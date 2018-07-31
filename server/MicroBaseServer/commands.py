import re
import subprocess
import datetime
import time
import database
import funs
from classes import ClientInformation
import sendinfo
import language
from language import LANGUAGE
import variables
import usersdb
import classes
import access

# Работа с командами

SPECSYMBOLS = (',', '\\', '[', ']', '{', '}','<','>', '^') # специальные символы, которые не могут быть использованы в командах

# Класс хранения переменных для передачи информации о доступе в режиме визуального клиента
class Inf:
    OK = '<OK>' # команда выполнена успешно
    Error = '<ERROR>' # произошла ошибка
    PermissionDenied = '<PERMISSION DENIED>' # ошибка доступа
    Info = '<INFO>' # информация или данные



# Функции для обработки команд от клиентов
# После выполнения команды, отправляются данные в формате (Краткая информация, Данные, Вывод пользователю) на дальнейшую обработку в функции вывода (например: OUTONLY)
# Далее определяется, пользователь если использует Telnet, выводится только "Вывод пользователю", а если в режиме визуального клиента, то "Краткая информация" и "данные"

# Показать справку
def COMHELP(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.DefaultHelp)

# Показать справку по управлению базами данных
def COMDBHELP(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.DBHelp)

# Показать справку по управлению данными
def COMVARHELP(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.VarHelp)

# Показать справку по прослушиванию
def COMLISTENINGHELP(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.ListeningHelp)

# Показать справку по различным другим командам
def COMOTHERHELP(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.OtherHelp)

# Показать информацию о дополнительных символах
def COMSYMBOLS(ClientInfo:ClientInformation):
    return (Inf.Info, ' '.join(SPECSYMBOLS),ClientInfo.language.HelpSpecSymbols.format(' '.join(SPECSYMBOLS)))

