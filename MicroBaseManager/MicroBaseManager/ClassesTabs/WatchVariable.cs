using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MicroBaseManager.ClassesTabs
{
    public partial class WatchVariable : UserControl
    {
        DataBaseWork DataBase;
        string Variable;
        public WatchVariable(string variable, DataBaseWork DataBase)
        {
            this.Variable = variable;
            this.DataBase = DataBase;
            InitializeComponent();
            Updater.Start();
            VariableWatchBox.Text = String.Format("Переменная {0} из базы данных {1}", variable, DataBase.DataBaseName);
        }

        private void ForeColorSwitch_Click(object sender, EventArgs e)
        {
            if (ColorDialogBox.ShowDialog() != DialogResult.OK)
                return;
            ForeColorSwitch.BackColor = ColorDialogBox.Color;
            VariableChart.Series[0].Color = ColorDialogBox.Color;
        }

        private void BackColorSwitch_Click(object sender, EventArgs e)
        {
            if (ColorDialogBox.ShowDialog() != DialogResult.OK)
                return;
            BackColorSwitch.BackColor = ColorDialogBox.Color;
            VariableChart.ChartAreas[0].BackColor = ColorDialogBox.Color;
        }

        private void PeriodBox_ValueChanged(object sender, EventArgs e)
        {
            Updater.Interval = Convert.ToInt32(PeriodBox.Value);
        }

        private void Updater_Tick(object sender, EventArgs e)
        {
            DataBaseWork.Value value = DataBase.GetValue(Variable);
            float val = 0;
            try
            {
                val = Convert.ToSingle(value.Values[0], CultureInfo.InvariantCulture);
            }
            catch { }
            CurrentValueLabel.Text = val.ToString();
            VariableChart.Series[0].Points.AddXY(DateTime.Now, val);

        }

        private void StopWatch_Click(object sender, EventArgs e)
        {
            Updater.Stop();
            TabWatch.Watches.Remove(this);
            if (MainForm.Tabss.TabPages.ContainsKey("Слежение"))
            {
                ((UpdateDataInterface)(MainForm.Tabss.TabPages["Слежение"])).UpdateData();
            }
        }
    }
}
