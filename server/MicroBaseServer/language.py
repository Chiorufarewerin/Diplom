from classes import Language
import variables

# Языки

# Класс для английского языка, от него могут наследоваться остальные языки
class EnglishLanguage(Language):
    #
    # FOR SERVER
    #
    # main.py
    LanguageNotFoundInTranslated = 'The program does not support your language, it will use English'
    LanguageNotFound = 'The system language is not detected, by default the English will be used'
    LanguageUserNotFound = 'The program is not translated into the selected language'
    LauguageFound = 'The language was not entered, by default - English'
    ParserPort = 'Port (default: 23)'
    ParserIP = 'IP (default: 127.0.0.1)'
    ParserLang = 'Language (default: system language) - [{}]'
    TranslateUsage = 'usage:'
    TranslateShowThis = 'show this help message and exit'
    TranslateError = 'error:'
    TranslateArgument = 'argument'
    TranslateRequired = 'the following arguments are required:'
    TranslateOptional = 'optional arguments'
    Translateunrecognized = 'unrecognized arguments'
    TranslateExpected = 'expected one argument'
    TranslateInvalid = 'invalid'
    TranslateValue = 'value:'
    ServerWorking = 'Server starting on {}{}'
    WaitingForConnections = 'Waiting for connections...'
    ClientConnected = 'Client connected {}:{}'
    CantStartServer = 'Failed to start the server:\n{}'

    # database.py
    SaveDatabases = 'Saving databases...'
    SavedDatabases = 'Saved'
    CantOpenDatabase = 'Could not open database - {}.'
    DatabaseGlobalCorrupted = 'The GLOBAL database is corrupted and is the main one in the program, to recreate it? Undo will terminate the program ...'
    DatabaseCorrupted = 'Database {} is corrupted, recreate it?'
    DatabaseNotFoundInPath = 'Database {} not found, recreate it?'

    # commands.py
    ClientDisconnected = 'Client disconnected {}:{}'

    # funs.py
    WrongAnswer = 'Wrong answer entered. Try again...'

    # usersdb.py
    CantOpenDatabaseUsers = 'Could not open users database - {}.'
    DatabaseUsersCorrupt = 'The users database is corrupted and is the main one in the program, to recreate it? Undo will terminate the program ...'
    CantSaveDatabaseUsers = 'Could not save users database - {}.'

    #
    # FOR CLIENTS
    #
    # main.py
    TypeHelp = ('\033[0;36m' + 'Type HELP for help\r\n' + '\033[0;37m').encode()
    NotSpecs = 'You can not use special characters\r\n'
    CommandNotFound = 'Command not found\r\n'
    TypeStop = ('\033[0;36m' +'Type STOP to stop listening\r\n' + '\033[0;37m').encode()
    CurrentDatabase = ('\033[0;36m' +'Current database - {}\r\n' + '\033[0;37m')
    DatabaseNotFound = ('\033[0;31m' +'Database not found\r\n' + '\033[0;37m').encode()
    NotCorrectNumberArguments ='Wrong arguments or their number\r\n'
    PermissionDeniedEnc = ('\033[0;31m' +'Permission denied\r\n' + '\033[0;37m').encode()
    
    # funs.py
    NotCorrectNumberQuotes = ('\033[0;31m' + 'Invalid number of quotes\r\n' + '\033[0;37m').encode()
    ServerShutdown = 'Server shut down...\r\n{}\r\n'

    # database.py
    CreateBD = 'Created database - {}\r\n'
    BDExists = 'The database {} exists\r\n'
    BDDeleted = 'The database {} deleted\r\n'

    #usersdb.py
    NotCorrectLoginUser = 'Incorrect login\r\n'
    UserIsExists = 'User with this login is exists\r\n'
    UserIsNotExists = 'User with this login is not exists\r\n'
    RegistrationCompleted = 'Registration completed successfully\r\n'
    UserDeleted = 'User deleted\r\n'
    ThisUserCannotChange = 'This user can not change anything\r\n'
    PasswordChanged = 'Password changed\r\n'

    # commands.py
    PermissionDenied = 'Permission denied\r\n'
    OK = 'OK\r\n'
    NotFound = 'Not found\r\n'
    NULL = '<NULL>'
    Saved = 'Saved\r\n'
    NoValues = 'There are no values\r\n'
    NotCorrectNameOfVariable = 'Invalid variable name\r\n'
    NotCorrectNameOfDatabase = 'Invalid database name\r\n'
    BDNotExists = 'The database {} does not exist\r\n'
    BDCantDeleteCurrent = 'You can not delete the current database\r\n'
    BDCantDeleteWhereUsers = 'You can not delete a database on which there are users\r\n'
    BDCantDeleteMainBase = 'You can not delete the GLOBAL database\r\n'
    BDCleared = 'The database {} cleared\r\n'
    NotNumericWherePosition = 'A non-numeric value is entered where position\r\n'
    IndexOutOfRange = 'Index out of range\r\n'
    VariableNotFound = 'Variable {} not found\r\n'
    StartListening = 'Now you are listening {} \r\nWrite STOP to stop listening\r\n'
    StartListeningAll = 'Now you are listening all changes\r\nWrite STOP to stop listening\r\n'
    CantUseWhenListening = 'You can not change the database while listening\r\n'
    CurrentListening = 'You are already listening to this channel\r\n'
    StopListening = 'You no longer listen {}\r\n'
    YouAreNotListening = 'You are not listening anything\r\n'
    VariableNotNumber = 'The variable is not a number\r\n'
    ValueNotNumber = 'A non-numeric value is entered where the value\r\n'
    IncorrectLanguage = 'Language not found! Use the LANGS command to get the possible languages\r\n'
    ChooseLanguage = 'Your Language - English\r\n'
    NotCorrectArgument = 'Invalid argument entered\r\n'
    InvalidSortingMethod = 'Invalid sorting method. Possible a - ascending and d - descending\r\n'
    Listeners = 'Listeners of everything: {}\r\n{}Total listeners: {}\r\n'
    AboutProgram = '''MicroBase Server\r
Version 1.0\r
© Chiorufarewerin (Beltsov Artur), 2018\r\n'''
    MaximumOfDataBases = 'You can not create a database, because the maximum number of databases available to create you is reached - {0}\r\n'
    RegistrationIsNotAvaible = 'Registration is not avaible on server\r\n'
    PasswordsDoNotMatch = 'Passwords do not match\r\n'
    PasswordsDoNotMatchInDataBase = 'Passwords do not match\r\n'
    LoginSuccessful = 'Login succsessful\r\n'
    GetUserInfo = '''Login: {}\r
Password: {}\r
User role: {}\r
Max count databases for create: {}\r
User commands: {}\r
Databases: {}\r
Owner databases: {}\r\n'''
    RoleNotFound = 'Role not found\r\n'
    OneOfParametersIsNotBool = 'One of the parameters is not bool\r\n'
    UserNotAddedToDB = 'User not added to this database\r\n'
    UserAddedToDB = 'User added to this database\r\n'
    CannotUseOnYourself = 'You can not use on yourself\r\n'
    NA = 'n/a'
    LoginLength = 'Length of login could be equal or less then {} symbols\r\n'
    InfoCommand = 'Memory use: {}\r\nTotal memory: {}\r\nCPU use: {}\r\nQueryes for last second: {}\r\nQueryes for last minute: {}\r\nAll queryes: {}\r\nUptime: {}\r\n'


    ListenerSet = '{} = {}\r\n'
    ListenerDel = '{} - deleted\r\n'
    ListenerAppend = '{} added in {}, on position {}\r\n'
    ListenerRename = '{} renamed to {}\r\n'
    ListenerIncr = '{} incremented in position {} = {}\r\n'
    ListenerDecr = '{} decremented in position {} = {}\r\n'
    ListenerAdd = '{} added {} in position {} = {}\r\n'
    ListenerSub = '{} subtracked {} in position {} = {}\r\n'
    ListenerAllCreate = '{} - database created\r\n'
    ListenerAllDelete = '{} - database deleted\r\n'
    ListenerAllDatabasesSaved = 'The databases were saved\r\n'

    DefaultHelp = '''Help commands:\r
 HELP - Display this help\r
 DBHELP - Display database help\r
 VARHELP - Display help on data managment commands\r
 LISTENINGHELP - Display help on listening commands\r
 OTHERHELP - Display help on other commands\r
 SYMBOLS - Get information about additional characters\r
Basic commands:\r
 LOGIN <LOGIN> <PASSWORD> - login to account\r
 LOGOUT - Sign out\r
 REGISTER <LOGIN> <PASSWORD> <CONFIRM PASSWORD> - Registration (if avaible)\r
 LS - Show available commands\r
 ECHO - Output of the received value\r
 CLEAR - Output 50 empty lines\r
 QUIT - Close connection\r
 ABOUT - Show information about server\r
Switch language:\r
 LANGS - Possible languages\r
 SETLANG <LANG> - Select language\r
Additional information:\r
 <> - Required arguments\r
 [] - Optional arguments\r\n'''

    DBHelp = '''Working with databases:
 USE <DATABASE> - Use the database <DATABASE> (default: GLOBAL)\r
 CURRENTDB - Show the current database\r
 CREATE <DATABASE> - Create a database named <DATABASE>\r
 DBDEL <DATABASE> - Delete the database <DATABASE>
 DBALL - List of databases\r
 SAVE - Save all databases\r
 COUNTUSERSDB [DATABASE] - Get the number of connected users of the current database or <DATABASE>\r\n'''

    VarHelp = '''Working with variables:\r
 SET <VAR> <VALUE> [VALUE2] ... - Set the value(-s) <VALUE> to the variable <VAR>\r
 APPEND <VAR> <VALUE> [POS] - Add the value <VALUE> to the variable <VAR> in the position [POS] (default: at the end) and return the final length of the array. If the variable does not exist, creates a new\r
 GET <VAR> - Get the value of the variable <VAR>\r
 LEN <VAR> - Get count values in the variable <VAR>\r
 EXISTS <VAR> [VAR2] ... - Check for the existence of variables. Returns the number of exists variables\r
 DEL <VAR> [VAR2] ... - Delete the variables. Returns the number of deleted variables\r
 RENAME <VAR1> <VAR2> - Renames the variable <VAR1> on <VAR2>\r
 INCR <VAR> [POS] - Add 1 to the variable <VAR> in the position [POS] (default: [POS] = 0)\r
 DECR <VAR> [POS] - Decrease 1 from the variable <VAR> in the position [POS] (default: [POS] = 0)\r
 ADD <VAR> <VALUE> [POS] - Add <VALUE> to the variable <VAR> in the position [POS] (default: [POS] = 0)\r 
 SUB <VAR> <VALUE> [POS] - Decrease <VALUE> from the variable <VAR> in the position [POS] (default: [POS] = 0)
 VALUES <0|1> [FILTER] - Get a list of variables | Variables with values, [FILTER] - show filter values\r
                         In the filter, you can specify * - any number of characters and ? - any single character\r
                         Also, the sorting method is /a - ascending, /d - descending\r
                         Example: VALUES 1 VAL1??/a or you can specify just sorting VALUES 1 /d\r\n'''

    ListeningHelp = '''Listening:\r
 LISTEN - Start receiving all changes in the current database\r
 LISTENALL - Start receiving all changes from all databases\r
 STOP - Finish listening\r
 LISTENERSDB - Get listeners in currend database\r
 LISTENERS - Get listeners\r\n'''

    OtherHelp = '''Other:
 EVAL - Execute python script\r
 EXEC - Execute OS script\r
 SHUTDOWN - Shut down the server\r
 LSALL - Get all commands\r
 COUNTCOMMANDS - Total number of commands\r
 COUNTUSERS - Get the number of connected users\r
 COUNTVARS - Get count vars in current database\r
 COUNTVARSALL - Get all of count vars everywhere\r
 COUNTVARSALLDB - Get all of count vars with databases\r
 LENVARIABLES - Get count of values in variables in current database\r
 LENVARIABLESALL - Get all of count values in variables everywhere\r\n'''

    HelpForCommands = '''System commands:\r
 HELP - Display this help\r
 SYMBOLS - Get information about additional characters\r
 COUNTUSERS - Get the number of connected users\r
 ECHO - Output of the received value\r
 CLEAR - Output 50 empty lines\r
 QUIT - Close connection\r
 COUNTCOMMANDS - Total number of commands\r
 LS - List of possible commands\r
 EVAL - Execute python script\r
 EXEC - Execute OS script\r
 SHUTDOWN - Shut down the server\r
Working with databases:\r
 CREATE <DATABASE> - Create a database named <DATABASE>\r
 USE <DATABASE> - Use the database <DATABASE> (default: GLOBAL)\r
 DBDEL <DATABASE> - Delete the database <DATABASE>\r
 DBCLEAR <DATABASE> - Clear the database <DATABASE>\r
 DBALL - List of databases\r
 SAVE - Save all databases\r
 CURRENTDB - Show the current database\r
 COUNTUSERSDB [<DATABASE>] - Get the number of connected users of the current database or <DATABASE>\r
Working with variables:\r
 SET <VAR> <VALUE> [VALUE2] ... - Set the value(-s) <VALUE> to the variable <VAR>\r
 APPEND <VAR> <VALUE> [POS] - Add the value <VALUE> to the variable <VAR> in the position [POS] (default: at the end) and return the final length of the array. If the variable does not exist, creates a new\r
 GET <VAR> - Get the value of the variable <VAR>\r
 LEN <VAR> - Get count values in the variable <VAR>\r
 VALUES <0|1> [FILTER] - Get a list of variables | Variables with values, [FILTER] - show filter values\r
                         In the filter, you can specify * - any number of characters and ? - any single character\r
                         Also, the sorting method is /a - ascending, /d - descending\r
                         Example: VALUES 1 VAL1??/a or you can specify just sorting VALUES 1 /d\r
 COUNTVARS - Get count vars in current database\r
 COUNTVARSALL - Get all of count vars everywhere\r
 COUNTVARSALLDB - Get all of count vars with databases\r
 LENVARIABLES - Get count of values in variables in current database\r
 LENVARIABLESALL - Get all of count values in variables everywhere\r
 EXISTS <VAR> [VAR2] ... - Check for the existence of variables. Returns the number of exists variables\r
 DEL <VAR> [VAR2] ... - Delete the variables. Returns the number of deleted variables\r
 RENAME <VAR1> <VAR2> - Renames the variable <VAR1> on <VAR2>\r
 INCR <VAR> [POS] - Add 1 to the variable <VAR> in the position [POS] (default: [POS] = 0)\r
 DECR <VAR> [POS] - Decrease 1 from the variable <VAR> in the position [POS] (default: [POS] = 0)\r
 ADD <VAR> <VALUE> [POS] - Add <VALUE> to the variable <VAR> in the position [POS] (default: [POS] = 0)\r 
 SUB <VAR> <VALUE> [POS] - Decrease <VALUE> from the variable <VAR> in the position [POS] (default: [POS] = 0)\r
Listening:\r
 LISTEN - Start receiving all changes in the current database\r
 LISTENALL - Start receiving all changes from all databases\r
 STOP - Finish listening\r
 LISTENERSDB - Get listeners in currend database\r
 LISTENERS - Get listeners\r
Switch language:\r
 LANGS - Possible languages\r
 EN - English\r
 RU - Russian\r
Additional information:\r
 <> - Required arguments\r
 [] - Optional arguments\r\n'''

    HelpSpecSymbols = '''Character information:\r
{} - Characters that can not be used in commands\r
" - Used to join a line in which there is a space, example: SET VAR "Hello World!" - in the variable VAR will be the value Hello World!\r\n'''