# Установить значение переменной
def COMSET(ClientInfo:ClientInformation, variable, value, *args):
    if not funs.CheckCommandDataBase(ClientInfo, 'SET'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    if not funs.CheckCorrectNameVariable(variable):
        return (Inf.Error, ClientInfo.language.NA, ClientInfo.language.NotCorrectNameOfVariable)
    data = [value,] + list(args)
    ClientInfo.DataBase.data[variable] = data
    sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerSet', [variable, ', '.join(data)])
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Получить значение переменной
def COMGET(ClientInfo:ClientInformation, variable):
    if not funs.CheckCommandDataBase(ClientInfo, 'GET'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Data = ', '.join(ClientInfo.DataBase.data.get(variable, [ClientInfo.language.NULL, ]))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Получить количество значений в переменной
def COMLEN(ClientInfo:ClientInformation, variable):
    if not funs.CheckCommandDataBase(ClientInfo, 'LEN'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Data = str(len(ClientInfo.DataBase.data.get(variable, [])))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Удалить переменную
def COMDEL(ClientInfo:ClientInformation, *args):
    if not funs.CheckCommandDataBase(ClientInfo, 'DEL'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    count = 0
    for var in args:
        if var in ClientInfo.DataBase.data:
            del ClientInfo.DataBase.data[var]
            sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerDel', [var, ])
            count += 1
    Data = str(count)
    return (Inf.OK, Data, '{}\r\n'.format(Data))

# Получить переменные и их значения
def COMVALUES(ClientInfo:ClientInformation, argument, filter=''):
    if not funs.CheckCommandDataBase(ClientInfo, 'VALUES'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    argument = argument.upper()
    sorting = None
    if filter != '':
        if len(filter) >= 2 and filter[-2] == '/':
            sorting = filter[-1].upper()
            filter = filter[:-2]
    if filter == '':
        filter = '*'
    filter = filter.replace('*', '.*').replace('?', '.')
    pattern = '^.*{}.*$'.format(filter)
    pattern = re.compile(pattern)
    if sorting not in [None, 'A', 'D']:
        return (Inf.Error, 'SORT', ClientInfo.language.InvalidSortingMethod)
    variabless = DataBase.data.keys()
    if sorting in ['A', 'D']:
        sorting = sorting == 'D'
        variabless = [var for var in sorted(variabless, reverse=sorting) if pattern.match(var)]
    else:
        variabless = [var for var in variabless if pattern.match(var)]
    if argument == 'LIST':
        Data = ', '.join(variabless)
        toret = Data + '\r\n'
        if len(toret) == 2:
            toret = ClientInfo.language.NoValues
        return (Inf.Info, Data, toret)
    elif argument == 'FULL':
        toret = ''
        Data = ''
        for var in variabless:
            toret += '{} = {}\r\n'.format(var, ', '.join(ClientInfo.DataBase.data.get(var, [ClientInfo.language.NULL, ])))
        if len(toret) == 0:
            toret = ClientInfo.language.NoValues
        else:
            Data = toret[:-2]
        return (Inf.Info, Data, toret)
    else:
        return (Inf.Error, 'ARG', ClientInfo.language.NotCorrectArgument)

# Создать базу данных
def COMCREATE(ClientInfo:ClientInformation, Database):
    if len(ClientInfo.CurrentUser.OwnerDataBases) >= ClientInfo.CurrentUser.MaxCountCreateDataBases and ClientInfo.CurrentUser.MaxCountCreateDataBases != -1 and ClientInfo.CurrentUser.UserRole != variables.ADMINISTRATORROLE:
        return (Inf.Error, 'MAXDB', ClientInfo.language.MaximumOfDataBases.format(ClientInfo.CurrentUser.MaxCountCreateDataBases))
    Database = Database.upper()
    if not funs.CheckCorrectNameVariable(Database):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfDatabase)
    message = database.CreateDB(Database)
    if message == 'CreateBD':
        sendinfo.SendToAllListeners('ListenerAllCreate', [Database, ])
        ClientInfo.CurrentUser.DataBases[Database] = classes.AccessDataBase(True, True, True, True, True, True, True)
        ClientInfo.CurrentUser.OwnerDataBases.append(Database)
        return (Inf.OK, Database, ClientInfo.language[message].format(Database))
    elif message == 'BDExists':
        return (Inf.Error, 'EXISTS', ClientInfo.language[message].format(Database))

# Удалить базу данных
def COMDBDEL(ClientInfo:ClientInformation, Database):
    Database = Database.upper()
    if Database == 'GLOBAL':
        return (Inf.Error, 'MAIN', ClientInfo.language.BDCantDeleteMainBase)
    if not funs.CheckCorrectNameVariable(Database):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfDatabase)
    if Database not in database.DATABASES:
        return (Inf.Error, 'NOTEXISTS', ClientInfo.language.BDNotExists.format(Database))

    if not funs.CheckCommandDataBase(ClientInfo, 'DBDEL', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)

    DataBase = database.DATABASES[Database]
    if ClientInfo.DataBase == DataBase:
        return (Inf.Error, 'CURRENT', ClientInfo.language.BDCantDeleteCurrent)
    if len(database.GetClientsInDB(DataBase)) > 0:
        return (Inf.Error, 'USERS', ClientInfo.language.BDCantDeleteWhereUsers)
    message = database.DeleteDB(Database)
    if message == 'BDDeleted':
        sendinfo.SendToAllListeners('ListenerAllDelete', [Database, ])
        return (Inf.OK, ClientInfo.language.NA, ClientInfo.language[message].format(Database))
    elif message == 'BDNotExists':
        return (Inf.Error, 'NOTEXISTS', ClientInfo.language[message].format(Database))

# Очистить базу данных
def COMDBCLEAR(ClientInfo:ClientInformation, Database):
    Database = Database.upper()
    if not funs.CheckCorrectNameVariable(Database):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfDatabase)
    if Database not in database.DATABASES:
        return (Inf.Error, 'NOTEXISTS', ClientInfo.language.BDNotExists.format(Database))

    if not funs.CheckCommandDataBase(ClientInfo, 'DBCLEAR', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)

    DataBase = database.DATABASES[Database]
    DataBase.data = dict()
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.BDCleared.format(Database))

# Показать количество подключений к базе данных
def COMCOUNTCONNECTIONSSDB(ClientInfo:ClientInformation, *args):
    Database = args[0].upper() if len(args) > 0 else ClientInfo.DataBase.name
    if Database not in database.DATABASES:
        return (Inf.Error, 'NOTEXISTS', ClientInfo.language.BDNotExists.format(Database))

    if not funs.CheckCommandDataBase(ClientInfo, 'COUNTUSERSDB', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Data = len(database.GetClientsInDB(database.DATABASES[Database]))
    return (Inf.Info, str(Data), '{}\r\n'.format(Data))

# Показать количество переменных в базе данных
def COMCOUNTVARS(ClientInfo:ClientInformation, *args):
    DataBase = ClientInfo.DataBase

    if not funs.CheckCommandDataBase(ClientInfo, 'COUNTVARS'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Data = str(len(DataBase.data.keys()))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Показать количество значений в переменных в базе данных
def COMLENVARIABLES(ClientInfo:ClientInformation, *args):
    if not funs.CheckCommandDataBase(ClientInfo, 'LENVARIABLES'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    result = ''
    DataBase = ClientInfo.DataBase
    LenOfVariables = [len(value) for value in DataBase.data.values()]
    DictLenOfVariables = dict()
    for count in LenOfVariables:
        if count in DictLenOfVariables:
            DictLenOfVariables[count] += 1
        else:
            DictLenOfVariables[count] = 1
    for count in sorted(DictLenOfVariables.keys()):
        result += '{}: {}\r\n'.format(count, DictLenOfVariables[count])
    Data = result[:-2]
    return (Inf.Info, Data, result)

# Проверить на существование переменных в базе данных
def COMEXISTS(ClientInfo:ClientInformation, *args):
    if not funs.CheckCommandDataBase(ClientInfo, 'EXISTS'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    count = 0
    for key in args:
        if key in DataBase.data:
            count+=1
    Data = str(count)
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Добавить значение к переменной в базе данных
def COMAPPEND(ClientInfo:ClientInformation, variable, value, position=None):
    if not funs.CheckCommandDataBase(ClientInfo, 'APPEND'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    if not funs.CheckCorrectNameVariable(variable):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfVariable)
    DataBase = ClientInfo.DataBase
    if variable in DataBase.data:
        if position == None:
            position = len(DataBase.data[variable])
        else:
            try:
                position = int(position)
            except:
                return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
        if position < 0 or position > len(DataBase.data[variable]):
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)
        DataBase.data[variable].insert(position, value)
    else:
        if position == None:
            position = 0
        else:
            try:
                position = int(position)
            except:
                return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
        if position != 0:
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)               
        DataBase.data[variable] = [value, ]

    sendinfo.SendToListeners(DataBase, 'ListenerAppend', [value, variable, position])

    Data = str(len(DataBase.data[variable]))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Переименовать переменную в базе данных
def COMRENAME(ClientInfo:ClientInformation, var1, var2):
    if not funs.CheckCommandDataBase(ClientInfo, 'RENAME'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    if not funs.CheckCorrectNameVariable(var1) or not funs.CheckCorrectNameVariable(var2):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfVariable)
    DataBase = ClientInfo.DataBase
    if var1 in DataBase.data:
        DataBase.data[var2] = DataBase.data[var1]
        del DataBase.data[var1]
    else:
        return (Inf.Error, 'VARNOTFOUND', ClientInfo.language.VariableNotFound.format(var1))
    sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerRename', [var1, var2])
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Начать прослушивание базы данных
def COMLISTEN(ClientInfo:ClientInformation):
    if not funs.CheckCommandDataBase(ClientInfo, 'LISTEN'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    if not ClientInfo.Listen and not ClientInfo.ListenAll:
        ClientInfo.Listen = True
        return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.StartListening.format(ClientInfo.DataBase.name))
    return (Inf.Error, 'CURRENTLISTENING', ClientInfo.language.CurrentListening)

# Получить количество слушателей в базе данных
def COMLISTENERSDB(ClientInfo:ClientInformation):
    if not funs.CheckCommandDataBase(ClientInfo, 'LISTENERSDB'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Total = 0
    for Client in database.GetClientsInDB(ClientInfo.DataBase):
        if Client.Listen:
            Total += 1
            continue
    Data = str(Total)
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Увеличить на 1 значение в переменной
def COMINCR(ClientInfo:ClientInformation, variable, position=0):
    if not funs.CheckCommandDataBase(ClientInfo, 'INCR'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    if position != 0:
        try:
            position = int(position)
        except:
            return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
    if variable in DataBase.data:
        if position < 0 or position >= len(DataBase.data[variable]):
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)
        try:
            DataBase.data[variable][position] = str(int(DataBase.data[variable][position]) + 1)
        except:
            return (Inf.Error, 'VARNOTNUMBER', ClientInfo.language.VariableNotNumber)
        sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerAdd', [variable, 1, position, DataBase.data[variable][position]])
        return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.OK)
    else:
        return (Inf.Error, 'VARNOTFOUND', ClientInfo.language.NotFound)

# Уменьшить на 1 значение в переменной
def COMDECR(ClientInfo:ClientInformation, variable, position=0):
    if not funs.CheckCommandDataBase(ClientInfo, 'DECR'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    if position != 0:
        try:
            position = int(position)
        except:
            return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
    if variable in DataBase.data:
        if position < 0 or position >= len(DataBase.data[variable]):
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)
        try:
            DataBase.data[variable][position] = str(int(DataBase.data[variable][position]) - 1)
        except:
            return (Inf.Error, 'VARNOTNUMBER', ClientInfo.language.VariableNotNumber)
        sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerSub', [variable, 1, position, DataBase.data[variable][position]])
        return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.OK)
    else:
        return (Inf.Error, 'VARNOTFOUND', ClientInfo.language.NotFound)

# Получить роль пользователя в СУБД
def COMGETUSERROLE(ClientInfo:ClientInformation, login):
    if login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTFOUND', ClientInfo.language.UserIsNotExists)
    return (Inf.OK, usersdb.USERS[login].UserRole, '{}\r\n'.format(usersdb.USERS[login].UserRole))

# Увеличить на value значение в переменной
def COMADD(ClientInfo:ClientInformation, variable, value, position=0):
    if not funs.CheckCommandDataBase(ClientInfo, 'ADD'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    try:
        value = int(value)
    except:
        return (Inf.Error, 'VALUENOTNUMBER', ClientInfo.language.ValueNotNumber)
    if position != 0:
        try:
            position = int(position)
        except:
            return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
    if variable in DataBase.data:
        if position < 0 or position >= len(DataBase.data[variable]):
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)
        try:
            DataBase.data[variable][position] = str(int(DataBase.data[variable][position]) + value)
        except:
            return (Inf.Error, 'VARNOTNUMBER', ClientInfo.language.VariableNotNumber)
        sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerAdd', [variable, value, position, DataBase.data[variable][position]])
        return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.OK)
    else:
        return (Inf.Error, 'VARNOTFOUND', ClientInfo.language.NotFound)

# Уменьшить на value значение в переменной
def COMSUB(ClientInfo:ClientInformation, variable, value, position=0):
    if not funs.CheckCommandDataBase(ClientInfo, 'SUB'):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    DataBase = ClientInfo.DataBase
    try:
        value = int(value)
    except:
        return (Inf.Error, 'VALUENOTNUMBER', ClientInfo.language.ValueNotNumber)
    if position != 0:
        try:
            position = int(position)
        except:
            return (Inf.Error, 'NOTNUMPOS', ClientInfo.language.NotNumericWherePosition)
    if variable in DataBase.data:
        if position < 0 or position >= len(DataBase.data[variable]):
            return (Inf.Error, 'INDEXOUTOFRANGE', ClientInfo.language.IndexOutOfRange)
        try:
            DataBase.data[variable][position] = str(int(DataBase.data[variable][position]) - value)
        except:
            return (Inf.Error, 'VARNOTNUMBER', ClientInfo.language.VariableNotNumber)
        sendinfo.SendToListeners(ClientInfo.DataBase, 'ListenerSub', [variable, value, position, DataBase.data[variable][position]])
        return (Inf.Info, ClientInfo.language.NA, ClientInfo.language.OK)
    else:
        return (Inf.Error, 'VARNOTFOUND', ClientInfo.language.NotFound)

# Начать использовать базу данных
def COMUSE(ClientInfo:ClientInformation, Database):
    Database = Database.upper()
    if ClientInfo.Listen:
        return (Inf.Error, 'CANTUSEWHENLISTENING', ClientInfo.language.CantUseWhenListening)
    if not funs.CheckCorrectNameVariable(Database):
        return (Inf.Error, 'NAME', ClientInfo.language.NotCorrectNameOfDatabase)
    if Database in database.DATABASES:

        if not funs.CheckCommandDataBase(ClientInfo, 'USE', Database):
            return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)

        ClientInfo.DataBase = database.DATABASES[Database]

        return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)
    else:
        return (Inf.Error, 'NOTEXISTS', ClientInfo.language.BDNotExists.format(Database))

