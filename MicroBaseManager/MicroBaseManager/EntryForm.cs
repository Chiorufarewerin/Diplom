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
    public partial class EntryForm : Template
    {
        public static Dictionary<Button, Connection> ConnectionsButtons = new Dictionary<Button, Connection>();

        public EntryForm()
        {
            InitializeComponent();
            this.ConnectionButton.Visible = false;
            this.SettingsButton.Visible = false;
            LoadListConnections();
        }

        public void LoadListConnections()
        {
            try
            {
                using (StreamReader reader = new StreamReader("connections.dat"))
                {
                    string line;
                    string[] data;
                    Connection conn;
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(new char[] { ':' });
                        conn = new Connection(data[0], data[1], int.Parse(data[2]));
                        AddConnection_Click(conn, null);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (StreamWriter write = new StreamWriter("connections.dat", false))
                    {
                    }
                }catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить информацию о соединениях\nПричина ошибки:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveListConnections()
        {
            try
            {
                using (StreamWriter write = new StreamWriter("connections.dat", false))
                {
                    foreach (Connection conn in ConnectionsButtons.Values)
                    {
                        write.WriteLine("{0}:{1}:{2}", conn.GetName(), conn.GetConnect(), conn.GetPort());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить информацию о соединениях\nПричина ошибки:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            Button btn = null;
            if (sender is ToolStripMenuItem)
            {
                btn = (Button)ConnectionMenu.SourceControl;
            }
            else
            {
                btn = (Button)sender;
            }

            Connection conn = ConnectionsButtons[btn];

            if (!Database.Connect(conn))
                return;
            try
            {
            MainForm MF = new MainForm();
            this.Visible = false;
            MF.WindowState = FormWindowState.Maximized;

                MF.ShowDialog();
                if (MF.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch { }
        }

        private void AddConnection_Click(object sender, EventArgs e)
        {
            Connection conn = null;
            bool save = false;
            if (sender is Connection)
            {
                conn = (Connection)sender;
            }
            else
            {
                AddNewConnectionForm connectionForm = new AddNewConnectionForm();
                connectionForm.ShowDialog();
                if (connectionForm.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
                conn = connectionForm.connection;
                save = true;
            }
            Button ConnectionButton = new Button();
            ConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            ConnectionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            ConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ConnectionButton.Image = global::MicroBaseManager.Properties.Resources.ConnectButton;
            ConnectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ConnectionButton.Parent = PanelOfConnections;
            ConnectionButton.Name = "ConnectionButton_" + ConnectionButton.ToString();
            ConnectionButton.Size = new System.Drawing.Size(250, 76);
            ConnectionButton.Text = String.Format("{0}\n{1}:{2}", conn.GetName(), conn.GetConnect(), conn.GetPort());
            ConnectionButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            ConnectionButton.UseVisualStyleBackColor = false;
            ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            ConnectionButton.MouseEnter += ConnectionButton_MouseEnter;
            ConnectionButton.MouseLeave += ConnectionButton_MouseLeave;
            ConnectionButton.MouseDown += ConnectionButton_MouseDown;
            ConnectionButton.ContextMenuStrip = ConnectionMenu;

            Button SettingsButton = new Button();
            SettingsButton.Parent = ConnectionButton;
            SettingsButton.BackColor = Color.Transparent;
            SettingsButton.FlatAppearance.BorderSize = 0;
            SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SettingsButton.Image = global::MicroBaseManager.Properties.Resources.settingsOn;
            SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            SettingsButton.Location = new System.Drawing.Point(218, 45);
            SettingsButton.Name = "SettingsButton_" + SettingsButton.ToString();
            SettingsButton.Size = new System.Drawing.Size(28, 28);
            SettingsButton.UseVisualStyleBackColor = false;
            SettingsButton.MouseEnter += new System.EventHandler(this.SettingsButton_MouseEnter);
            SettingsButton.MouseLeave += new System.EventHandler(this.SettingsButton_MouseLeave);
            SettingsButton.MouseClick += SettingsButton_Click;

            ConnectionsButtons.Add(ConnectionButton, conn);
            ButtonsLocationChange(null, null);
            if (save)
                SaveListConnections();
        }

        private void ButtonsLocationChange(object sender, EventArgs e)
        {
            int x = 12;
            int y = 12;
            int margin = 20;
            foreach (Button btn in ConnectionsButtons.Keys)
            {
                if(x + btn.Width > PanelOfConnections.Width - 30)
                {
                    x = 12;
                    y += margin + btn.Height;
                }
                btn.Left = x;
                btn.Top = y;

                x += margin + btn.Width;
            }
        }

        private void ConnectionButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));

        }

        private void ConnectionButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
        }

        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = global::MicroBaseManager.Properties.Resources.settingsOff;
            btn.UseVisualStyleBackColor = false;
            btn.BackColor = Color.Transparent;
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Image = global::MicroBaseManager.Properties.Resources.settingsOn;
            btn.UseVisualStyleBackColor = false;
            btn.BackColor = Color.Transparent;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            Button parent = null;
            if (sender is ToolStripMenuItem)
            {
                parent = (Button)ConnectionMenu.SourceControl;
            }
            else
            {
                Button btn = (Button)sender;
                parent = (Button)btn.Parent;
            }
            Connection conn = ConnectionsButtons[parent];
            AddNewConnectionForm form = new AddNewConnectionForm(conn);
            form.ShowDialog();
            if (form.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            conn = form.connection;
            parent.Text = String.Format("{0}\n{1}:{2}", conn.GetName(), conn.GetConnect(), conn.GetPort());
            ConnectionsButtons[parent] = conn;
            SaveListConnections();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ConnectionButton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void проверитьСоединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Button parent = (Button)ConnectionMenu.SourceControl;
            Connection conn = ConnectionsButtons[parent];
            new TestConnectionForm(conn).ShowDialog();
        }

        private void основныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutProgramForm().ShowDialog();
        }

        private void EntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void открытьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().ShowDialog();
        }
    }
}
