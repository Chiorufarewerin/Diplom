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
    public partial class MessageForm : Template
    {
        public MessageForm(string message, string header)
        {
            InitializeComponent();
            MessageLabel.Text = message;
            HeaderLabel.Text = header;
            this.Cancel.Visible = false;
        }
        public MessageForm(string message, string header, Inf info, bool CancelButton=false, string OKButtonString = null, string CancelButtonString = null)
        {
            InitializeComponent();
            MessageLabel.Text = message;
            HeaderLabel.Text = header;
            switch (info)
            {
                case Inf.Error:
                case Inf.PermissionDenied:
                case Inf.WrongAnswer: HeaderLabel.ForeColor = Color.FromArgb(255, 192, 192); break;
                case Inf.Info: HeaderLabel.ForeColor = Color.FromArgb(192, 255, 192); break;
            }
            this.Cancel.Visible = CancelButton;
            if (OKButtonString != null)
                OKButton.Text = OKButtonString;
            if (CancelButtonString != null)
                Cancel.Text = CancelButtonString;
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static DialogResult Show(string message, string header)
        {
            return new MessageForm(message, header).ShowDialog();
        }

        public static DialogResult Show(string message, string header, Inf info, bool CancelButton = false, string OKButtonString = null, string CancelButtonString = null)
        {
            return new MessageForm(message, header, info, CancelButton, OKButtonString, CancelButtonString).ShowDialog();
        }
    }
}
