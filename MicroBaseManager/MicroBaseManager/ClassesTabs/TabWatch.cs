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
    public partial class TabWatch : TabPage, UpdateDataInterface
    {
        public TabWatchDesigner f;
        Panel p;
        public static List<WatchVariable> Watches = new List<WatchVariable>();
        public TabWatch()
        {
            InitializeComponent();
            this.Resize += TabWatch_Resize;
            f = new TabWatchDesigner();
            p = f.EditPanel;
            p.Top = 0;
            p.Left = 0;
            p.Height = this.Height;
            p.Width = this.Width;
            p.MaximumSize = new Size(0, 0);
            p.Size = this.Size;
            p.Anchor = ( AnchorStyles.Left | AnchorStyles.Top);
            Controls.Add(p);
            UpdateData();
        }

        public void UpdateData()
        {
            f.Load();
        }

        private void TabWatch_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
        }
    }
}
