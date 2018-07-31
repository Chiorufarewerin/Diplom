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
    public partial class OpacityForm : Form
    {
        Bitmap map;
        Point point;
        Point point0;
        public OpacityForm(Bitmap map, int x, int y, int x0, int y0, float opacityform=0.7f)
        {
            InitializeComponent();
            this.Width = map.Width;
            this.Height = map.Height;
            this.point = new Point(x, y);
            this.point0 = new Point(x0, y0);
            this.map = map;
            this.Opacity = opacityform;
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            timer1.Start();
        }

        private void OpacityForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(map, 0, 0);
        }

        private void OpacityForm_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(point.X, point.Y);
        }

        private void OpacityForm_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Control.MouseButtons != MouseButtons.Left)
            {
                timer1.Stop();
                this.Close();
            }
            else
            {
                this.SetDesktopLocation(Cursor.Position.X - point0.X,Cursor.Position.Y - point0.Y);
            }
        }
    }
}
