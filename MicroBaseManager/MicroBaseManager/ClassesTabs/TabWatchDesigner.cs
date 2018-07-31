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
    public partial class TabWatchDesigner : Template
    {
        public TabWatchDesigner()
        {
            InitializeComponent();
            
        }

        public void Load()
        {
            List<Control> ToRemove = new List<Control>();
            foreach (Control ctrl in EditPanel.Controls)
            {
                if (ctrl != WatchNotFound)
                    ToRemove.Add(ctrl);
            }
            foreach(Control ctrl in ToRemove)
            {
                EditPanel.Controls.Remove(ctrl);
            }
            WatchNotFound.Visible = true;
            for (int i = 0; i < TabWatch.Watches.Count; i++)
            {
                WatchNotFound.Visible = false;
                WatchVariable WatchCtrl = TabWatch.Watches[i];
                WatchCtrl.Left = 10;
                WatchCtrl.Top = i * WatchCtrl.Height + 10;
                EditPanel.Controls.Add(WatchCtrl);
            }
            EditPanel_Resize(null, null);
        }

        private void EditPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in EditPanel.Controls)
            {
                if (ctrl != WatchNotFound)
                    ctrl.Width = EditPanel.Width - 20;
            }
        }
    }
}
