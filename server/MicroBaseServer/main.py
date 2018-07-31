import sys
import os
import socket
import threading
import locale
import language
from language import LANGUAGE
import commands
from commands import COMMANDS, SPECSYMBOLS, COMQUIT, Inf, OUTONLY
import classes
import funs
import database
import usersdb
import variables
import access
import variables
import datetime
import time
from importlib import reload

# Главный файл

# Функция, создающая сокет и ставящая сервер на нужный ip и порт
def InitializationServer(port, ip):
    serv_sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM, proto=0)
    serv_sock.bind((ip, port))
    serv_sock.listen(0)
    serv_sock.settimeout(3)
    return serv_sock

# Функция для работы с подключенными клиентами
def WorkWithClient(client:socket.socket, addr:tuple):
    ClientInfo = classes.ClientInformation(client, addr, LANGUAGE[variables.DEFAULTLANGUAGECLIENTS], database.DATABASES['GLOBAL'], usersdb.DEFAULTUSER)
    try:
        client.send(ClientInfo.language.TypeHelp)
    except:
        return
    database.ALLCLIENTS.append(ClientInfo)
    while True:
        try:
            data = client.recv(1024)
            if data in (b'\xff\xf4\xff\xfd\x06', b'\xff\xed\xff\xfd\x06'): # в некоторых Telnet клиентах есть возможность отключиться от сервера при помощи CTRL+Z или CTRL+C, проверка нажатия этиъ комбинаций
                COMQUIT(ClientInfo)
        except:
            COMQUIT(ClientInfo)
            return           
        if not data:
            COMQUIT(ClientInfo)
            return
        try:
            udata = data.decode('utf_8')
        except:
            continue
        if udata == '\r\n':
            continue
        udata = udata.strip('\r\n ')

        timesec = int(time.time())
        if timesec in database.QUERYTIME:
            database.QUERYTIME[timesec] += 1
        else:
            database.QUERYTIME.clear()
            database.QUERYTIME[timesec] = 1
        if timesec//60 in database.QUERYTIMEMIN:
            database.QUERYTIMEMIN[timesec//60] += 1
        else:
            database.QUERYTIMEMIN.clear()
            database.QUERYTIMEMIN[timesec//60] = 1
        database.QUERYES += 1

        if any(symb in udata for symb in SPECSYMBOLS):
            client.send(OUTONLY(ClientInfo, Inf.Error, 'SPECSYMB', ClientInfo.language.NotSpecs)[0])
            continue
        try:
            arguments = funs.GetArguments(udata)
        except Exception as e:
            client.send(OUTONLY(ClientInfo, Inf.Error, 'NOTCORRECTNUMBERQUOTES', ClientInfo.language[e.args[0]])[0])
            continue
        command, *args = arguments
        command = command.upper()
        if command not in COMMANDS:
            client.send(OUTONLY(ClientInfo, Inf.Error, 'COMNOTFOUND' ,ClientInfo.language.CommandNotFound)[0])
            continue
        if command not in access.ACCESSLEVEL[ClientInfo.CurrentUser.UserRole] and command not in ClientInfo.CurrentUser.UserCommands and ClientInfo.CurrentUser.UserRole != variables.ADMINISTRATORROLE:
            client.send(OUTONLY(ClientInfo, Inf.PermissionDenied, '', ClientInfo.language.PermissionDenied)[0])
            continue
        try:
            minargs = COMMANDS[command][2]
            maxargs = COMMANDS[command][3]
            if len(args) < minargs or (len(args) > maxargs and maxargs != -1):
                client.send(OUTONLY(ClientInfo, Inf.Error, 'COUNTARGUMENTERROR', ClientInfo.language.NotCorrectNumberArguments)[0])
                continue
            information, Info = COMMANDS[command][1](ClientInfo, *COMMANDS[command][0](ClientInfo,*args))
            if information:
                client.send(information)
        except Exception as e:
            try:
                client.send((str(e) + '\r\n').encode())
                COMQUIT(ClientInfo)
            except:
                pass
        if variables.WRITELOGS:
            date = str(datetime.datetime.fromtimestamp(int(datetime.datetime.now().timestamp())))
            FILELOG.write('{}\t{}:{}-{}|{}\r\n'.format(date, *addr, ClientInfo.CurrentUser.login, command))
            if information:
                FILELOG.write('{}\t{}:{}-{}|{}\r\n'.format(date, *addr, ClientInfo.CurrentUser.login, Info))
                FILELOG.flush()

# Функция для начала работы сервера
def work(port, ip=''):
    usersdb.InitializeUsers()
    database.InitializeDatabase()
    if database.CLOSE:
        return
    try:
        database.MAINSERVERSOCKET = InitializationServer(port, ip)
    except Exception as ex:
        print(language.SERVERLANG.CantStartServer.format(ex))
        return
    print(language.SERVERLANG.ServerWorking.format('IP: {}, '.format(ip) if len(ip) > 0 else '','PORT: {}'.format(port)))
    print(language.SERVERLANG.WaitingForConnections)
    database.TIMESTART = int(time.time())
    try:
        while True: # подключение клиентов к серверу
            client = None
            try:
                client, addr = database.MAINSERVERSOCKET.accept()
                print(language.SERVERLANG.ClientConnected.format(*addr))
                thr = threading.Thread(target=WorkWithClient, args=(client,addr)) 
                thr.start()
            except socket.timeout:
                pass
            except Exception as ex:
                print(ex)
                if client:
                    client.close()
                if database.CLOSE:
                    return
    except KeyboardInterrupt:
        funs.CloseTheProgramm()
        return

# Функция, возвращающая переданные параментры пользователем
def GetParameters():
    def Translate(Text): # перевод справки на язык, установленный системой
        Text = Text.replace('usage:', language.SERVERLANG.TranslateUsage)
        Text = Text.replace('show this help message and exit', language.SERVERLANG.TranslateShowThis)
        Text = Text.replace('error:', language.SERVERLANG.TranslateError)
        Text = Text.replace('the following arguments are required:', language.SERVERLANG.TranslateRequired)
        Text = Text.replace('optional arguments', language.SERVERLANG.TranslateOptional)
        Text = Text.replace('unrecognized arguments', language.SERVERLANG.Translateunrecognized)
        Text = Text.replace('expected one argument', language.SERVERLANG.TranslateExpected)
        Text = Text.replace('argument', language.SERVERLANG.TranslateArgument)
        Text = Text.replace('invalid', language.SERVERLANG.TranslateInvalid)
        Text = Text.replace('value:', language.SERVERLANG.TranslateValue)
        return Text
    import gettext
    gettext.gettext = Translate
    import argparse
    parser = argparse.ArgumentParser()
    parser.add_argument('-port', help=language.SERVERLANG.ParserPort, default=23, type=int)
    parser.add_argument('-ip', help=language.SERVERLANG.ParserIP, default='127.0.0.1', type=str)
    parser.add_argument('-lang', help=language.SERVERLANG.ParserLang.format(', '.join(LANGUAGE.keys()))
                        , default=None)
    args = parser.parse_args()
    return {'port': args.port, 'ip': args.ip, 'lang': args.lang}

# Входная функция в программу
def main():
    # Если необходимо создавать логи, то создается файл для этого
    if variables.WRITELOGS:
        global FILELOG
        date = datetime.datetime.now().date()
        FILELOG = open('{}{}{}.txt'.format(variables.logspath, '/', date.isoformat()),'a+')
    message = None
    try: # проверка возможности установить языком программы - язык системы
        lang = locale.getdefaultlocale()[0][:2].upper()
        if lang in LANGUAGE:
            language.SERVERLANG = LANGUAGE[lang]
        else:
            message = language.SERVERLANG.LanguageNotFoundInTranslated
    except:
        message = language.SERVERLANG.LanguageNotFound

    args = GetParameters()
    if args['lang'] != None: # проверка возможности установить языком программы - язык, переданный в аргументе
        lang = args['lang'].upper()
        if lang not in LANGUAGE:
            print(language.SERVERLANG.LanguageUserNotFound)
            return
        else:
            language.SERVERLANG = LANGUAGE[lang]
            message = None
    if message != None:
        print(message)

    while database.ISRELOADING:
        if database.ISRELOADING:
            database.CLOSE = False
            reload(variables)
            reload(commands)
            reload(funs)
            reload(database)
            reload(usersdb)
        database.ISRELOADING = False
        work(args['port'], args['ip'])



if __name__ == '__main__':
    main()