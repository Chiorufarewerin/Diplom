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
    public partial class TabInformation : TabPage, UpdateDataInterface
    {
        public TabInformationDesigner f;
        Panel p;
        public TabInformation()
        {
            InitializeComponent();
            f = new TabInformationDesigner();
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

        private void TabInformation_Resize(object sender, EventArgs e)
        {
            p.Size = this.Size;
        }
    }
}
