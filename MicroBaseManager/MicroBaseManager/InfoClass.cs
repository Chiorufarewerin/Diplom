using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBaseManager
{
    public class InfoClass
    {
        public float UsedMemory;
        public float TotalMemory;
        public float CPU;
        public int QuerySec;
        public int QueryMin;
        public int QueryTotal;
        public int UpTime;
        public DateTime time;

        public InfoClass()
        {
            this.UsedMemory = 0;
            this.TotalMemory = 0;
            this.CPU = 0;
            this.QuerySec = 0;
            this.QueryMin = 0;
            this.QueryTotal = 0;
            this.UpTime = 0;
            this.time = DateTime.Now;
        }

        public InfoClass(float UsedMemory, float TotalMemory, float CPU, int QuerySec, int QueryMin, int QueryTotal, int Uptime)
        {
            this.UsedMemory = UsedMemory;
            this.TotalMemory = TotalMemory;
            this.CPU = CPU;
            this.QuerySec = QuerySec;
            this.QueryMin = QueryMin;
            this.QueryTotal = QueryTotal;
            this.UpTime = Uptime;
            this.time = DateTime.Now;
        }
    }
}
