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
    public partial class ChangeUserForm : Template
    {
        public string[] AllCommands;
        User user;
        public ChangeUserForm(User user)
        {
            this.user = user;
            InitializeComponent();
            LoginBox.Text = user.Login;
            PasswordBox.Text = user.Password;
            RoleBox.Items.AddRange(Database.SendGetAnswer("GETROLES").GetSerializedData(new string[] {"V", "L|, "}).Values);
            RoleBox.Text = user.Role;
            AllCommands = Database.SendGetAnswer("LSALL").GetSerializedData(new string[] { "V", "L|, " }).Values;
            BasesBox.Value = Convert.ToInt32(user.MaxCountCreateDB);
            CurrentList.Items.AddRange(user.UserCommands);
            CurrentList.Sorted = true;
            PossibleList.Sorted = true;
            UpdatePossible();
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePossible()
        {
            PossibleList.Items.Clear();
            HashSet<String> All = new HashSet<string>(AllCommands);
            HashSet<String> Current = new HashSet<string>((string[])user.UserCommands);
            All.ExceptWith(Current);
            PossibleList.Items.AddRange(All.ToArray());
        }

        private void ToCurrent_Click(object sender, EventArgs e)
        {
            if (PossibleList.SelectedIndex != -1)
            {
                CurrentList.Items.Add(PossibleList.SelectedItem);
                PossibleList.Items.RemoveAt(PossibleList.SelectedIndex);
            }
        }

        private void FromCurrent_Click(object sender, EventArgs e)
        {
            if (CurrentList.SelectedIndex != -1)
            {
                PossibleList.Items.Add(CurrentList.SelectedItem);
                CurrentList.Items.RemoveAt(CurrentList.SelectedIndex);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
