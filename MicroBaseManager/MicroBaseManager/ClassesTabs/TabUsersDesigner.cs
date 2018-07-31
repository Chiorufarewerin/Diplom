using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager.ClassesTabs
{
    public partial class TabUsersDesigner : Form
    {
        public TabUsersDesigner()
        {
            InitializeComponent();
            UpdateData();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
            MainForm.UpdateAll();
        }

        private void OpenInfoUser_Click(object sender, EventArgs e)
        {
            new UserInfo(new User()).Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (new RegisterUserForm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
                UpdateData();
        }

        public void UpdateData()
        {
            UsersGridView.Rows.Clear();
            if (Controls.ContainsKey("UserInfoPanel"))
                Controls.RemoveByKey("UserInfoPanel"); 
            UserLabel.Text = User.CurrentUser.Login;
            DataTable table = new DataTable();
            Answer answer = Database.SendGetAnswer("USERS");
            if (answer.Info != Inf.OK)
            {
                PermissionDenied.Visible = true;
                PermissionDenied.Text = answer.Message;
                PermissionDenied.BringToFront();
                return;
            }
            PermissionDenied.Visible = false;
            foreach (string login in Database.SendGetAnswer("USERS").GetSerializedData(new string[]{"V", "L|, "}).GetEnumerable())
            {
                UsersGridView.Rows.Add(new object[]{null, login, Database.SendGetAnswer("GETUSERROLE " + login).Message});
            }
        }

        private void UsersGridView_CellContentClick(object sender, EventArgs e)
        {
            if (UsersGridView.SelectedRows.Count == 0)
                return;
            UserInfo f = new UserInfo(new User(UsersGridView.SelectedRows[0].Cells["Login"].Value.ToString()));
            Panel p = f.EditPanel;
            p.Top = UsersGridView.Top + 12;
            p.Left = UsersGridView.Left + UsersGridView.Width + 5;
            p.Height = MainPanel.Height;
            p.Width = MainPanel.Width;
            p.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            p.Name = "UserInfoPanel";
            EditPanel.Controls.Add(p);
            p.BringToFront();
            EditPanel.Invalidate();
            p.Invalidate();
        }
    }
}
