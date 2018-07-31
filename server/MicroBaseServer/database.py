from os import listdir, remove
from os.path import isfile, join
from threading import Timer
import pickle
import funs
import classes
import language
import sendinfo
import commands
import variables
import usersdb

# Работа с базами данных и клиентами

CLOSE = False # флаг для полного завершения работы сервера
AUTOSAVETIMER = None # переменная для хранения таймера автосохранения баз данных
MAINSERVERSOCKET = None # переменная для хранения сокета сервера
TIMETOSAVE = variables.AUTOSAVETIME # интервал автосохранения баз данных
PATH = variables.DATABASEDIRECTORY # директория для хранения баз данных
DATABASES = dict() # переменная для хранения баз данных
ALLCLIENTS = [] # переменная для хранения подключенных клиентов
ISRELOADING = True # флаг показывающий перезагрузку сервера
QUERYTIME = {0:0} # Количество запросов за последнюю секунду
QUERYTIMEMIN = {0:0} # Количество запросов за последнюю минуту
QUERYES = 0 # Всего запросов
TIMESTART = 0 # Время запуска сервера

# Функция для получения клиентов в определенной базе данных
def GetClientsInDB(DataBase:classes.DataBase):
    return [Client for Client in ALLCLIENTS if Client.DataBase == DataBase]

# Функция для создания базы данных
def CreateDB(DB):
    if DB not in DATABASES.keys():
        path = '{}{}.DAT'.format(PATH, DB)
        DATABASES[DB] = classes.DataBase(DB, path, dict())
        with open(path, 'wb') as f:
            pickle.dump(dict(), f)
        return 'CreateBD'
    return 'BDExists'

# Функция для удаления базы данных
def DeleteDB(DB):
    if DB not in DATABASES.keys():
        return 'BDNotExists'
    del DATABASES[DB]
    try:
        remove('{}{}.DAT'.format(PATH, DB))
    except:
        pass
    usersdb.RemoveFromUsersDatabase(DB)
    return 'BDDeleted'

# Функция для сохранения баз данных
def SaveALL():
    print(language.SERVERLANG.SaveDatabases)
    for DB in DATABASES.values():
        with open(DB.path,'wb') as f:
            pickle.dump(DB.data, f)
    sendinfo.SendToAllListeners('ListenerAllDatabasesSaved', [])
    print(language.SERVERLANG.SavedDatabases)

# Функция для автосохранение базы данных с интервалом, указанным в variables.AUTOSAVETIME
def AutoSave():
    SaveALL()
    usersdb.SaveUsers()
    global AUTOSAVETIMER
    AUTOSAVETIMER = Timer(TIMETOSAVE, AutoSave)
    AUTOSAVETIMER.start()

# Функция для запуска возможности автосохранения
def StartAutoSave():
    global AUTOSAVETIMER
    if not CLOSE:
        AUTOSAVETIMER = Timer(TIMETOSAVE, AutoSave)
        AUTOSAVETIMER.start()

# Функция для создания основной базы данных - GLOBAL
def CreateGlobal():
    with open(PATH + 'GLOBAL.DAT', 'wb') as f:
        pickle.dump(dict(), f)
    DATABASES['GLOBAL'] = classes.DataBase('GLOBAL', PATH + 'GLOBAL.DAT', dict())

pathes = [f for f in listdir(PATH) if isfile(join(PATH, f))]
pathesUP = [s.upper() for s in pathes]

# Инициализация и загрузка баз данных в память
def InitializeDatabase():
    global DATABASES
    if 'GLOBAL.DAT' not in pathesUP:
        CreateGlobal()
    for path in pathes:
        try:
            if len(path) < 5 or path[-4:].upper() != '.DAT':
                continue
            name = path[:-4].upper()
            with open(PATH + path, 'rb') as f:
                DATABASES[name] = classes.DataBase(name, PATH + path, pickle.load(f))
        except: # если база данных повреждена, спрашивается возможность пересоздать ее
            print(language.SERVERLANG.CantOpenDatabase.format(path.upper())) 
            if path.upper() == 'GLOBAL.DAT':
                print(language.SERVERLANG.DatabaseGlobalCorrupted)
                if funs.GetAnswer():
                    CreateGlobal()
                else:
                    funs.CloseTheProgramm()
                    break
            else:
                name = path[:-4].upper()
                print(language.SERVERLANG.DatabaseCorrupted.format(name))
                if funs.GetAnswer():
                    CreateDB(name)
    dbs = set()
    for user in usersdb.USERS.values():
        for db in user.DataBases.keys():
            if db not in DATABASES:
                dbs.add(db)
    for Database in dbs:
        print(language.SERVERLANG.DatabaseNotFoundInPath.format(Database)) 
        if funs.GetAnswer():
            CreateDB(Database)
        else:
            for user in usersdb.USERS:
                if Database in user.DataBases:
                    del user.DataBases[Database]
    StartAutoSave()