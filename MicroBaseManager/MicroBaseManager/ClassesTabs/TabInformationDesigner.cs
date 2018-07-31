using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager.ClassesTabs
{
    public partial class TabInformationDesigner : Template
    {
        InfoClass info = new InfoClass(0, 0, 0, 0, 0, 0, 0);
        public TabInformationDesigner()
        {
            InitializeComponent();
            Initialize();
        }
        public void Initialize()
        {
            Answer ans = Database.SendGetAnswer("INFO");
            if(ans.Info != Inf.OK)
            {
                PermissionDenied.Visible = true;
                PermissionDenied.Text = ans.Message;
                return;
            }
            PermissionDenied.Visible = false;
            TimerUpdate.Stop();
            CPUChart.Series[0].Points.Clear();
            RAMChart.Series[0].Points.Clear();
            QueryChart.Series[0].Points.Clear();
            if (MainForm.ServerInformation.Count != 0)
            {
                info = MainForm.ServerInformation.Last();
                RAMChart.ChartAreas[0].AxisY.Maximum = info.TotalMemory;
                TimeStart.Text = DateTime.Now.AddSeconds(-info.UpTime).ToString("yyyy/MM/dd hh:mm:ss");
            }
            TimerUpdate.Start();
            foreach (InfoClass inf in MainForm.ServerInformation)
            {
                AddToCharts(inf);
                if (inf.TotalMemory > RAMChart.ChartAreas[0].AxisY.Maximum)
                    RAMChart.ChartAreas[0].AxisY.Maximum = inf.TotalMemory;
            }
        }
        public void AddToCharts(InfoClass info)
        {
            CPULabel.Text = String.Format("{0}%", info.CPU);
            OZUAllLabel.Text = String.Format("{0} МБ", info.TotalMemory);
            OZULabel.Text = String.Format("{0} МБ", info.UsedMemory);
            OZUFreeLabel.Text = String.Format("{0} МБ", info.TotalMemory - info.UsedMemory);
            QuerySec.Text = String.Format("{0}", info.QuerySec);
            QueryMin.Text = String.Format("{0}", info.QueryMin);
            QueryStart.Text = String.Format("{0}", info.QueryTotal);
            TimeWork.Text = String.Format("{0}", TimeSpan.FromSeconds(info.UpTime));
            CPUChart.Series[0].Points.AddXY(info.time, info.CPU);
            RAMChart.Series[0].Points.AddXY(info.time, info.UsedMemory);
            QueryChart.Series[0].Points.AddXY(info.time, info.QuerySec);
        }
        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            if (MainForm.ServerInformation.Count == 0)
            {
                TimerUpdate.Stop();
                return;
            }

            AddToCharts(MainForm.ServerInformation.Last());
            
                
        }
    }
}
