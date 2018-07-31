using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager.ClassesTabs
{
    public partial class TabTelnetDesigner : Template
    {
        public struct ColorText
        {
            public int start;
            public int length;
            public Color c;
        }
        List<ColorText> Colors = new List<ColorText>();
        Socket socket;
        public TabTelnetDesigner()
        {
            InitializeComponent();
            InitializeTelnet();
            MessageTextBox.Focus();
            this.ActiveControl = MessageTextBox;
        }

        public void InitializeTelnet()
        {
            CloseSocket();
            try
            {
                socket = Database.GetSocketFromConnect(Database.CurrentConnection);
            }
            catch
            {
                WriteToConsole(((char)(27)) + "[0;31mСоединение с сервером не установлено!");
                MessageTextBox.ReadOnly = true;
                return;
            }
            try
            {
                Database.SendGetAnswerWithSocket(socket, "RU");
                if (User.CurrentUser != null)
                    Database.SendGetAnswerWithSocket(socket, String.Format("LOGIN {0} {1}", User.CurrentUser.Login, User.CurrentUser.Password));
                WriteToConsole("Введите HELP для помощи");
                MessageTextBox.ReadOnly = false;
            }
            catch { }

        }
        public void WriteToConsole(string message)
        {
            ConsoleTextBox.Text += message + ((message.IndexOf((char)27) != -1)?"":"\n");
            if (ConsoleTextBox.Text.Contains((char)27))
                ConsoleTextBox_TextChanged(null, null);
            ConsoleTextBox.SelectionStart = ConsoleTextBox.Text.Length;
            ConsoleTextBox.ScrollToCaret();
        }

        private void MessageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != ((char)13))
                return;
            string message = MessageTextBox.Text.Trim();
            MessageTextBox.Text = "";
            if (message.Equals(""))
                return;
            string command;
            if (!Database.SendDataStringWithSocket(socket, message))
            {
                WriteToConsole(((char)(27)) + "[0;31mСоединение с сервером было разорвано!");
                MessageTextBox.ReadOnly = true;
                return;
            }
            String answer = Database.GetDataStringWithSocket(socket);
            command = message.Split(new char[] { ' ' })[0].ToUpper();
            if (command.Equals("CLEAR"))
            {
                Colors.Clear();
                ConsoleTextBox.Text = "\n";
                return;
            }
            WriteToConsole(answer);
            MessageTextBox.SelectionFont = new Font(this.Font, FontStyle.Bold);
        }

        private void ConsoleTextBox_TextChanged(object sender, EventArgs e)
        {
            Color rgb = Color.White;
            int pos = ConsoleTextBox.Text.IndexOf((char)27);
            if (pos != -1)
            {
                string newstrings = ConsoleTextBox.Text.Substring(pos + 1, ConsoleTextBox.Text.Length - pos - 1);
                ConsoleTextBox.Text = ConsoleTextBox.Text.Substring(0, pos);
                foreach (string item in newstrings.Split((char)27))
                {
                    if (item.StartsWith("[0;31m"))
                    {
                        rgb = Color.Red;
                    }
                    if (item.StartsWith("[0;36m"))
                    {
                        rgb = Color.Aqua;
                    }
                    if (item.StartsWith("[0;37m"))
                    {
                        rgb = Color.White;
                    }
                    string str = item.Substring(6, item.Length - 6);
                    if (str.Length == 0)
                        continue;
                    ConsoleTextBox.Text += str;
                    ColorText ct = new ColorText();
                    ct.c = rgb;
                    ct.length = str.Length;
                    ct.start = pos;
                    Colors.Add(ct);
                    pos += str.Length + 1;
                }
            }
            foreach (ColorText ct in Colors)
            {
                ConsoleTextBox.SelectionStart = ct.start;
                ConsoleTextBox.SelectionLength = ct.length;
                ConsoleTextBox.SelectionColor = ct.c;
            }
        }

         public void CloseSocket()
        {
            try
            {
                socket.Close();
            }
            catch
            {

            }
        }
    }
}
