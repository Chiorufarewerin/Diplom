# Поле, которое необходимо поменять, это хэш пароля администратора по умолчанию (пароль устанавливается только тут, этот администратор доступен всегда)
ADMINISTRATORPASSWORD = '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8' # хэш пароля администратора по умолчанию, используется sha256 (По умолчанию зашифрован: password)

# Остальные настройки меняются на ваше усмотрение
REGISTRATION = True # возможность регистрации пользователей

ADMINISTRATORNAME = 'Administrator' # логин для адмистратора по умолчанию
DEFAULTNAME = 'Guest' # логин для незарегистрированного пользователя

ADMINISTRATORROLE = 'Administrator' # роль для администратора по умолчанию (в файле access.py)
REGISTRATIONROLE = 'User' # установить роль по умолчанию для зарегистрированного пользователя (в файле access.py)
DEFAULTROLE = 'Guest' # роль незарегистрированного пользователя (в файле access.py)

MAXIMUMCREATEDATABASE = 2 # максимальное возможное число создания баз данных для зарегистрированных пользователей

DEFAULTLANGUAGECLIENTS = 'EN' # язык по умолчанию для подключаемых пользователей
DEFAULTLANGSERVER = 'EN' # язык по умолчанию для сервера, когда не удалось обнаружить язык системы в списке доступных языков или не был передан параметром

AUTOSAVETIME = 300.0 # интервал автосохранения баз данных

WRITELOGS = False # True - будет вестись логирование на сервере, иначе False

LOGSDIRECTORY = 'logs/' # директория, где будут хранится логи сервера
DATABASEDIRECTORY = 'databases/' # директория, где будут хранится базы данных
USERSDATABASEFILE = 'users/USERS.DAT' # файл, где будут храниться пользователи базы данных

# Поиск файла пользовательских настроек и их изменение
try:
    for var in open('config.cfg'):
        exec(var)
except:
    print('config.cfg not found... Will appled standart cfg in variables.py')

# Создание директорий
import os
dbpath = os.path.dirname(DATABASEDIRECTORY)
userpath = os.path.dirname(USERSDATABASEFILE)
logspath = os.path.dirname(LOGSDIRECTORY)
if not os.path.exists(dbpath):
    os.makedirs(dbpath)
if not os.path.exists(userpath):
    os.makedirs(userpath)
if WRITELOGS and not os.path.exists(logspath):
    os.makedirs(logspath)