# Получить общее количество слушателей из всех баз данных
def COMLISTENERS(ClientInfo:ClientInformation):
    Data = dict()
    AllListeners = 0
    ListenersFromDatabases = ''
    Total = 0
    for Client in database.ALLCLIENTS:
        if Client.ListenAll:
            AllListeners += 1
            Total += 1
            continue
        if Client.Listen:
            if Client.DataBase.name not in Data:
                Data[Client.DataBase.name] = 0
            Data[Client.DataBase.name] = Data[Client.DataBase.name] + 1
            Total += 1
            continue
    for name in sorted(Data.keys()):
        ListenersFromDatabases += '{}: {}\r\n'.format(name, Data[name])
    Data = '{}\r\n{}\r\n{}'.format(AllListeners, ListenersFromDatabases, Total)
    return (Inf.Info, Data, ClientInfo.language.Listeners.format(AllListeners, ListenersFromDatabases, Total))

# Показать общее количество переменных в базах данных
def COMCOUNTVARSALL(ClientInfo:ClientInformation):
    count = 0
    for Database in sorted(database.DATABASES.keys()):
        DataBase = database.DATABASES[Database]
        count += len(DataBase.data.keys())
    Data = str(count)
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Вывести список баз данных на сервере
def COMDBALL(ClientInfo:ClientInformation):
    return (Inf.Info,', '.join(sorted(database.DATABASES.keys())), ', '.join(sorted(database.DATABASES.keys())) + '\r\n')

