using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public partial class HelpForm : Template
    {
        public HelpForm()
        {
            InitializeComponent();
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Navigate(String.Format("file:///{0}/help/index.html", curDir).Replace('\\', '/'));
        }
    }
}
