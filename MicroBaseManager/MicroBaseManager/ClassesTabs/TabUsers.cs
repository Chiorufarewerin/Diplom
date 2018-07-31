using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager.ClassesTabs
{
    public partial class TabUsers : TabPage, UpdateDataInterface
    {
        Panel p;
        TabUsersDesigner f;
        public TabUsers()
        {
            InitializeComponent();
            f = new TabUsersDesigner();
            p = f.EditPanel;
            p.Top = 0;
            p.Left = 0;
            p.Height = this.Height;
            p.Width = this.Width;
            p.MaximumSize = new Size(0, 0);
            p.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            Controls.Add(p);
           


            this.Resize += TabUsers_Resize;
        }

        void TabUsers_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
            if (p.Controls.ContainsKey("UserInfoPanel"))
            {
                p.Controls["UserInfoPanel"].Height = f.MainPanel.Height;
                p.Controls["UserInfoPanel"].Width = f.MainPanel.Width;
                p.Controls["UserInfoPanel"].Invalidate();
            }
        }

        public void UpdateData()
        {
            f.UpdateData();
        }
    }
}
