using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBaseManager
{
    public class User
    {
        public static User CurrentUser;
        public static void UpdateCurrentUser()
        {
            User user = new User();
            if (CurrentUser!= null && CurrentUser.Login == user.Login)
                user.Password = CurrentUser.Password;
            CurrentUser = user;
        }
        public static bool LoginToServer(string login, string password)
        {
            Answer answer = Database.SendGetAnswer(String.Format("LOGIN {0} {1}", login, password));
            if (answer.Info != Inf.OK)
            {
                answer.ShowMessage();
                return false;
            }
            User user = new User();
            user.Password = password;
            CurrentUser = user;
            return true;
        }

        public static bool RegisterUser(string login, string password)
        {
            Answer answer = Database.SendGetAnswer(String.Format("REGISTER {0} {1} {1}", login, password));
            if (answer.Info != Inf.OK)
            {
                answer.ShowMessage();
                return false;
            }
            return true;
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public string MaxCountCreateDB { get; private set; }
        public string[] UserCommands { get; private set; }
        public string[] OwnerDatabases { get; private set; }
        public Dictionary<string, DataBaseWork.Access> Databases { get; private set; }

        public User()
        {
            InitializationUser(Database.SendGetAnswer("GETMYINFO"));
        }

        public User(string login)
        {
            InitializationUser(Database.SendGetAnswer("GETUSERINFO " + login));
        }

        public User(string Login, string Password, string Role, string MaxCountCreateDB, string[] UserCommands, string[] OwnerDatabases, Dictionary<string, DataBaseWork.Access> Databases)
        {
            this.Login = Login;
            this.Password = Password;
            this.Role = Role;
            this.MaxCountCreateDB = MaxCountCreateDB;
            this.UserCommands = UserCommands;
            this.OwnerDatabases = OwnerDatabases;
            this.Databases = Databases;
        }

        private void InitializationUser(Answer Data)
        {
            AnswerData data = Data.GetSerializedData(new string[] { "D|: ", "L|, " });
            this.Login = data["Login"].ToString();
            this.Password = data["Password"].ToString();
            this.Role = data["Role"].ToString();
            this.MaxCountCreateDB = data["MaxCount"].ToString();
            this.UserCommands = data["UserComm"].Values;
            this.OwnerDatabases = data["OwnerDatabases"].Values;
            this.Databases = new Dictionary<string,DataBaseWork.Access>();
            data = Database.SendGetAnswer("GETACCESSDB "+ Login).GetSerializedData(new string[] { "D|: ", "L|, " });
            foreach(string str in data.GetEnumerable())
            {
                this.Databases[str] = new DataBaseWork.Access(data[str].Values);
            }
        }
    }
}
