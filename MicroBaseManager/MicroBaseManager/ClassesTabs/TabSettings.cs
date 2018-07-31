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
    public partial class TabSettings : TabPage, UpdateDataInterface
    {
        public TabSettingsDesigner f;
        Panel p;
        public TabSettings()
        {
            InitializeComponent();
            f = new TabSettingsDesigner();
            p = f.EditPanel;
            p.Top = 0;
            p.Left = 0;
            p.Height = this.Height;
            p.Width = this.Width;
            p.MaximumSize = new Size(0, 0);
            p.Size = this.Size;
            p.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            p.Font = this.Font;
            Controls.Add(p);
        }

        public void UpdateData()
        {
            f.Initialize();
        }

        private void TabSettings_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
        }
    }
}
