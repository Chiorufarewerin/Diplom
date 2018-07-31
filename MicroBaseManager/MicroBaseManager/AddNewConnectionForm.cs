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
    public partial class AddNewConnectionForm : Template
    {
        private string OldName = "";
        public Connection connection;

        public AddNewConnectionForm()
        {
            InitializeComponent();
            this.Text = "Добавление подключения";
        }

        public AddNewConnectionForm(Connection conn)
        {
            InitializeComponent();
            this.Text = "Изменение подключения";
            NameBox.Text = conn.GetName();
            HostBox.Text = conn.GetConnect();
            PortBox.Value = conn.GetPort();
            this.OldName = conn.GetName();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text.Trim();
            string host = HostBox.Text;
            int port = (int)PortBox.Value;
            if (name.Length > 15)
            {
                MessageBox.Show("Наименование не должно быть длиннее 15 символов", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (name == "")
            {
                MessageBox.Show("Наименование не должно быть пустым", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (host == "")
            {
                MessageBox.Show("Хост не должен быть пустым", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (Connection conn in EntryForm.ConnectionsButtons.Values)
            {
                if (conn.GetName() == name && conn.GetName() != OldName)
                {
                    MessageBox.Show("Соединение с таким наименованием уже существует", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            connection = new Connection(name, host, port);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void CheckConnectionButton_Click(object sender, EventArgs e)
        {
            string host = HostBox.Text;
            int port = (int)PortBox.Value;
            if (host == "")
            {
                MessageBox.Show("Хост не должен быть пустым", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Connection conn = new Connection("", host, port);
            new TestConnectionForm(conn).ShowDialog();
        }

        bool SelectTextHost = true;
        bool SelectTextPORT = true;
        private void HostBox_Enter(object sender, EventArgs e)
        {
            if (SelectTextHost)
                HostBox.SelectAll();
        }

        private void HostBox_Click(object sender, EventArgs e)
        {
            if (SelectTextHost)
                HostBox.SelectAll();
        }

        private void HostBox_TextChanged(object sender, EventArgs e)
        {
            SelectTextHost = false;
        }

        private void PortBox_Enter(object sender, EventArgs e)
        {
            if (SelectTextPORT)
            {
                PortBox.Select(0, PortBox.Value.ToString().Length);
            }
        }

        private void PortBox_Click(object sender, EventArgs e)
        {
            if (SelectTextPORT)
            {
                PortBox.Select(0, PortBox.Value.ToString().Length);
            }
        }

        private void PortBox_ValueChanged(object sender, EventArgs e)
        {
            SelectTextPORT = false;
        }
    }
}