# Сохранить базы данных на сервере
def COMSAVE(ClientInfo:ClientInformation):
    database.SaveALL()
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.Saved)

# Вывести текущую базу данных
def COMCURRENTDB(ClientInfo:ClientInformation):
    Data = ClientInfo.DataBase.name
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Вывести количество пользователей в базе данных
def COMCOUNTUSERS(ClientInfo:ClientInformation):
    Data = str(len(usersdb.USERS))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Получить информацию о текущих соединениях
def COMGETCONNECTIONS(ClientInfo:ClientInformation):
    Data = []
    for con in database.ALLCLIENTS:
        Data.append('{}:{}'.format(*con.addr))
        Data.append(', ')
        Data.append(con.CurrentUser.login)
        Data.append(', ')
        Data.append(con.DataBase.name)
        Data.append('\r\n')
    return (Inf.Info, ''.join(Data[:-1]), ''.join(Data))

# Вывести текущее количество соединений с сервером
def COMCOUNTCONNECTIONS(ClientInfo:ClientInformation):
    Data = str(len(database.ALLCLIENTS))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Вывести количество переменных в базах данных
def COMCOUNTVARSALLDB(ClientInfo:ClientInformation, *args):
    result = ''
    for Database in sorted(database.DATABASES.keys()):
        DataBase = database.DATABASES[Database]
        result += '{}: {}\r\n'.format(Database, len(DataBase.data.keys()))
    Data = result[:-2]
    return (Inf.Info, Data, result)

# Вывести количество значений в переменных из всех баз данных
def COMLENVARIABLESALL(ClientInfo:ClientInformation, *args):
    result = ''
    DictLenOfVariables = dict()
    for Database in sorted(database.DATABASES.keys()):
        DataBase = database.DATABASES[Database]
        LenOfVariables = [len(value) for value in DataBase.data.values()]
        for count in LenOfVariables:
            if count in DictLenOfVariables:
                DictLenOfVariables[count] += 1
            else:
                DictLenOfVariables[count] = 1
    for count in sorted(DictLenOfVariables.keys()):
        result += '{}: {}\r\n'.format(count, DictLenOfVariables[count])
    Data = result[:-2]
    return (Inf.Info, Data, result)

# Вывести полученную строку
def COMECHO(ClientInfo:ClientInformation, value):
    Data = value
    return (Inf.OK, Data, '{}\r\n'.format(Data))

# Остановить любое прослушивание
def COMSTOP(ClientInfo:ClientInformation):
    if ClientInfo.Listen or ClientInfo.ListenAll:
        if ClientInfo.Listen:
            ClientInfo.Listen = False  
            return (Inf.OK, ClientInfo.DataBase.name, ClientInfo.language.StopListening.format(ClientInfo.DataBase.name))
        if ClientInfo.ListenAll:
            ClientInfo.ListenAll = False  
            return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.StopListening.format(''))
    return (Inf.Info, 'NOTLISTENING', ClientInfo.language.YouAreNotListening)

# Выдать информацию о памяти и CPU
def COMINFO(ClientInfo:ClientInformation):
    try:
        import psutil
        MemoryUse = psutil.virtual_memory()[3]/2.**20
        TotalMemory = psutil.virtual_memory()[0]/2.**20
        CPUUsed = psutil.cpu_percent(interval=None)
    except:
        MemoryUse = 0
        TotalMemory = 0
        CPUUsed = 0
    now = int(time.time())
    Sec = database.QUERYTIME.get(now,0)
    Min = database.QUERYTIMEMIN.get(now//60,0)
    Uptime = now - database.TIMESTART
    Data = 'MEMUSE: {}\r\nMEMTOT: {}\r\nCPU: {}\r\nSEC: {}\r\nMIN: {}\r\nTOTAL: {}\r\nTIME: {}'.format(MemoryUse, TotalMemory, CPUUsed, Sec, Min, database.QUERYES, Uptime)
    Data2 = ClientInfo.language.InfoCommand.format(MemoryUse, TotalMemory, CPUUsed, Sec, Min, database.QUERYES, Uptime)
    return (Inf.Info, Data, Data2)

# Начать прослушивание всех изменений в бд
def COMLISTENALL(ClientInfo:ClientInformation):
    if ClientInfo.Listen or ClientInfo.ListenAll:
        return (Inf.Info, 'CURRENTLISTENING', ClientInfo.language.CurrentListening)
    ClientInfo.ListenAll = True
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.StartListeningAll)

# Произвести отключение от сервера
def COMQUIT(ClientInfo:ClientInformation):
    ClientInfo.VisualClient = False
    try:
        ClientInfo.socket.close()
    except:
        pass
    try:
        database.ALLCLIENTS.remove(ClientInfo)
        print(language.SERVERLANG.ClientDisconnected.format(*ClientInfo.addr))
    except:
        pass

# Вывести список существующих команд на сервере
def COMLSALL(ClientInfo:ClientInformation):
    Data = ', '.join(sorted(COMMANDS.keys()))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Вывести список доступных команд пользователю
def COMLS(ClientInfo:ClientInformation):
    if ClientInfo.CurrentUser.UserRole == usersdb.ADMINISTRATOR.UserRole:
        Data = ', '.join(sorted(COMMANDS.keys()))
    else:
        Data = ', '.join(sorted(set(ClientInfo.CurrentUser.UserCommands) | set(access.ACCESSLEVEL[ClientInfo.CurrentUser.UserRole])))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Вывести общее количество команд на сервере
def COMCOUNTCOMMANDS(ClientInfo:ClientInformation):
    Data = str(len(COMMANDS.keys()))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Выключить сервер удаленно
def COMSHUTDOWN(ClientInfo:ClientInformation):
    ClientInfo.VisualClient = False
    funs.CloseTheProgramm()

# Перезагрузить сервер удаленно
def COMRELOAD(ClientInfo:ClientInformation):
    ClientInfo.VisualClient = False
    funs.CloseTheProgramm(Reload=True)

