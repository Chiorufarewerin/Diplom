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
    public partial class DBSettingsDesigner : Template
    {
        private DataBaseWork DataBase;
        public DBSettingsDesigner(DataBaseWork DataBase)
        {
            this.DataBase = DataBase;
            InitializeComponent();
            UpdateData();
        }

        public void UpdateData()
        {
            DataBase.UpdateData();
            CountVariablesLabel.Text = DataBase.CountVariables.ToString();
            CountListenersLabel.Text = DataBase.CountListeners.ToString();
            CountConnectionsLabel.Text = DataBase.CountConnections.ToString();
            UsersDBGridView.Rows.Clear();
            foreach (var value in DataBase.Users)
            {
                UsersDBGridView.Rows.Add(new object[] { value.Key, value.Value });
            }
        }
    }
}