# Класс для русского языка
class RussianLanguage(EnglishLanguage):
    #
    # FOR SERVER
    #
    # main.py
    LanguageNotFoundInTranslated = 'Программа не имеет поддержки вашего языка, будет использован русский язык'
    LanguageNotFound = 'Язык системы не обнаружен, по умолчанию будет использоваться русский язык'
    LanguageUserNotFound = 'На выбранный язык программа не переведена'
    LauguageFound = 'Язык не был указан, по умолчанию - русский'
    ParserPort = 'Порт (по умолчанию: 23)'
    ParserIP = 'IP (по умолчанию: 127.0.0.1)'
    ParserLang = 'Язык (по умолчанию: язык системы) - [{}]'
    TranslateUsage = 'Использование:'
    TranslateShowThis = 'Показать помощь и выйти'
    TranslateError = 'ошибка:'
    TranslateArgument = 'аргумент'
    TranslateRequired = 'Обязательные аргументы:'
    TranslateOptional = 'Необязательные аргументы'
    Translateunrecognized = 'неверные аргументы'
    TranslateExpected = 'ожидается один аргумент'
    TranslateInvalid = 'неправильное'
    TranslateValue = 'значение:'
    ServerWorking = 'Сервер заработал на {}{}'
    WaitingForConnections = 'Ожидание соединений...'
    ClientConnected = 'Клиент подключился {}:{}'
    CantStartServer = 'Не удалось запустить сервер:\n{}'

    # database.py
    SaveDatabases = 'Сохранение баз данных...'
    SavedDatabases = 'Сохранено'
    CantOpenDatabase = 'Не удалось открыть БД - {}.'
    DatabaseGlobalCorrupted = 'База данных GLOBAL повреждена и является главной в программе, пересоздать ее? Отмена приведет к завершению программы...'
    DatabaseCorrupted = 'База данных {} повреждена, пересоздать ее?'

    # commands.py
    ClientDisconnected = 'Клиент отключился {}:{}'

    # funs.py
    WrongAnswer = 'Введен неверный ответ. Повторите попытку...'

    # usersdb.py
    CantOpenDatabaseUsers = 'Невозможно открыть пользовательскую базу данных - {}.'
    DatabaseUsersCorrupt = 'База данных пользователей повреждена и является главной в программе, пересоздать ее? Отмена приведет к завершению программы...'
    CantSaveDatabaseUsers = 'Невозможно сохранить пользовательскую базу данных - {}.'

    #
    # FOR CLIENTS
    #
    # main.py
    TypeHelp = ('\033[0;36m' + 'Напишите HELP для помощи\r\n' + '\033[0;37m').encode()
    NotSpecs = 'Нельзя использовать спец. символы\r\n'
    CommandNotFound = 'Команда не найдена\r\n'
    TypeStop = ('\033[0;36m' +'Напишите STOP для остановки прослушки\r\n' + '\033[0;37m').encode()
    CurrentDatabase = ('\033[0;36m' +'Текуща БД - {}\r\n' + '\033[0;37m')
    DatabaseNotFound = ('\033[0;31m' +'База данных не найдена\r\n' + '\033[0;37m').encode()
    NotCorrectNumberArguments ='Неверные аргументы\r\n'
    PermissionDeniedEnc = ('\033[0;31m' +'Доступ запрещен\r\n' + '\033[0;37m').encode()
    PermissionDenied = 'Доступ запрещен\r\n'
    
    # funs.py
    NotCorrectNumberQuotes = 'Нечетное количество кавычек\r\n'.encode()
    ServerShutdown = 'Сервер завершил свою работу...\r\n{}\r\n'

    # database.py
    CreateBD = 'Создана БД - {}\r\n'
    BDExists = 'База данных {} существует\r\n'
    BDDeleted = 'БД {} удалена\r\n'
    DatabaseNotFoundInPath = 'База данных {} была удалена, пересоздать её?'

    #usersdb.py
    NotCorrectLoginUser = 'Неправильное имя пользователя\r\n'
    UserIsExists = 'Пользователь с таким именем уже существует\r\n'
    UserIsNotExists = 'Пользователь с таким именем не существует\r\n'
    RegistrationCompleted = 'Регистрация успешно завершена\r\n'
    UserDeleted = 'Пользователь удален\r\n'

    # commands.py
    OK = '<OK>\r\n'
    NotFound = '<NOT FOUND>\r\n'
    NULL = '<NULL>'
    Saved = 'Сохранено\r\n'
    NoValues = 'Нет никаких значений\r\n'
    NotCorrectNameOfVariable = 'Неверное имя переменной\r\n'
    NotCorrectNameOfDatabase = 'Неверное имя базы данных\r\n'
    BDNotExists = 'База данных {} не существует\r\n'
    BDCantDeleteCurrent = 'Нельзя удалить текущую БД\r\n'
    BDCantDeleteWhereUsers = 'Нельзя удалить БД на которой есть пользователи\r\n'
    BDCantDeleteMainBase = 'Нельзя удалить базу данных GLOBAL\r\n'
    BDCleared = 'БД {} очищена\r\n'
    NotNumericWherePosition = 'Введено нечисловое значение, где позиция\r\n'
    IndexOutOfRange = 'Индекс выходит за пределы границы массива\r\n'
    VariableNotFound = 'Переменная {} не найдена\r\n'
    StartListening = 'Сейчас вы слушаете {}\r\nНапишите STOP для прекращения\r\n'
    StartListeningAll = 'Вы начинаете слушать все изменения\r\nНапишите STOP для прекращения\r\n'
    CantUseWhenListening = 'Нельзя менять базу данных во время прослушки\r\n'
    CurrentListening = 'Вы уже слушаете этот канал\r\n'
    StopListening = 'Вы больше не слушаете {}\r\n'
    YouAreNotListening = 'Вы ничего не слушаете\r\n'
    VariableNotNumber = 'Переменная не является числом\r\n'
    ValueNotNumber = 'Введено нечисловое значение, где значение\r\n'
    IncorrectLanguage = 'Язык не найден! Используйте команду LANGS для получения возможных языков\r\n'
    ChooseLanguage = 'Ваш язык - Русский\r\n'
    NotCorrectArgument = 'Введен неверный аргумент\r\n'
    InvalidSortingMethod = 'Неверный метод сортировки. Возмодны a - по возрастанию и d - по убыванию\r\n'
    Listeners = 'Слушатели всего: {}\r\n{}Итоговое количество: {}\r\n'
    AboutProgram = '''MicroBase Server\r
Версия 1.0\r
© Chiorufarewerin (Бельцов Артур), 2018\r\n'''
    MaximumOfDataBases = 'Вы не можете создать базу данных, так как достигнуто максимальное количество доступных для создания вам баз данных - {0}\r\n'
    LoginSuccessful = 'Вход успешен\r\n'
    


    ListenerSet = '{} = {}\r\n'
    ListenerDel = '{} - удален\r\n'
    ListenerAppend = '{} добавлен в {}, на позицию {}\r\n'
    ListenerRename = '{} переименована в {}\r\n'
    ListenerIncr = '{} инкрементировано в позиции {} = {}\r\n'
    ListenerDecr = '{} декрементировано в позиции {} = {}\r\n'
    ListenerAdd = '{} добавлено {} в позиции {} = {}\r\n'
    ListenerSub = '{} вычтено {} в позиции {} = {}\r\n'
    ListenerAllCreate = '{} - БД создана\r\n'
    ListenerAllDelete = '{} - БД удалена\r\n'
    ListenerAllDatabasesSaved = 'Произошло сохранение баз данных\r\n'

    DefaultHelp = '''Справка:\r
 HELP - Открыть справку\r
 DBHELP - Открыть справку по управлению базами данных\r
 VARHELP - Открыть справку по управлению данными\r
 LISTENINGHELP - Открыть справку по прослушиваниям\r
 OTHERHELP - Прочее\r
 SYMBOLS - Специальные символы, которые нельзя использовать\r
Базовые команды:\r
 LOGIN <LOGIN> <PASSWORD> - Вход в аккаунт\r
 LOGOUT - Выход\r
 REGISTER <LOGIN> <PASSWORD> <CONFIRM PASSWORD> - Регистрация (если включена)\r
 LS - Показать доступные команды\r
 ECHO - Вывести сообщние\r
 CLEAR - Очистить сообщения\r
 QUIT - Закрыть соединение\r
 ABOUT - Показать информацию о сервере\r
Языки:\r
 LANGS - Возможные языки\r
 SETLANG <LANG> - Сменить языкr
Additional information:\r
 <> - Обязательные аргументы\r
 [] - Необязательные аргументы\r\n'''

    HelpForCommands = '''Системные команды:\r
 HELP - Вызов справки\r
 SYMBOLS - Получить информацию о дополнительных символах\r
 COUNTUSERS - Получить количество подключенных пользователей\r
 ECHO - Вывод полученной строки\r
 CLEAR - Вывод 50 пустых строк\r
 QUIT - Закрыть соединение\r
 COUNTCOMMANDS - Общее количество команд\r
 LS - Список возможных команд\r
 EVAL - Выполнить команду python\r
 EXEC - Выполнить команду операционной системы\r
 SHUTDOWN - Завершить работу сервера\r
Работа с базами данных:\r
 CREATE <DATABASE> - Создать базу данных с именем <DATABASE>\r
 USE <DATABASE> - Использовать базу данных <DATABASE> (По умолчанию GLOBAL)\r
 DBDEL <DATABASE> - Удалить базу данных <DATABASE>\r
 DBCLEAR <DATABASE> - Очистить базу данных <DATABASE>\r
 DBALL - Список баз данных\r
 SAVE - Сохранить все БД в файлы\r
 CURRENTDB - Показать текущую базу данных\r
 COUNTUSERSDB [<DATABASE>] - Получить количество подключенных пользователей текущей БД или <DATABASE>\r
Работа с переменными:\r
 SET <VAR> <VALUE> [VALUE2] ... - Установить значение(-я) <VALUE> переменной <VAR>\r
 APPEND <VAR> <VALUE> [POS]- Добавить значение <VALUE> к переменной <VAR> в позицию [POS] (По умолчанию будет добавлен в конец) и возвратить конечную длинну массива. Если ключа не существует, создает новый\r
 GET <VAR> - Получить значение переменной <VAR>\r
 LEN <VAR> - Получить количество значений в переменной <VAR>\r
 VALUES <LIST|FULL> [FILTER] - Получить список переменных | Переменные со значениями, [FILTER] - показать значения по фильтру\r
                         В фильтре можно указать * - любое количество символов и ? - любой одиночный символ\r
                         Также указывается метод сортировки /a - по возрастанию, /d - по убыванию\r
                         Пример: VALUES 1 VAL1??/a или можно указать просто сортировку VALUES 1 /d\r
 COUNTVARS - Получить количество переменных в текущей БД\r
 COUNTVARSALL - Получить общее количество переменных во всех БД\r
 COUNTVARSALLDB - Получить все количества переменных с БД\r
 LENVARIABLES - Получить количество значений в переменных в текущей БД\r
 LENVARIABLESALL - Получить все количества значений в переменных во всех БД\r
 EXISTS <VAR> [VAR2] ... - Проверить на существование переменные. Возвращает количество существующих ключей\r
 DEL <VAR> [VAR2] ... - Удалить переменные. Возвращает количество удаленных переменных\r
 RENAME <VAR1> <VAR2> - Переименовывает переменную <VAR1> на <VAR2>\r
 INCR <VAR> [POS] - Прибавить 1 к переменной <VAR> в позиции [POS] (По умолчанию [POS] = 0)\r
 DECR <VAR> [POS] - Убавить 1 у переменной <VAR> в позиции [POS] (По умолчанию [POS] = 0)\r
 ADD <VAR> <VALUE> [POS] - Прибавить <VALUE> к переменной <VAR> в позиции [POS] (По yмолчанию [POS] = 0)\r 
 SUB <VAR> <VALUE> [POS] - Убавить <VALUE> у переменной <VAR> в позиции [POS] (По умолчанию [POS] = 0)\r
Прослушивание:\r
 LISTEN - Начать получать все изменения в текущей БД\r
 LISTENALL - Начать получать все изменения из всех баз данных\r
 STOP - Окончить прослушивание\r
 LISTENERSDB - Получить слушателей в текущей БД\r
 LISTENERS - Получить всех слушателей\r
Переключение языка:\r
 LANGS - Доступные языки\r
 EN - Английский\r
 RU - Русский\r
Дополнительная информация:\r
 <> - Обязательные аргументы\r
 [] - необязательные аргументы\r\n'''
    HelpSpecSymbols = '''Информация о символах:\r
{} - Символы, которые нельзя использовать в командах\r
" - Используется для объединения строки в которой есть пробел, пример: SET VAR "Hello World!" - в переменной VAR будет значение Hello World!\r\n'''

    
# Короткие имена для языков и создание объектов классов языков
LANGUAGE = {
    'EN': EnglishLanguage(),
    'RU': RussianLanguage()
}

SERVERLANG = LANGUAGE[variables.DEFAULTLANGSERVER] # установка языка для сервера