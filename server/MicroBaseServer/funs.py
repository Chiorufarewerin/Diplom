import hashlib
import database
import sendinfo
import language
import classes
import variables

# Некоторые вспомогательные функции

# Функция получает все аргументы из посланной пользователем строки
# Пример: 'HELP 123  321 "Hello world!" ' -> ['HELP', '123', '321', 'Hello world!']
def GetArguments(arg:str):
    if arg.count('"') % 2 != 0:
        raise Exception('NotCorrectNumberQuotes')
    temp = ''
    arguments = []
    inQuot = False
    for symb in arg:
        if symb == '"':
            inQuot = not inQuot
        elif symb != ' ' or inQuot:
            temp += symb
        elif symb == ' ' and temp != '':
            arguments.append(temp)
            temp = ''
    arguments.append(temp)

    return arguments

# Функция дает возможность получить ответ "Да" или "Нет"
def GetAnswer():
    while True:
        answer = input('[Y/n] ->').upper()
        if answer == 'Y' or answer == 'N':
            break
        print(language.SERVERLANG.WrongAnswer)
    return answer == 'Y'

# Функция для полного отключения сервера
def CloseTheProgramm(message='', Reload=False):
    database.CLOSE = True
    database.ISRELOADING = Reload
    try:
        database.AUTOSAVETIMER.cancel()
        try:
            sendinfo.SendToAllClients('ServerShutdown', [message])
        except:
            pass
        for client in database.ALLCLIENTS:
            try:
                client.socket.close()
            except:
                pass
        try:
            database.MAINSERVERSOCKET.close()
        except:
            pass
        database.SaveALL()
    except Exception as ex:
        print(str(ex))
        pass

# Функция для проверки валидности переменной
def CheckCorrectNameVariable(variable:str):
    return variable.isidentifier()

# Функция для проверки возможности выполнения команды в базе данных
def CheckCommandDataBase(ClientInfo:classes.ClientInformation, command:str, Database=None):
    if ClientInfo.CurrentUser.UserRole == variables.ADMINISTRATORROLE:
        return True
    if Database == None:
        Database = ClientInfo.DataBase.name
    if Database not in ClientInfo.CurrentUser.DataBases:
        return False
    Access = ClientInfo.CurrentUser.DataBases[Database]
    if Access.Main:
        return True
    if command in ('USE', ):
        return Access.Access
    if command in ('DBDEL', 'ADDUSERTODB', 'REMOVEUSERFROMDB', 'CHANGEACCESS'):
        return Access.Main
    if command in ('GET', 'LEN', 'VALUES', 'COUNTVARS', 'COUNTVARSALLDB', 'LENVARIABLES', 'EXISTS', ):
        return Access.Read
    if command in ('SET', 'APPEND', 'RENAME', 'INCR', 'DECR', 'ADD', 'SUB', ):
        return Access.Write
    if command in ('DEL', 'DBCLEAR', ):
        return Access.Delete
    if command in ('LISTEN', ):
        return Access.Listen
    if command in ('LISTENERSDB', 'GETUSERSDB'):
        return Access.Info
    return False

# Получить хэш строки
def EncryptString(HashString:str):
    ShaSignature = hashlib.sha256(HashString.encode()).hexdigest()
    return ShaSignature

# Перевод из str в bool
def StringToBool(String:str):
    String = String.lower()
    if String in ('true', 't', '1', 'y', 'yes'):
        return True
    if String in ('false', 'f', '0', 'n', 'no'):
        return False
    return None

def OutForVisual(Info:str, Data:str):
    return Info + '\r\n' + Data + '\r\n'