# Очистка экрана для клиента (вывод 50 пустых строк)
def COMCLEAR(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.language.NA, '\r\n' * 50)

# Исполнение команды python
def COMEVAL(ClientInfo:ClientInformation, command):
    try:
        Data = str(eval(command))
        return (Inf.Info, Data, '{}\r\n'.format(Data))
    except Exception as ex:
        return (Inf.Error,ex.args[0], '{}\r\n'.format(ex.args[0]))

# Исполнение команды операционной системы
def COMEXEC(ClientInfo:ClientInformation, command):
    if ClientInfo.VisualClient:
        return (Inf.Error, 'NOTAVAIBLEINVISUALMODE', '\r\n')
    try:
        output = subprocess.check_output(command, shell=True)
        if len(output) == 0:
            output = '\r\n'.encode()
        ClientInfo.socket.send(output)
    except Exception as ex:
        ClientInfo.socket.send('{}\r\n'.format(ex.args[0]).encode())

# Вывести список возможных языков на сервере
def COMLANGS(ClientInfo:ClientInformation):
    Data = ', '.join(sorted(LANGUAGE.keys()))
    return (Inf.OK, Data, '{}\r\n'.format(Data))

# Установка языка для клиента
def COMSETLANG(ClientInfo:ClientInformation, language):
    language = language.upper()
    if language not in LANGUAGE.keys():
        return (Inf.Error, 'INCORRECTLANG', ClientInfo.language.IncorrectLanguage)
    ClientInfo.language = LANGUAGE[language]
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.ChooseLanguage)

# Вывод информации о программе
def COMABOUT(ClientInfo:ClientInformation):
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.AboutProgram)

# Регистрация пользователя
def COMREGISTER(ClientInfo:ClientInformation, Login, Password, ConfirmPassword):
    if len(Login) > 15:
        return (Inf.Error, '15', ClientInfo.language.LoginLength)
    if not variables.REGISTRATION and ClientInfo.CurrentUser.UserRole != variables.ADMINISTRATORROLE:
        return (Inf.Error, 'REGISTERNOTAVAIBLE', ClientInfo.language.RegistrationIsNotAvaible)
    if Password != ConfirmPassword:
        return (Inf.Error, 'PASSWORDSDONOTMATCH', ClientInfo.language.PasswordsDoNotMatch)
    HashPassword = funs.EncryptString(Password)
    RegUser = classes.User(Login, HashPassword, variables.REGISTRATIONROLE, variables.MAXIMUMCREATEDATABASE)
    Complete = usersdb.CreateUser(RegUser)
    Message = ClientInfo.language[Complete]
    if Complete == 'NotCorrectLoginUser':
        return (Inf.Error, 'NOTCORRECTLOGINUSER', Message)
    if Complete == 'UserIsExists':
        return (Inf.Error, 'USEREXISTS', Message)
    return (Inf.OK, ClientInfo.language.NA, Message)

# Вход пользователя    
def COMLOGIN(ClientInfo:ClientInformation, Login, Password):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    HashPassword = funs.EncryptString(Password)
    if usersdb.USERS[Login].password.lower() != HashPassword.lower():
        return (Inf.Error, 'PASSWORDSDONOTMATCH', ClientInfo.language.PasswordsDoNotMatchInDataBase)
    ClientInfo.CurrentUser = usersdb.USERS[Login]
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.LoginSuccessful)

# Удаление пользователя    
def COMDELUSER(ClientInfo:ClientInformation, Login):
    Complete = usersdb.DeleteUser(Login)
    Message = ClientInfo.language[Complete]
    if Complete == 'UserIsNotExists':
        return (Inf.Error, 'USERNOTEXISTS', Message)
    if Complete == 'ThisUserCannotChange':
        return (Inf.Error, 'CANNOTCHANGE', Message)
    return (Inf.OK, ClientInfo.language.NA, Message)

# Изменение пароля
def COMCHANGEPASSWORD(ClientInfo:ClientInformation, OldPassword, Password, ConfirmPassword):
    if Password != ConfirmPassword:
        return (Inf.Error, 'PASSWORDSDONOTMATCH', ClientInfo.language.PasswordsDoNotMatch)
    HashOldPassword = funs.EncryptString(OldPassword)
    HashPassword = funs.EncryptString(Password)
    if ClientInfo.CurrentUser.password.lower() != HashOldPassword.lower():
        return (Inf.Error, 'PASSWORDSDONOTMATCHINDB', ClientInfo.language.PasswordsDoNotMatchInDataBase)
    Complete = usersdb.ChangePassword(ClientInfo.CurrentUser, HashPassword)
    Message = ClientInfo.language[Complete]
    if Complete == 'UserIsNotExists':
        return (Inf.Error, 'USERNOTEXISTS', Message)
    if Complete == 'ThisUserCannotChange':
        return (Inf.Error, 'CANNOTCHANGE', Message)
    return (Inf.OK, ClientInfo.language.NA, Message)

# Посмотреть доступные команды пользователя
def COMUSERCOMMANDS(ClientInfo:ClientInformation, Login):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]
    RoleCommands =  set(access.ACCESSLEVEL[User.UserRole])
    AddedCommands = set(User.UserCommands)
    Commands = RoleCommands | AddedCommands
    Data = ', '.join(sorted(Commands))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Посмотреть информацию о пользователе
def COMGETUSERINFO(ClientInfo:ClientInformation, Login):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]
    Data = 'Login: {}\r\nPassword: {}\r\nRole: {}\r\nMaxCount: {}\r\nUserComm: {}\r\nDatabases: {}\r\nOwnerDatabases: {}'.format(
        User.login, User.password, User.UserRole, User.MaxCountCreateDataBases, 
        ', '.join(sorted(set(access.ACCESSLEVEL[User.UserRole]) | set(User.UserCommands))), ', '.join(User.DataBases.keys()), 
        ', '.join(User.OwnerDataBases))
    return (Inf.Info, Data, ClientInfo.language.GetUserInfo.format(User.login, User.password, User.UserRole, User.MaxCountCreateDataBases, ', '.join(User.UserCommands), ', '.join(User.DataBases.keys()), ', '.join(User.OwnerDataBases)))

