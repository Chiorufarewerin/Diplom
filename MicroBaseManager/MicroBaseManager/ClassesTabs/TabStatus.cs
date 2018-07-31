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
    public partial class TabStatus : TabPage, UpdateDataInterface
    {
        private DataTable ConnectionsTable;

        public TabStatus()
        {
            InitializeComponent();
            Label timelabel = new Label();
            timelabel.Name = "timelabel";
            timelabel.Text = Database.SendGetAnswer("TIME").Message;
            timelabel.Location = new Point(271, 90);
            Label datelabel = new Label();
            datelabel.Name = "datelabel";
            datelabel.Text = Database.SendGetAnswer("DATE").Message;
            datelabel.Location = new Point(271, 70);
            Label lab = new Label();
            lab.Location = new Point(162, 70);
            lab.Text = Lang.Date;
            this.Controls.Add(lab);
            lab = new Label();
            lab.Location = new Point(162, 90);
            lab.Text = Lang.Time;
            this.Controls.Add(lab);
            this.Controls.Add(timelabel);
            this.Controls.Add(datelabel);



            this.BackColor = Color.White;

            ConnectionsTable = new DataTable();
            ConnectionsTable.Columns.Add(String.Format("{0}:{1}", Lang.IP, Lang.Port));
            ConnectionsTable.Columns.Add(Lang.User);
            ConnectionsTable.Columns.Add(Lang.DataBase);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = ConnectionsTable;
            UpdateData();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void UpdateData()
        {
            Connection conn = Database.CurrentConnection;
            label9.Text = conn.GetName();
            label8.Text = conn.GetConnect();
            label7.Text = conn.GetPort().ToString();
            Database.SendDataString("ME");
            Database.GetDataString();
            if (Database.MainConnection != null)
            {
                label4.Text = String.Format(Lang.CurrentUser, Database.SendGetAnswer("ME").Message);
                label10.Text = String.Format(Lang.CurrentDB, Database.SendGetAnswer("CURRENTDB").Message);
                label11.Text = String.Format(Lang.CountConnections, Database.SendGetAnswer("COUNTCONNECTIONS").Message);
                label12.Text = String.Format(Lang.CountUsers, Database.SendGetAnswer("COUNTUSERS").Message);
                label13.Text = String.Format(Lang.CountVars, Database.SendGetAnswer("COUNTVARSALL").Message);
                label6.Text = String.Format(Lang.Status, Lang.On);
                label5.Text = String.Format(Lang.Delay, Database.CheckConnectionPing());
                ((Label)Controls["timelabel"]).Text = Database.SendGetAnswer("TIME").Message;
                ((Label)Controls["datelabel"]).Text = Database.SendGetAnswer("DATE").Message;
                ConnectionsTable.Rows.Clear();
                Answer Connections = Database.SendGetAnswer("GETCONNECTIONS");
                if (Connections.Info == Inf.OK)
                {
                    foreach (AnswerData data in Connections.GetSerializedData(new string[]{"L", "L|,"}).GetRow())
                    {
                        ConnectionsTable.Rows.Add(new object[] { data[0].ToString(), data[1].ToString(), data[2].ToString() });
                    }
                    label15.Visible = false;
                    dataGridView1.ReadOnly = false;
                }
                else
                {
                    label15.BackColor = Color.Gainsboro;
                    label15.Visible = true;
                    label15.Text = Connections.Message;
                    dataGridView1.ReadOnly = true;
                }
                pictureBox2.Image = Properties.Resources.start;
            }
            else
            {
                label4.Text = String.Format(Lang.CurrentUser, "n/a");
                label10.Text = String.Format(Lang.CurrentDB, "n/a");
                label11.Text = String.Format(Lang.CountConnections, "n/a");
                label12.Text = String.Format(Lang.CountUsers, "n/a");
                label13.Text = String.Format(Lang.CountVars, "n/a");
                label6.Text = String.Format(Lang.Status, Lang.Off);
                label5.Text = String.Format(Lang.Delay, "n/a");
                ConnectionsTable.Rows.Clear();
                dataGridView1.ReadOnly = true;
                label15.Visible = true;
                label15.Text = "n/a";
                ((Label)Controls["datelabel"]).Text = "n/a";
                ((Label)Controls["timelabel"]).Text = "n/a";
                pictureBox2.Image = Properties.Resources.stop;
            }
            label15.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            if(label15.Visible)
                label15.Invalidate();
        }
    }
}
