# Команды по умолчанию для разных групп пользователей
# Эти команды по умолчанию имеют все пользователи с конкретной ролью (За исключением администратора, тут команды указаны для ознакомления)
# Исключить команду из этого списка у пользователя с какой-то ролью невозможно
# Возможно только добавить ту команду, которая не присутствует у него в роли
# Команды у ролей и роли можно менять, добавлять
ACCESSLEVEL = {
    'Administrator' : ('HELP', 'SET', 'GET', 'DEL', 'LEN', 'VALUES', 'CREATE', 'USE', 
                       'DBDEL', 'DBCLEAR', 'DBALL', 'SAVE', 'CURRENTDB', 'COUNTUSERS', 
                       'COUNTVARS', 'COUNTVARSALL', 'COUNTVARSALLDB', 'LENVARIABLES', 'LENVARIABLESALL', 
                       'EXISTS', 'APPEND', 'RENAME', 'SYMBOLS', 'ECHO', 'CLEAR', 'LISTEN', 'LISTENALL', 
                       'STOP', 'LISTENERSDB', 'LISTENERS', 'QUIT', 'COUNTCOMMANDS', 'INCR', 'DECR', 
                       'ADD', 'SUB', 'LS', 'SHUTDOWN', 'EVAL', 'EXEC', 'LANGS', 'SETLANG', 'ABOUT',
                       'LSALL', 'DBHELP', 'VARHELP', 'LISTENINGHELP', 'ADMINHELP', 'REGISTER', 'LOGIN',
                       'DELUSER', 'CHANGEPASSWORD', 'USERCOMMANDS', 'GETUSERINFO', 'CHANGEUSERCOMMANDS',
                       'USERS', 'ADDUSERTODB', 'REMOVEUSERFROMDB', 'CHANGEACCESS', 'CHANGEROLE', 'VISUAL',
                       'ME', 'GETCONNECTIONS', 'COUNTCONNECTIONS', 'DATE', 'TIME', 'GETROLES', 'GETROLECOMMANDS',
                       'GETUSERSDB', 'GETMYINFO', 'GETACCESSDB', 'GETSTANDARTUSERS', 'RELOAD', 'INFO', 'CHANGEUSER',
                       'GETSPACE', 'GETUSERROLE', 'OTHERHELP', 'GETSETTINGS', 'SETSETTINGS', 'COUNTCONNECTIONSDB',

                       ),

    'User' :          ('HELP', 'SET', 'GET', 'DEL', 'LEN', 'VALUES', 'USE', 'CREATE', 'DBDEL', 'DBCLEAR', 
                       'DBALL', 'CURRENTDB', 'COUNTUSERSDB', 'COUNTVARS', 'COUNTVARS', 'VISUAL', 'ME', 
                       'LENVARIABLES', 'EXISTS', 'APPEND', 'RENAME', 'SYMBOLS', 'ECHO', 'CLEAR', 'LISTEN', 'STOP', 
                       'LISTENERSDB', 'QUIT', 'INCR', 'DECR', 'ADD', 'SUB', 'LS', 'LANGS', 'SETLANG',
                       'ABOUT', 'DBHELP', 'VARHELP', 'LISTENINGHELP', 'ADMINHELP', 'REGISTER', 'LOGIN', 'CHANGEPASSWORD',
                       'ADDUSERTODB', 'REMOVEUSERFROMDB', 'CHANGEACCESS', 'DATE', 'TIME', 'GETUSERSDB', 'GETMYINFO',
                       'GETACCESSDB', 'COUNTCONNECTIONSDB'
                       ),
                       
    'Guest' :         ('HELP', 'GET', 'LEN', 'VALUES', 'USE', 'DBALL', 'CURRENTDB', 'COUNTUSERSDB', 'COUNTVARS', 
                       'LENVARIABLES', 'EXISTS', 'SYMBOLS', 'ECHO', 'CLEAR', 'LISTEN', 'STOP', 'LISTENERSDB',
                       'QUIT', 'LS', 'LANGS', 'SETLANG', 'ABOUT', 'DBHELP', 'VARHELP', 'LISTENINGHELP', 'ADMINHELP',
                       'REGISTER', 'LOGIN', 'VISUAL', 'ME', 'DATE', 'TIME', 'GETUSERSDB', 'GETMYINFO', 
                       'GETACCESSDB', 'COUNTCONNECTIONSDB'
                       )
}