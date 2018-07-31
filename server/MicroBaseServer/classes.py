# Основные классы программы

# Класс для хранения языков
class Language:
    def __getitem__(self, name:str): # возможность получить значение путем обращения через квадратные скобки []
        return getattr(self, name)

# Класс для хранения информации о базе данных
class DataBase:
    def __init__(self, name:str, path:str, data:dict):
        self.name = name # имя БД
        self.path = path # путь базы данных
        self.data = data # хранилище БД

# Класс для хранения информации о доступе пользователя к базе данных
class AccessDataBase:
    def __init__(self, Access:bool, Main:bool, Read:bool, Write:bool, Delete:bool, Listen:bool, Info:bool):
        self.Access = Access # возможность входа - USE
        self.Main = Main # возможности администратора - DBDEL, ADDUSERTODB, REMOVEUSERFROMDB, CHANGEACCESS
        self.Read = Read # возможность получать данные в базе данных - GET, LEN, VALUES, COUNTVARS, COUNTVARSALLDB, LENVARIABLES, EXISTS, 
        self.Write = Write # возможность записывать и изменять данные в базе данных - SET, APPEND, RENAME, INCR, DECR, ADD, SUB
        self.Delete = Delete # возможность удалять данные в базе данных - DEL, DBCLEAR
        self.Listen = Listen # возможность прослушивания базы данных - LISTEN
        self.Info = Info # возможность получать дополнительную информацию в базе данных

# Класс для хранения информации о пользователе
class User:
    def __init__(self, login:str, password:str, UserRole:str, MaxCountCreateDataBases:int):
        self.login = login # логин
        self.password = password # хэш пароля
        self.UserRole = UserRole # роль пользователя
        self.MaxCountCreateDataBases = MaxCountCreateDataBases # Максимальное число создания своих баз данных (-1 - бесконечно)
        self.UserCommands = list() # команды, которыми может воспользоваться пользователь, кроме доступных ролью (Для администратора не имеет значения)
        self.DataBases = dict() # ключ - параметры базы данных для пользователя, значение - доступ пользователя
        self.OwnerDataBases = list() # список баз данных, созданных этим пользователем

# Класс для хранения информации о клиенте
class ClientInformation:
    def __init__(self, socket, addr:tuple, language:Language, DataBase:DataBase, CurrentUser:User):
        self.socket = socket # сокет
        self.addr = addr # информация о ip адресе и порту
        self.language = language # язык
        self.DataBase = DataBase # текущая база данных
        self.CurrentUser = CurrentUser # информация о пользователе
        self.Listen = False # прослушивание одной базы данных
        self.ListenAll = False # прослушивание всех баз данных
        self.VisualClient = False # режим визуального клиента