# Получить информацию о себе
def COMGETMYINFO(ClientInfo:ClientInformation):
    return COMGETUSERINFO(ClientInfo, ClientInfo.CurrentUser.login)

# Получить пользователей базы данных с доступами
def COMGETUSERSDB(ClientInfo:ClientInformation, *args):
    Database = ClientInfo.DataBase.name
    if len(args) > 0:
        Database = args[0].upper()
        if Database not in database.DATABASES:
            return (Inf.Error, 'DBNOTFOUND', ClientInfo.language.BDNotExists.format(Database))
        Database = database.DATABASES[database].name
    if not funs.CheckCommandDataBase(ClientInfo, 'GETUSERSDB', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Data = []
    for user in usersdb.USERS.values():
        if Database in user.DataBases:
            Data.append('{}: {}'.format(user.login, ', '.join([i for i in dir(user.DataBases[Database]) if not i.startswith('_') and getattr(user.DataBases[Database], i)])))
            Data.append('\r\n')
    return (Inf.Info, ''.join(Data[:-1]), ''.join(Data))

# Получить информацию о доступах в базы данных
def COMGETACCESSDB(ClientInfo:ClientInformation, login=''):
    if login == '':
        login = ClientInfo.CurrentUser.login
    Data = []
    for (Database, Access) in usersdb.USERS[login].DataBases.items():
            Data.append('{}: {}'.format(Database, ', '.join([i for i in dir(Access) if not i.startswith('_') and getattr(Access, i)])))
            Data.append('\r\n')
    return (Inf.Info, ''.join(Data[:-1]), ''.join(Data))

# Получить список ролей
def COMGETROLES(ClientInfo:ClientInformation):
    Data = ', '.join(access.ACCESSLEVEL.keys())
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Получить список комманд роли
def COMGETROLECOMMANDS(ClientInfo:ClientInformation, Role):
    if Role not in access.ACCESSLEVEL:
        return (Inf.Error, 'NOTFOUND', ClientInfo.language.NotFound)
    Data = ', '.join(access.ACCESSLEVEL)
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Получить стандартных пользователей
def COMGETSTANDARTUSERS(ClientInfo:ClientInformation):
    Data = '{} - {}, {}\r\n{} - {}, {}'.format('ADMINISTRATOR', variables.ADMINISTRATORNAME, variables.ADMINISTRATORPASSWORD, 'DEFAULT', variables.DEFAULTNAME, variables.DEFAULTROLE)
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Изменить комманды пользователя
def COMCHANGEUSERCOMMANDS(ClientInfo:ClientInformation, Login, *args):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]
    Commands = []
    for com in args:
        com = com.upper()
        if com not in COMMANDS:
            return (Inf.Error, 'COMMANDNOTFOUND', ClientInfo.language.CommandNotFound)
        Commands.append(com)
    User.UserCommands = Commands
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Список всех пользователей в базе данных
def COMUSERS(ClientInfo:ClientInformation):
    Data = ', '.join(sorted(usersdb.USERS.keys()))
    return (Inf.Info, Data, '{}\r\n'.format(Data))

