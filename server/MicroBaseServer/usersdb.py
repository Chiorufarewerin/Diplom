from os.path import isfile
import pickle
import classes
import access
import variables
import language
import funs

# Работа с пользователями

ADMINISTRATOR = classes.User(variables.ADMINISTRATORNAME, variables.ADMINISTRATORPASSWORD, variables.ADMINISTRATORROLE, -1) # администратор по умолчанию

DEFAULTUSER = classes.User(variables.DEFAULTNAME, '', variables.DEFAULTROLE, 0) # пользователь по умолчанию для незарегистрированных пользователей
DEFAULTUSER.DataBases['GLOBAL'] = classes.AccessDataBase(True, False, True, False, False, True, False) # ему доступна по умолчанию база данных GLOBAL с возможностью чтения данных (добавляется для всех пользователей)

USERS = dict() # Переменная для хранения пользователей

# Инициализация базы данных
def InitializeUsers():
    global USERS
    if isfile(variables.USERSDATABASEFILE):
        try:
            with open(variables.USERSDATABASEFILE, 'rb') as f:
                USERS = pickle.load(f)
        except: # если база данных повреждена, спрашивается возможность пересоздать ее
            print(language.SERVERLANG.CantOpenDatabaseUsers.format(variables.USERSDATABASEFILE)) 
            print(language.SERVERLANG.DatabaseUsersCorrupt)
            if funs.GetAnswer():
                with open(variables.USERSDATABASEFILE, 'wb') as f:
                    pickle.dump(dict(), f)
            else:
                funs.CloseTheProgramm()
    else:
        with open(variables.USERSDATABASEFILE, 'wb') as f:
            pickle.dump(dict(), f)
    if variables.ADMINISTRATORNAME in USERS:
        USERS[variables.ADMINISTRATORNAME].password = ADMINISTRATOR.password
        USERS[variables.ADMINISTRATORNAME].UserRole = ADMINISTRATOR.UserRole
        USERS[variables.ADMINISTRATORNAME].MaxCountCreateDataBases = ADMINISTRATOR.MaxCountCreateDataBases
    else:
        USERS[variables.ADMINISTRATORNAME] = ADMINISTRATOR
    if variables.DEFAULTNAME in USERS:
        USERS[variables.DEFAULTNAME].password = DEFAULTUSER.password
        USERS[variables.DEFAULTNAME].UserRole = DEFAULTUSER.UserRole
        USERS[variables.DEFAULTNAME].MaxCountCreateDataBases = DEFAULTUSER.MaxCountCreateDataBases
        USERS[variables.DEFAULTNAME].DataBases['GLOBAL'] = DEFAULTUSER.DataBases['GLOBAL']
    else:
        USERS[variables.DEFAULTNAME] = DEFAULTUSER
    for user in USERS.values():
        if 'GLOBAL' not in user.DataBases:
            user.DataBases['GLOBAL'] = classes.AccessDataBase(True, False, True, False, False, True, False)

# Сохранить базу данных
def SaveUsers():
    try:
        with open(variables.USERSDATABASEFILE, 'wb') as f:
            pickle.dump(USERS, f)
    except:
        print(language.SERVERLANG.CantSaveDatabaseUsers.format(variables.USERSDATABASEFILE))

# Создать пользователя
def CreateUser(RegUser:classes.User):
    if not funs.CheckCorrectNameVariable(RegUser.login):
        return 'NotCorrectLoginUser'
    if RegUser.login.lower() in (u.lower() for u in USERS):
        return 'UserIsExists'
    if 'GLOBAL' not in RegUser.DataBases:
        RegUser.DataBases['GLOBAL'] = classes.AccessDataBase(True, False, True, False, False, True, False)
    USERS[RegUser.login] = RegUser
    SaveUsers()
    return 'RegistrationCompleted'

# Удалить пользователя
def DeleteUser(DelUserLogin:str):
    if DelUserLogin not in USERS:
        return 'UserIsNotExists'
    if DelUserLogin in (ADMINISTRATOR.login, DEFAULTUSER.login):
        return 'ThisUserCannotChange'
    del USERS[DelUserLogin]
    SaveUsers()
    return 'UserDeleted'

# Изменить пароль
def ChangePassword(UsedUser:classes.User, NewPassword:str):
    if UsedUser not in USERS:
        return 'UserIsNotExists'
    if UsedUser in (ADMINISTRATOR, DEFAULTUSER):
        return 'ThisUserCannotChange'
    UsedUser.password = NewPassword
    return 'PasswordChanged'

# При удалении базы данных, ее связь удаляется у всех пользователей
def RemoveFromUsersDatabase(Database:str):
    for User in USERS:
        if Database in User.DataBases:
            del User.DataBases[Database]
        if Database in User.OwnerDataBases:
            User.OwnerDataBases.remove(Database)
    
    