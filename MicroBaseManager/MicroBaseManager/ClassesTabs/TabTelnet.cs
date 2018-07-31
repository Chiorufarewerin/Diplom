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
    public partial class TabTelnet : TabPage, UpdateDataInterface
    {
        public TabTelnetDesigner f;
        Panel p;
        public TabTelnet()
        {
            InitializeComponent();
            f = new TabTelnetDesigner();
            p = f.EditPanel;
            p.Top = 0;
            p.Left = 0;
            p.Height = this.Height;
            p.Width = this.Width;
            p.MaximumSize = new Size(0, 0);
            p.Size = this.Size;
            p.Anchor = ( AnchorStyles.Left | AnchorStyles.Top);
            Controls.Add(p);
        }

        public void UpdateData()
        {
            //f.InitializeTelnet();
        }

        public void RemoveData()
        {
            f.CloseSocket();
        }

        private void TabTelnet_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
        }
    }
}
