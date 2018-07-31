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
    public partial class UserInfo : Template
    {
        User user;
        public UserInfo(User user)
        {
            this.user = user;
            InitializeComponent();
            LoadUser();
            EditAccess.Visible = false;
            if (!User.CurrentUser.UserCommands.Contains("CHANGEUSER") || user.Login == User.CurrentUser.Login)
                EditLogin.Visible = false;
            
        }
        public void LoadUser()
        {
            Login.Text = user.Login;
            Role.Text = user.Role;
            Commands.Text = String.Format("                                      {0}", string.Join(", ", user.UserCommands));
            panel2.Top = Commands.PreferredHeight + Commands.Top + 5;
            panel2.Height = EditPanel.Height - panel2.Top - 5;
            CreatedBasesList.Items.Clear();
            CreatedBasesList.Items.AddRange(user.OwnerDatabases);
            CreatedBases.Text = user.OwnerDatabases.Length.ToString();
            MaxToCreate.Text = (user.MaxCountCreateDB.ToString() == "-1") ? "Неог." : user.MaxCountCreateDB.ToString();
            DBGridView.Rows.Clear();
            foreach (var val in user.Databases)
            {
                DBGridView.Rows.Add(val.Key, string.Join(", ", val.Value));
            }
        }
        private static double one = 85;
        private static double two = 137;
        private static double three = 251;
        private static double k1 = three / one;
        private static double k2 = three / two;
        private void panel2_Resize(object sender, EventArgs e)
        {
            Commands.MaximumSize = new Size(panel3.Width,0);
            Commands.MinimumSize = new Size(panel3.Width, 0);
            panel2.Top = Commands.PreferredHeight + Commands.Top + 5;
            panel2.Height = EditPanel.Height - panel2.Top - 5;
            panel3.Height = (int)(panel2.Height / k1);
            panel4.Height = (int)(panel2.Height / k2);
            panel4.Top = panel3.Top + panel3.Height;
            panel4.Height = panel2.Height - panel4.Top -5;
            EditAccess.Top = panel4.Top + (panel4.Height - DBGridView.Height);
            EditAccess.Height = DBGridView.Height;
        }

        private void Commands_TextChanged(object sender, EventArgs e)
        {
            Commands.Height = Commands.PreferredHeight;
        }

        private void EditLogin_Click(object sender, EventArgs e)
        {
            if (new ChangeUserForm(user).ShowDialog() == DialogResult.OK)
            {
                user = new User(user.Login);
                LoadUser();
            }
        }
    }
}
