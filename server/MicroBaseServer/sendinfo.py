import database
import classes

# Отправка данных прослушивающим пользователям

# Функция для отправки данных слушателям определенной базы данных - LISTEN
def SendToListeners(DataBase:classes.DataBase, info:str, args):
    for ClientInfo in database.ALLCLIENTS:
        if ClientInfo.ListenAll:
            text = (DataBase.name + ': ' + ClientInfo.language[info].format(*args)).encode()
            ClientInfo.socket.send(text)
            continue
        if ClientInfo.Listen and DataBase == ClientInfo.DataBase:
            text = ClientInfo.language[info].format(*args).encode()
            ClientInfo.socket.send(text)
            continue

# Функция для отправки данных слушателям всего - LISTENALL
def SendToAllListeners(info:str, args):
    for ClientInfo in database.ALLCLIENTS:
        if ClientInfo.ListenAll:
            text = ClientInfo.language[info].format(*args).encode()
            ClientInfo.socket.send(text)

# Функция для отправки сообщения всем подключенным пользователям
def SendToAllClients(info:str, args):
    for ClientInfo in database.ALLCLIENTS:
        text = ClientInfo.language[info].format(*args).encode()
        ClientInfo.socket.send(text)