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
    public partial class TestConnectionForm : Template
    {
        Connection conn;
        public static Brush brushForProgressBar = Brushes.Lime;
        public TestConnectionForm(Connection conn)
        {
            InitializeComponent();
            HostPortLabel.Text = String.Format("{0}:{1}", conn.GetConnect(), conn.GetPort());
            this.conn = conn;
        }

        private void TimerForBar_Tick(object sender, EventArgs e)
        {
            try
            {
                ProgressBarConnection.Value += 1;
            }
            catch { }
        }
        bool Test = false;
        private void TestConnection()
        {
            object data = Database.CheckConnection(conn);
            if (data == null)
            {
                ProgressBarConnection.Value = ProgressBarConnection.Maximum;
                MessageBox.Show("Соединение произошло успешно!", "Проверка подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                brushForProgressBar = Brushes.Red;
                ProgressBarConnection.Value = ProgressBarConnection.Maximum;
                MessageBox.Show(String.Format("Произошла ошибка:\n{0}", data.ToString()), "Проверка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
            brushForProgressBar = Brushes.Lime;
        }

        private void TimerForConnect_Tick(object sender, EventArgs e)
        {
            if (!Test)
            {
                Test = true;
                TestConnection();
            }
        }

        public class NewProgressBar : ProgressBar
        {
            public NewProgressBar()
            {
                this.SetStyle(ControlStyles.UserPaint, true);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rec = e.ClipRectangle;

                rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
                if (ProgressBarRenderer.IsSupported)
                    ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
                rec.Height = rec.Height - 4;
                e.Graphics.FillRectangle(brushForProgressBar, 2, 2, rec.Width, rec.Height);
            }
        }

        private void TestConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimerForBar.Stop();
            TimerForConnect.Stop();
        }
    }
}