# Изменить роль пользователя
def COMCHANGEROLE(ClientInfo:ClientInformation, Login, Role):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]
    if Role not in access.ACCESSLEVEL:
        return (Inf.Error, 'ROLENOTFOUND', ClientInfo.language.RoleNotFound)
    User.UserRole = Role
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Изменить настройки пользователя
def COMCHANGEUSER(ClientInfo: ClientInformation, Login, NewLogin, NewPassword, NewRole, NewMaxCommands, *Commands):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    if Login != NewLogin:
        if Login.upper() == ClientInfo.CurrentUser.login.upper():
            return (Inf.Error, 'CANNOTYOURSELF', ClientInfo.language.CannotUseOnYourself)
        if len(NewLogin) > 15:
            return (Inf.Error, 'LOGINLENGTH', ClientInfo.language.LoginLength)
        if NewLogin.lower() in (u.lower() for u in usersdb.USERS):
            return (Inf.Error, 'NEWLOGINEXISTS', ClientInfo.language.RegistrationIsNotAvaible)
    if NewPassword.lower() != usersdb.USERS[Login].password.lower():
        NewPassword = funs.EncryptString(NewPassword)
    if NewRole not in access.ACCESSLEVEL:
        return (Inf.Error, 'ROLENOTFOUND', ClientInfo.language.RoleNotFound)
    try:
        NewMaxCommands = int(NewMaxCommands)
        if NewMaxCommands < 0:
            NewMaxCommands = -1
    except:
        return (Inf.Error, 'NOTANUMBER', ClientInfo.language.VariableNotNumber)
    Commands = [com.upper() for com in Commands]
    for com in Commands:
        if com not in COMMANDS:
            return (Inf.Error, 'COMMANDNOTFOUND', ClientInfo.language.CommandNotFound)
    user = usersdb.USERS[Login] 
    del usersdb.USERS[Login]
    user.password = NewPassword
    user.UserRole = NewRole
    user.MaxCountCreateDataBases = NewMaxCommands
    user.UserCommands = Commands
    usersdb.USERS[NewLogin] = user
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

    
# Добавить пользователя в базу данных
def COMADDUSERTODB(ClientInfo:ClientInformation, Database, Login):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]  
    if Login == ClientInfo.CurrentUser.login:
        return (Inf.Error, 'CANNOTYOURSELF', ClientInfo.language.CannotUseOnYourself)
    Database = Database.upper()  
    if Database not in database.DATABASES:
        return (Inf.Error, 'DBNOTEXISTS', ClientInfo.language.BDNotExists.format(Database))
    if Database in User.DataBases:
        return (Inf.Info, 'USERCURRENTDB', ClientInfo.language.UserAddedToDB)
    if not funs.CheckCommandDataBase(ClientInfo, 'ADDUSERTODB', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    User.DataBases[Database] = classes.AccessDataBase(True, False, True, False, False, True, False)
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Удалить пользователя из базы данных
def COMREMOVEUSERFROMDB(ClientInfo:ClientInformation, Database, Login):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]  
    if Login == ClientInfo.CurrentUser.login:
        return (Inf.Error, 'CANNOTYOURSELF', ClientInfo.language.CannotUseOnYourself)
    Database = Database.upper()  
    if Database not in database.DATABASES:
        return (Inf.Error, 'DBNOTEXISTS', ClientInfo.language.BDNotExists.format(Database))
    if Database not in User.DataBases:
        return (Inf.Info, 'USERNOTINDB', ClientInfo.language.UserNotAddedToDB)
    if not funs.CheckCommandDataBase(ClientInfo, 'REMOVEUSERFROMDB', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    del User.DataBases[Database]
    if Database in User.OwnerDataBases:
        User.OwnerDataBases.remove(Database)
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Изменить у пользователя роль в базе данных
def COMCHANGEACCESS(ClientInfo:ClientInformation, Database, Login, Access, Main, Read, Write, Delete, Listen, Info):
    if Login not in usersdb.USERS:
        return (Inf.Error, 'USERNOTEXISTS', ClientInfo.language.UserIsNotExists)
    User = usersdb.USERS[Login]  
    if Login == ClientInfo.CurrentUser.login:
        return (Inf.Error, 'CANNOTYOURSELF', ClientInfo.language.CannotUseOnYourself)
    Database = Database.upper()  
    if Database not in database.DATABASES:
        return (Inf.Error, 'DBNOTEXISTS', ClientInfo.language.BDNotExists.format(Database))
    if Database not in User.DataBases:
        return (Inf.Error, 'USERNOTINDB', ClientInfo.language.UserNotAddedToDB)
    if not funs.CheckCommandDataBase(ClientInfo, 'CHANGEACCESS', Database):
        return (Inf.PermissionDenied, ClientInfo.language.NA, ClientInfo.language.PermissionDenied)
    Access = funs.StringToBool(Access)
    Main = funs.StringToBool(Main)
    Read = funs.StringToBool(Read)
    Write = funs.StringToBool(Write)
    Delete = funs.StringToBool(Delete)
    Listen = funs.StringToBool(Listen)
    Info = funs.StringToBool(Info)
    if None in (Access, Main, Read, Write, Delete, Listen, Info):
        return (Inf.Error, 'PARAMNOTBOOL', ClientInfo.language.OneOfParametersIsNotBool)
    AccessDB = classes.AccessDataBase(Access, Main, Read, Write, Delete, Listen, Info)
    User.DataBases[Database] = AccessDB
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Включение/отключение режима визуального клиента
def COMVISUAL(ClientInfo:ClientInformation):
    ClientInfo.VisualClient = not ClientInfo.VisualClient
    return (Inf.OK, ClientInfo.language.NA, ClientInfo.language.OK)

# Текущий пользователь
def COMME(ClientInfo:ClientInformation):
    return (Inf.Info, ClientInfo.CurrentUser.login, '{}\r\n'.format(ClientInfo.CurrentUser.login))

def COMDATE(ClientInfo:ClientInformation):
    Date = str(datetime.date.today())
    return (Inf.Info, Date, '{}\r\n'.format(Date))

def COMTIME(ClientInfo:ClientInformation):
    Time = '{:02d}:{:02d}:{:02d}'.format(datetime.datetime.now().hour, datetime.datetime.now().minute, datetime.datetime.now().second)
    return (Inf.Info, str(Time), '{}\r\n'.format(Time))

# Получить время старта сервера
def COMGETSPACE(ClientInfo:ClientInformation):
    return (Inf.OK, '', '\r\n')

# Получить установленные настройки на сервере    
def COMGETSETTINGS(ClientInfo:ClientInformation):
    return (Inf.OK, '', '\r\n')

# Установить настройки на сервере
def COMSETSETTINGS(ClientInfo:ClientInformation):
    return (Inf.OK, '', '\r\n')

# Функции для вывода сообщений в нужном виде

# Отправка сообщения пользователю с кодированием сообщения
def OUTONLY(ClientInfo:ClientInformation, Info, Data, Out):
    if not ClientInfo.VisualClient:
        if Info == Inf.Info:
            return Out.encode(), Info
        if Info == Inf.PermissionDenied or Info == Inf.Error:
            return ('\033[0;31m' + str(Out) + '\033[0;37m').encode(), Info
        if Info == Inf.OK:
            return ('\033[0;36m' + str(Out) + '\033[0;37m').encode(), Info
    else:
        return funs.OutForVisual(Info, Data).encode(), Info

# Отправка сообщения пользователю без кодирования сообщения
def RETURNINFO(ClientInfo:ClientInformation, Info, Data, Out):
    if not ClientInfo.VisualClient:
        return Out, Info
    else:
        return funs.OutForVisual(Info, Data).encode(), Info

# Ничего не выводить
def DONOTHING(ClientInfo:ClientInformation, Info, Data, Out):
    if ClientInfo.VisualClient:
        return funs.OutForVisual(Info, Data).encode(), Info

# Ключ - имя команды, значение - (функция для команды, функция для вывода, минимальное число аргументов, максимальное число аргументов(-1 - неограничено))
COMMANDS = {
    # Справочные команды
    'HELP' : (COMHELP, OUTONLY, 0, 0),
    'DBHELP' : (COMDBHELP, OUTONLY, 0, 0),
    'VARHELP' : (COMVARHELP, OUTONLY, 0, 0),
    'LISTENINGHELP' : (COMLISTENINGHELP, OUTONLY, 0, 0),
    'OTHERHELP' : (COMOTHERHELP, OUTONLY, 0, 0),
    'LS' : (COMLS, OUTONLY, 0, 0),
    'LSALL' : (COMLSALL, OUTONLY, 0, 0),
    'SYMBOLS' : (COMSYMBOLS, OUTONLY, 0, 0),
    'ABOUT' : (COMABOUT, OUTONLY, 0, 0),

    # Команды работы с пользователями
    'REGISTER' : (COMREGISTER, OUTONLY, 3, 3),
    'LOGIN' : (COMLOGIN, OUTONLY, 2, 2),
    'DELUSER' : (COMDELUSER, OUTONLY, 1, 1),
    'CHANGEPASSWORD' : (COMCHANGEPASSWORD, OUTONLY, 3, 3),
    'USERS' : (COMUSERS, OUTONLY, 0, 0),
    'ME' : (COMME, OUTONLY, 0, 0),
    'CHANGEUSER' : (COMCHANGEUSER, OUTONLY, 5, -1),
    'GETUSERINFO' : (COMGETUSERINFO, OUTONLY, 1, 1),
    'GETMYINFO' : (COMGETMYINFO, OUTONLY, 0, 0),
    'GETSTANDARTUSERS' : (COMGETSTANDARTUSERS, OUTONLY, 0, 0),

    # Команды работы с базами данных
    'CREATE' : (COMCREATE, OUTONLY, 1, 1),
    'USE' : (COMUSE, OUTONLY, 1, 1),
    'DBDEL': (COMDBDEL, OUTONLY, 1, 1),
    'DBALL': (COMDBALL, OUTONLY, 0, 0),
    'SAVE' : (COMSAVE, OUTONLY, 0, 0),

    # Команды работы с данными
    'SET' : (COMSET, OUTONLY, 2, -1),
    'GET' : (COMGET, OUTONLY, 1, 1),
    'DEL' : (COMDEL, OUTONLY, 1, -1),
    'LEN' : (COMLEN, OUTONLY, 1, 1),
    'VALUES' : (COMVALUES, OUTONLY, 1, 3),
    'DBCLEAR': (COMDBCLEAR, OUTONLY, 1, 1),
    'CURRENTDB' : (COMCURRENTDB, OUTONLY, 0, 0),
    'EXISTS' : (COMEXISTS, OUTONLY, 1, -1),
    'APPEND' : (COMAPPEND, OUTONLY, 2, 3),
    'RENAME' : (COMRENAME, OUTONLY, 2, 2),
    'INCR' : (COMINCR, OUTONLY, 1, 2),
    'DECR' : (COMDECR, OUTONLY, 1, 2),
    'ADD' : (COMADD, OUTONLY, 2, 3),
    'SUB' : (COMSUB, OUTONLY, 2, 3),

    # Команды прослушивания
    'LISTEN' : (COMLISTEN, OUTONLY, 0, 0),
    'LISTENALL' : (COMLISTENALL, OUTONLY, 0, 0),
    'STOP' : (COMSTOP, OUTONLY, 0, 0),
    
    # Команды работы с языками
    'LANGS': (COMLANGS, OUTONLY, 0, 0),
    'SETLANG' : (COMSETLANG, OUTONLY, 1, 1),
    
    # Команды для разраничения прав
    'GETROLES' : (COMGETROLES, OUTONLY, 0, 0),
    'GETROLECOMMANDS' : (COMGETROLECOMMANDS, OUTONLY, 1, 1),
    'GETUSERROLE' : (COMGETUSERROLE, OUTONLY, 1, 1),
    'CHANGEROLE' : (COMCHANGEROLE, OUTONLY, 2, 2),
    'USERCOMMANDS' : (COMUSERCOMMANDS, OUTONLY, 1, 1),
    'CHANGEUSERCOMMANDS' : (COMCHANGEUSERCOMMANDS, OUTONLY, 1, -1),
    'GETUSERSDB' : (COMGETUSERSDB, OUTONLY, 0, 1),
    'ADDUSERTODB' : (COMADDUSERTODB, OUTONLY, 2, 2),
    'REMOVEUSERFROMDB' : (COMREMOVEUSERFROMDB, OUTONLY, 2, 2),
    'GETACCESSDB' : (COMGETACCESSDB, OUTONLY, 0, 1),
    'CHANGEACCESS' : (COMCHANGEACCESS, OUTONLY, 9, 9),

    # Информационные команды
    'COUNTCONNECTIONSDB' : (COMCOUNTCONNECTIONSSDB, OUTONLY, 0, 1),
    'COUNTVARS' : (COMCOUNTVARS, OUTONLY, 0, 0),
    'COUNTUSERS' : (COMCOUNTUSERS, OUTONLY, 0, 0),
    'COUNTCONNECTIONS' : (COMCOUNTCONNECTIONS, OUTONLY, 0, 0),
    'COUNTCOMMANDS' : (COMCOUNTCOMMANDS, OUTONLY, 0, 0),
    'COUNTLISTENERS' : (COMLISTENERS, OUTONLY, 0, 0),
    'COUNTLISTENERSDB' : (COMLISTENERSDB, OUTONLY, 0, 0),
    'COUNTVARSALL' : (COMCOUNTVARSALL, OUTONLY, 0, 0),
    'COUNTVARSALLDB' : (COMCOUNTVARSALLDB, OUTONLY, 0, 0),
    'GETCONNECTIONS' : (COMGETCONNECTIONS, OUTONLY, 0, 0),
    'LENVARIABLES' : (COMLENVARIABLES, OUTONLY, 0, 0),
    'LENVARIABLESALL' : (COMLENVARIABLESALL, OUTONLY, 0, 0),
    'DATE' : (COMDATE, OUTONLY, 0, 0),
    'TIME' : (COMTIME, OUTONLY, 0, 0),
    'INFO' : (COMINFO, OUTONLY, 0, 0),
    'GETSPACE' : (COMGETSPACE, OUTONLY, 0, 0),

    # Команды для управления сервером
    'SHUTDOWN' : (COMSHUTDOWN, DONOTHING, 0, 0),
    'RELOAD' : (COMRELOAD, DONOTHING, 0, 0),
    'GETSETTINGS': (COMGETSETTINGS, OUTONLY, 0, 0),
    'SETSETTINGS': (COMSETSETTINGS, OUTONLY, 0, 0),

    # Другие команды
    'ECHO' : (COMECHO, OUTONLY, 1, 1),
    'CLEAR' : (COMCLEAR, OUTONLY, 0, 0),
    'QUIT' : (COMQUIT, DONOTHING, 0, 0),
    'EVAL' : (COMEVAL, OUTONLY, 1, 1),
    'EXEC' : (COMEXEC, DONOTHING, 1, 1),
    'VISUAL' : (COMVISUAL, OUTONLY, 0, 0),
}