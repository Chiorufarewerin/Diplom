using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public enum Inf{
        OK,
        Error,
        PermissionDenied,
        Info,
        WrongAnswer
    }

    public class AnswerData
    {
        private object data;

        public AnswerData(object data) 
        {
            this.data = data;
        }

        public AnswerData this[object param]
        {
            get
            {
                if (data is Dictionary<string, AnswerData>)
                {
                    return ((Dictionary<string, AnswerData>)(data))[(string)param];
                }
                if (data is AnswerData[])
                {
                    return ((AnswerData[])(data))[(int)param];
                }
                if (data is string)
                {
                    return this;
                }
                return (AnswerData)data;
            }
        }

        public string This
        {
            get
            {
                return this.ToString();
            }
        }

        public string[] Values
        {
            get
            {
                return GetEnumerable().Select(x => x.ToString()).ToArray();
            }
        }

        public object GetData()
        {
            return data;
        }

        public IEnumerable<AnswerData> GetRow()
        {
            if (data is AnswerData)
                yield return (AnswerData)(data);
            else if (data is string)
                yield return this;
            else if (data is AnswerData[])
            {
                foreach (object val in ((AnswerData[])data))
                {
                    yield return (AnswerData)val;
                }

            }
            else if (data is Dictionary<string, AnswerData>)
            {
                foreach (object val in (((Dictionary<string, AnswerData>)data).Keys))
                {
                    yield return this;
                }

            }
            else
            {
                foreach (object val in ((IEnumerable)data))
                {
                    yield return this;
                }
            }
        }
        public IEnumerable<string> GetEnumerable()
        {
            if (data is AnswerData)
            {
                foreach (string d in ((AnswerData)data).GetEnumerable())
                {
                    yield return d;
                }
                yield break;
            }
            if (data is IEnumerable)
            {
                if (data is Dictionary<string, AnswerData>)
                {
                    foreach (object val in (((Dictionary<string, AnswerData>)data).Keys))
                    {
                        yield return val.ToString();
                    }

                }
                else
                {
                    foreach (object val in ((IEnumerable)data))
                    {
                        yield return val.ToString();
                    }
                }
            }
            yield break;
        }

        public override string ToString()
        {
            if (data is AnswerData[])
            {
                if (((AnswerData[])(data)).Length != 0)
                    return ((AnswerData[])(data))[0].ToString();
                return "";
            }
            if (data is Dictionary<string, AnswerData>)
                return ((Dictionary<string, AnswerData>)(data)).Keys.First();
            if (data is KeyValuePair<string, AnswerData>)
                return ((KeyValuePair<string, AnswerData>)(data)).Key;
            return data.ToString();
        }
    }

    public class Answer
    {
        private Inf information;
        private string[] data;

        public Answer(Inf information, string[] data)
        {
            this.information = information;
            this.data = data;
        }

        public Answer(string RawString)
        {
            if (RawString == "<DISCONNECTED>")
            {
                data = new string[] { RawString };
                this.information = Inf.Error;
                return;
            }
            string[] strings = RawString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            if (strings.Length < 2)
            {
                this.information = Inf.WrongAnswer;
                this.data = strings;
                return;
            }
            string ans = strings[0];
            switch (ans)
            {
                case "<OK>": this.information = Inf.OK; break;
                case "<ERROR>": this.information = Inf.Error; break;
                case "<PERMISSION DENIED>": this.information = Inf.PermissionDenied; break;
                case "<INFO>": this.information = Inf.Info; break;
            }
            this.data = strings.Skip(1).ToArray();
        }

        public Inf Info
        {
            get
            {
                if (information == Inf.Info)
                    return Inf.OK;
                return information;

            }
        }

        public string[] Data
        {
            get
            {
                return data;
            }
        }

        private AnswerData GetSerializedData(string data, string[] format=null)
        {
            if (format == null)
                return new AnswerData(data);
            string[] parser;
            if (format != null && format.Length > 0)
                parser = format[0].Split(new char[] { '|' });
            else
                parser = new string[] { "V" };

            if (format.Length == 1)
                format = null;

            if (parser[0] == "V")
            {
                return new AnswerData(GetSerializedData(data, format));
            }
            else if (parser[0] == "L")
            {
                 return new AnswerData(data.Split(new string[]{parser[1]}, StringSplitOptions.RemoveEmptyEntries).Select(x => GetSerializedData(x, format)).ToArray());
            }
            else if (parser[0] == "D")
            {
                /*    return new AnswerData(data.Select(delegate(string x)
                    {
                        string[] spl = x.Split(parser[1].ToCharArray());
                        return new { k = spl[0], v = GetSerializedData(spl[1].Split(parser[2].ToCharArray(), 2, StringSplitOptions.None), format) };
                    }).ToDictionary(x => x.k, x => x.v)); */
            }
            return null;
        }
        public AnswerData GetSerializedData(string[] format)
        {
            try
            {
                if (data.Length == 1 && data[0].Length == 0)
                    return new AnswerData("");
                string[] parser;
                if (format.Length > 0)
                {
                    parser = format[0].Split(new char[] { '|' });
                    format = format.Skip(1).ToArray();
                }
                else
                {
                    parser = new string[] { "V" };
                }

                if (parser[0] == "V")
                {
                    return new AnswerData(GetSerializedData(data[0], format));
                }
                else if (parser[0] == "L")
                {
                    return new AnswerData(data.Select(x => GetSerializedData(x, format)).ToArray());
                }
                else if (parser[0] == "D")
                {
                    
                    return new AnswerData(data.Select(delegate(string x)
                                            {
                                                string[] spl = x.Split(new string[] { parser[1] }, 2, StringSplitOptions.None);
                                                return new
                                                {
                                                    k = spl[0],
                                                    v = GetSerializedData(spl[1], format)
                                                };
                                            }).ToDictionary(x => x.k, x => x.v));
                }
            }catch(Exception ex)
            {
                return new AnswerData(ex.Message);
            }
            return new AnswerData("");
        }
        public string Message
        {
            get {
                if (information == Inf.OK || information == Inf.Info)
                    return data[0];
                if (information == Inf.PermissionDenied)
                    return Lang.PermissionDenied;
                if (information == Inf.Error)
                {
                    switch (data[0])
                    {
                        case "<DISCONNECTED>": return Lang.ConnectionOff;
                        case "COMNOTFOUND": return Lang.ComNotFoud;
                        case "USERNOTEXISTS": return "Пользователь не найден";
                        case "PASSWORDSDONOTMATCH": return "Пароли не совпадают";
                        case "USEREXISTS": return "Пользователь существует";
                        case "COUNTARGUMENTERROR": return "Неверное число аргументов";
                        case "SPECSYMB": return "Нельзя использовать спецсимволы";
                        default: return  data[0];
                    }
                }
                return Lang.InvalidQuery;
            }
        }

        internal void ShowMessage()
        {
            MessageBox.Show(this.Message, "");
        }
    }
}
