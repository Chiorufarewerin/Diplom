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
    public partial class RegisterUserForm : Template
    {
        public RegisterUserForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ConfirmPasswordBox.Text != PasswordBox.Text)
            {
                MessageBox.Show("Пароли должны совпадать!");
                return;
            }
            if (User.RegisterUser(LoginBox.Text, PasswordBox.Text))
            {
                MessageBox.Show("Пользователь зарегистрирован!");
                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            this.PasswordBox.PasswordChar = (!ShowPassword.Checked) ? '*' : '\0';
            this.ConfirmPasswordBox.PasswordChar = (!ShowPassword.Checked) ? '*' : '\0';
        }
    }
}
