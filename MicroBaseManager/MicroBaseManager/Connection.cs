using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBaseManager
{
    public class Connection
    {  
        private string name;
        private string connect;
        private int port;

        public Connection(string name, string connect, int port)
        {
            this.name = name;
            this.connect = connect;
            this.port = port;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetConnect()
        {
            return this.connect;
        }

        public int GetPort()
        {
            return this.port;
        }
    }
}
