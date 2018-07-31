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
    public partial class TabSettingsDesigner : Template
    {
        public TabSettingsDesigner()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Answer ans = Database.SendGetAnswer("GETSETTINGS");
            if (ans.Info != Inf.OK)
            {
                PermissionDenied.Visible = true;
                PermissionDenied.Text = ans.Message;
                PermissionDenied.Height = EditPanel.Height;
                PermissionDenied.Width = EditPanel.Width;
                return;
            }
            PermissionDenied.Visible = false;
        }

        private void RegistrationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RegistrationCheckBox.Checked)
                RegistrationCheckBox.Text = "Включена";
            else
                RegistrationCheckBox.Text = "Отключена";
        }

        private void LogsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LogsBox.Checked)
                LogsBox.Text = "Включен";
            else
                LogsBox.Text = "Отключен";
        }
    }
}
