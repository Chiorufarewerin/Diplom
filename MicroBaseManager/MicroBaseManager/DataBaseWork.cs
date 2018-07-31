using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBaseManager
{
    public class DataBaseWork
    {
        public class Access
        {
            public bool Access_ {get;private set;}
            public bool Main { get; private set; }
            public bool Read { get; private set; }
            public bool Write { get; private set; }
            public bool Delete { get; private set; }
            public bool Listen { get; private set; }
            public bool Info { get; private set; }

            public Access(bool Access, bool Main, bool Read, bool Write, bool Delete, bool Listen, bool Info) 
            {
                this.Access_ = Access;
                this.Main = Main;
                this.Read = Read;
                this.Write = Write;
                this.Delete = Delete;
                this.Listen = Listen;
                this.Info = Info;
            }

            public Access(string[] Accesses)
            {
                foreach (string str in Accesses)
                {
                    switch (str)
                    {
                        case "Access": Access_ = true; break;
                        case "Main": Main = true; break;
                        case "Read": Read = true; break;
                        case "Write": Write = true; break;
                        case "Delete": Delete = true; break;
                        case "Listen": Listen = true; break;
                        case "Info": Info = true; break;
                    }
                }
            }

            public IEnumerable<string> GetEnumerate()
            {
                if (this.Access_)
                    yield return "Access";
                if (this.Main)
                    yield return "Main";
                if (this.Read)
                    yield return "Read";
                if (this.Write)
                    yield return "Write";
                if (this.Delete)
                    yield return "Delete";
                if (this.Listen)
                    yield return "Listen";
                if (this.Info)
                    yield return "Info";
                yield break;
            }

            public string[] GetArray()
            {
                return GetEnumerate().ToArray();
            }

            public override string ToString()
            {
                return String.Join(", ", GetEnumerate());
            }
        }

        public class Value
        {
            public string Name;
            public List<String> Values;
            public Value(string Name, List<String> Values)
            {
                this.Name = Name;
                this.Values = Values;
            }
            public Value(string Name)
            {
                this.Name = Name;
            }
            public override string ToString()
            {
                return String.Join(", ", Values);
            }
        }

        public string DataBaseName {get; private set;}
        public List<Value> Variables { get; private set;}
        public int CountConnections { get; private set;}
        public int CountVariables { get; private set;}
        public int CountListeners { get; private set;}
        public Dictionary<String, Access> Users { get; private set;}

        public DataBaseWork(string Name)
        {
            this.DataBaseName = Name;
            Variables = new List<Value>();
            Users = new Dictionary<string, Access>();
        }

        public static DataBaseWork CreateDataBase(string Name)
        {
            return null;
        }

        public DataTable GetValues(string SortingType, string Format)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Переменная");
            table.Columns.Add("Значение");
            string otbor = String.Format("\"{0}{1}\"", Format, SortingType);
            Answer answer = Database.SendGetAnswer(String.Format("USE {0}", this.DataBaseName), String.Format("VALUES FULL {0}", otbor));
            if (answer.Info != Inf.OK)
            {
                answer.ShowMessage();
                return table;
            }
            Variables.Clear();
            AnswerData data = answer.GetSerializedData(new string[] { "D| = ", "L|, " });
            foreach (string val in data.GetEnumerable())
            {
                Value var = new Value(val, data[val].GetEnumerable().ToList());
                if (SortingType=="" && Format=="")
                    Variables.Add(var);
                table.Rows.Add(new object[] { val,  var});
            }
            return table;
        }

        public DataTable GetValues()
        {
            DataTable table = GetValues("", "");
            return table;
        }

        public Value GetValue(string variable)
        {
            return new Value(variable, Database.SendGetAnswer(String.Format("USE {0}", this.DataBaseName), "GET " + variable).GetSerializedData(new string[] { "V", "L|, " }).GetEnumerable().ToList());
        }

        public bool SetValue(Value Value) 
        { 
            return false; 
        }

        public int RemoveValues(Value[] Values)
        {
            return 0;
        }

        public int Exists(Value[] Values)
        {
            return 0;
        }

        public bool Rename(Value ValueFrom, Value ValueTo)
        {
            return false;
        }

        public bool RemoveDataBase()
        {
            return false;
        }

        public bool Clear()
        {
            return false;
        }

        public void UpdateData()
        {
            GetValues();
            CountVariables = Variables.Count;
            Answer answer = Database.SendGetAnswer("GETUSERSDB");
            AnswerData data = answer.GetSerializedData(new string[] { "D|:", "L|, " });
            foreach (string val in data.GetEnumerable())
            {
                Users.Add(val, new Access(data[val].Values));
            }
            try
            {
                answer = Database.SendGetAnswer("COUNTLISTENERSDB");
                CountListeners = Convert.ToInt32(answer.Message);
                answer = Database.SendGetAnswer("COUNTCONNECTIONSDB");
                CountConnections = Convert.ToInt32(answer.Message);
            }
            catch
            {
                CountListeners = 0;
                CountConnections = 0;
            }

        }

        public bool AddUser(string login)
        {
            return false;
        }

        public bool RemoveUser(string login)
        {
            return false;
        }

        public bool ChangeAccess(string login, Access access)
        {
            return false;
        }
    }
}
