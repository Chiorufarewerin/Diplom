using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public partial class MainForm : Template
    {
        public static List<string> DBList = new List<string>();
        public static LinkedList<InfoClass> ServerInformation = new LinkedList<InfoClass>();
        public static TabControl Tabss;
        public static MainForm thisForm;
        public MainForm()
        {
            InitializeComponent();
            AddTab(typeof(ClassesTabs.TabStatus), "Статус сервера");
            User.CurrentUser = new User();
            SearchBox.GotFocus += RemoveText;
            SearchBox.LostFocus += AddText;
            UpdateDBList();
            InfoTimer.Start();
            Tabs.CausesValidation=true;
            thisForm = this;
            Tabss = this.Tabs;
        }

        public static void UpdateAll()
        {
            List<TabPage> tabpages = new List<TabPage>();
            foreach (UpdateDataInterface tab in Tabss.TabPages)
            {
                if (tab is ClassesTabs.DB || tab is ClassesTabs.DBSettings)
                {
                    tabpages.Add(tab as TabPage);
                    continue;
                }
                tab.UpdateData();
            }
            foreach (TabPage tab in tabpages)
                Tabss.TabPages.Remove(tab);
            thisForm.UpdateDBList();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Disconnect();
            ServerInformation.Clear();
            InfoTimer.Stop();
        }

        public void UpdateDBList()
        {
            if (SearchBox.Text != "Поиск...")
                return;
            DBList.Clear();
            DataBasesList.Items.Clear();
            
            Answer DB = Database.SendGetAnswer("DBALL");
            if (DB.Info != Inf.OK)
                return;
            string[] data = DB.Data[0].Split(new string[] { ", " }, StringSplitOptions.None);
            DBList.AddRange(data);
            DataBasesList.Items.AddRange(data);
        }

        private void Tabs_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= Tabs.TabPages.Count)
                return;
            Font f;
            Brush backBrush;
            Brush foreBrush;

            if (e.Index == Tabs.SelectedIndex)
            {
                f = new Font(this.Font, FontStyle.Bold);
                backBrush = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.FromArgb(80, 80, 80), Color.FromArgb(150, 150, 150), System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);
                foreBrush = Brushes.Black;
            }
            else
            {
                f = e.Font;
                backBrush = new SolidBrush(e.BackColor);
                foreBrush = new SolidBrush(e.ForeColor);
            }
            
            string tabName = Tabs.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X+5, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(tabName, f, foreBrush, r, sf);
            
            sf.Dispose();

            if (e.Index == Tabs.SelectedIndex)
            {
                r = new Rectangle(e.Bounds.X + e.Bounds.Width - 25, e.Bounds.Y + 5, 20, 20);
                Brush br = new SolidBrush(Color.FromArgb(123, 255, 0, 0));
                e.Graphics.FillRectangle(br, r);
                f.Dispose();
                br.Dispose();
                backBrush.Dispose();
            }
            else
            {
                backBrush.Dispose();
                foreBrush.Dispose();
            }
            r = new Rectangle(e.Bounds.X + e.Bounds.Width - 25, e.Bounds.Y + 5, 20, 20);
            Pen p = new Pen(Color.Black, (e.Index == Tabs.SelectedIndex)?3:1);
            e.Graphics.DrawLine(p, r.X + 2, r.Y + 2, r.X + r.Width - 2, r.Y + r.Height - 2);
            e.Graphics.DrawLine(p, r.X + 2, r.Y + r.Height - 2, r.X + r.Width - 2, r.Y + 2);
            p.Dispose();
        }

        private void Tabs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;
            for (int i = 0; i < this.Tabs.TabPages.Count; i++)
            {
                Rectangle r = Tabs.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 25, r.Top + 5, 20, 20);
                if (closeButton.Contains(e.Location))
                {
                    if (Tabs.TabPages.Count > 1 && Tabs.SelectedIndex == i)
                    {
                        if (i - 1 >= 0)
                            Tabs.SelectedIndex = i - 1;
                        else
                            Tabs.SelectedIndex = 0;
                    }
                    this.Tabs.TabPages.RemoveAt(i);
                    return;
                }
                if (r.Contains(e.Location))
                {
                    page = Tabs.SelectedTab;
                    MouseDowned = true;
                    coords = Cursor.Position;
                    TabSize = r;
                    container.X = r.Right - e.Location.X;
                    container.Y = r.Top + e.Location.Y;
                    return;
                }
            }
        }

        Rectangle TabSize;
        Point container;
        Point coords;
        bool MouseDowned = false;
        OpacityForm MovingForm;
        TabPage page;

        private void Tabs_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDowned == false || page == null)
                return;
            if (Math.Abs(coords.X - Cursor.Position.X) < 10 && Math.Abs(coords.Y - Cursor.Position.Y) < 10)
                return;
            Bitmap map = new Bitmap(page.Bounds.Width, page.Bounds.Height);
            page.Show();
            page.DrawToBitmap(map, page.Bounds);
            Rectangle r = Tabs.GetTabRect(0);
            Bitmap TabMap = new Bitmap(TabSize.Width + TabSize.X, TabSize.Height + TabSize.Y);
            Tabs.DrawToBitmap(TabMap, new Rectangle(0,0, TabMap.Width, TabMap.Height));
            Graphics.FromImage(map).DrawImage(TabMap.Clone(TabSize, PixelFormat.DontCare), r.X, r.Y);
            MovingForm = new OpacityForm(map, Cursor.Position.X, Cursor.Position.Y,TabSize.Width - container.X, container.Y);
            int j = Tabs.TabPages.IndexOf(page);
            Point pos = Cursor.Position;
            if (Tabs.TabPages.Count > 1)
            {
                if (j - 1 >= 0)
                    Tabs.SelectedIndex = j - 1;
                else
                    Tabs.SelectedIndex = 0;
            }
            Tabs.TabPages.Remove(page);
            MovingForm.ShowDialog();
            pos.X -= Cursor.Position.X;
            for (int i = 0; i < this.Tabs.TabPages.Count; i++)
            {
                r = Tabs.GetTabRect(i);
                if (r.X < e.Location.X - pos.X && r.X + r.Width > e.Location.X - pos.X)
                {
                    Tabs.TabPages.Remove(page);
                    Tabs.TabPages.Insert(i, page);
                    Tabs.SelectedTab = page;
                    page = null;
                    MouseDowned = false;
                    return;
                }
            }
            if (!Tabs.TabPages.Contains(page))
            {
                if (Tabs.TabPages.Count == 0)
                    Tabs.TabPages.Add(page);
                else if(e.Location.X - pos.X < Tabs.GetTabRect(0).X)
                    Tabs.TabPages.Insert(0, page);
                else
                    Tabs.TabPages.Add(page);
            }
            Tabs.SelectedTab = page;
            page = null;
            MouseDowned = false;
        }

        private void Tabs_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDowned = false;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            SearchBox.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchBox.Text))
                SearchBox.Text = "Поиск...";
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SearchBox.Text) || SearchBox.Text == Lang.Search)
            {
                if (DataBasesList.Items.Count != DBList.Count)
                {
                    DataBasesList.Items.Clear();
                    DataBasesList.Items.AddRange(DBList.ToArray());
                }
                return;
            }
            SearchBox.Text = SearchBox.Text.ToUpper();
            int length = SearchBox.Text.Length;
            List<string> Founded = new List<string>();
            foreach (string db in DBList)
            {
                if (db.StartsWith(SearchBox.Text))
                {
                    Founded.Add(db);
                }
            }
            DataBasesList.Items.Clear();
            DataBasesList.Items.AddRange(Founded.ToArray());
            if (DataBasesList.Items.Count == 1)
                DataBasesList.SelectedIndex = 0;
            SearchBox.SelectionStart = length;
            SearchBox.SelectionLength =  0;
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (DataBasesList.SelectedIndex != -1)
                {
                    DataBasesList_DoubleClick(null, EventArgs.Empty);
                    SearchBox.Text = "";
                }
            }
        }

        private void AddTab(Type NameTab, string CreateName, object[] data=null)
        {
            if (Tabs.TabPages.ContainsKey(CreateName))
            {
                Tabs.SelectTab((TabPage)Tabs.Controls[CreateName]);
            }
            else
            {
                TabPage page;
                if (data == null)
                    page = Activator.CreateInstance(NameTab) as TabPage;
                else
                    page = Activator.CreateInstance(NameTab, data) as TabPage;
                page.Name = CreateName;
                page.Text = CreateName + "              ";
                Tabs.TabPages.Add(page);
                Tabs.SelectTab((TabPage)Tabs.Controls[CreateName]);
            }
        }

        private void StatusButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).Font = new Font(((Button)sender).Font, FontStyle.Underline);
        }

        private void StatusButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).Font = new Font(((Button)sender).Font, FontStyle.Regular);
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabStatus), "Статус сервера");
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabUsers), "Пользователи");
        }

        private void InformationButton_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabInformation), "Информация");
        }

        private void Telnet_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabTelnet), Lang.Console);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabSettings), Lang.Configuration);
        }

        public void Watch_Click(object sender, EventArgs e)
        {
            AddTab(typeof(ClassesTabs.TabWatch), "Слежение");
        }

        private void DataBasesList_DoubleClick(object sender, EventArgs e)
        {
            if (DataBasesList.SelectedItem == null)
                return;
            string NameDB = DataBasesList.SelectedItem.ToString();
            if (User.CurrentUser.Role == "Administrator" || (User.CurrentUser.Databases.ContainsKey(NameDB) && User.CurrentUser.Databases[NameDB].Read))
            AddTab(typeof(ClassesTabs.DB), Lang.DB + " " + NameDB, new object[]{NameDB});
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Tabs_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control is ClassesTabs.TabTelnet)
                ((ClassesTabs.TabTelnet)(e.Control)).f.CloseSocket();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutProgramForm().ShowDialog();
        }

        private void DataBasesList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Rectangle item = e.Bounds;
            Graphics g = e.Graphics;
            if (e.Index < 0)
                return;
            string database = DataBasesList.Items[e.Index].ToString();
            if (User.CurrentUser.Role == "Administrator")
            {
                Rectangle rect = new Rectangle(item.X + item.Width - item.Height - 4, item.Y + 2, DataBasesList.ItemHeight - 2, DataBasesList.ItemHeight - 2);
                g.DrawImage(Properties.Resources.jmet, rect);
                g.DrawString(database, new Font(e.Font, FontStyle.Bold), Brushes.Black, item.X + (item.Height - e.Font.Height), item.Y);
            }
            else
            {
                if (User.CurrentUser.Databases.ContainsKey(database))
                {
                    if(User.CurrentUser.Databases[database].Read)
                        g.DrawString(database, new Font(e.Font,FontStyle.Bold), Brushes.Black, item.X + (item.Height - e.Font.Height), item.Y);
                    else
                        g.DrawString(database, e.Font, Brushes.Black, item.X + (item.Height - e.Font.Height), item.Y);
                    if (User.CurrentUser.Databases[database].Main)
                    {
                        Rectangle rect = new Rectangle(item.X + item.Width - item.Height - 4, item.Y + 2, DataBasesList.ItemHeight - 2, DataBasesList.ItemHeight - 2);
                        g.DrawImage(Properties.Resources.jmet, rect);
                    }
                }
                else
                {
                    g.DrawString(database, e.Font, Brushes.Black, item.X + (item.Height - e.Font.Height), item.Y);
                }
            }
           
        }

        private void DataBasesList_Click(object sender, EventArgs e)
        {
            if (DataBasesList.SelectedItem == null && !(e is MouseEventArgs))
                return;
            Point click = ((MouseEventArgs)(e)).Location;
            Rectangle key = new Rectangle(DataBasesList.Width - DataBasesList.ItemHeight - 4,
                DataBasesList.SelectedIndex * DataBasesList.ItemHeight + 2,
                DataBasesList.ItemHeight - 2, DataBasesList.ItemHeight - 2);
            if (!key.Contains(click))
                return;
            string NameDB = DataBasesList.SelectedItem.ToString();
            if (User.CurrentUser.Role == "Administrator" || (User.CurrentUser.Databases.ContainsKey(NameDB) && User.CurrentUser.Databases[NameDB].Main))
                AddTab(typeof(ClassesTabs.DBSettings), Lang.DBSettings + " " + NameDB, new object[] { NameDB });
        }

        private void InfoTimer_Tick(object sender, EventArgs args)
        {
            Answer answer = Database.SendGetAnswer("INFO");
            if (answer.Info == Inf.OK)
            {
                AnswerData InfoData = answer.GetSerializedData(new string[] { "D|: ", "V" });
                float a = Convert.ToSingle(InfoData["MEMUSE"].This, CultureInfo.InvariantCulture);
                float b = Convert.ToSingle(InfoData["MEMTOT"].This, CultureInfo.InvariantCulture);
                float c = Convert.ToSingle(InfoData["CPU"].This, CultureInfo.InvariantCulture);
                if (a <= 0)
                    a = 1;
                if (b <= 0)
                    b = 1;
                if (c <= 0)
                    c = 1;
                int d = Convert.ToInt32(InfoData["SEC"].This);
                int e = Convert.ToInt32(InfoData["MIN"].This);
                int f = Convert.ToInt32(InfoData["TOTAL"].This);
                int g = Convert.ToInt32(InfoData["TIME"].This);
                ServerInformation.AddLast(new InfoClass(a, b, c, d, e, f, g));
                if (ServerInformation.Count > 500)
                    ServerInformation.RemoveFirst();
            }
        }

        private void основныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void открытьСправкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().ShowDialog();
        }


    }
}
