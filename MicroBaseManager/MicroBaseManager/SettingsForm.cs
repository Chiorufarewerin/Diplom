using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public partial class SettingsForm : Template
    {
        public SettingsForm()
        {
            InitializeComponent();
            checkBox1_CheckedChanged(null, null);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Да";
                label2.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                checkBox1.Text = "Нет";
                label2.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }
    }
}
