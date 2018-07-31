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
    public partial class LoginForm : Template
    {
        public LoginForm()
        {
            InitializeComponent();

            //LoginBox.Text = "Administrator";
            //PasswordBox.Text = "password";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(LoginBox.Text))
            {

            }

            if (String.IsNullOrWhiteSpace(PasswordBox.Text))
            {

            }
            if (User.LoginToServer(LoginBox.Text, PasswordBox.Text))
                this.Close();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            this.PasswordBox.PasswordChar = (!ShowPassword.Checked) ? '*' : '\0';
        }
    }
}
