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
    public partial class DBSettings : TabPage, UpdateDataInterface
    {
        public DBSettingsDesigner f;
        Panel p;
        private DataBaseWork DataBase;
        public DBSettings(string DataBase)
        {
            InitializeComponent();
            this.DataBase = new DataBaseWork(DataBase);
            f = new DBSettingsDesigner(this.DataBase);
            p = f.EditPanel;
            p.Top = 0;
            p.Left = 0;
            p.Height = this.Height;
            p.Width = this.Width;
            p.MaximumSize = new Size(0, 0);
            p.Size = this.Size;
            p.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            Controls.Add(p);
            
        }

        public void UpdateData()
        {

        }

        private void DBSettings_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
        }

    }
}
