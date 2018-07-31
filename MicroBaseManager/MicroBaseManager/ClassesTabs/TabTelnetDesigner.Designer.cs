namespace MicroBaseManager.ClassesTabs
{
    partial class TabTelnetDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EditPanel = new System.Windows.Forms.Panel();
            this.MessageTextBox = new System.Windows.Forms.RichTextBox();
            this.ConsoleTextBox = new System.Windows.Forms.RichTextBox();
            this.EditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.MessageTextBox);
            this.EditPanel.Controls.Add(this.ConsoleTextBox);
            this.EditPanel.Location = new System.Drawing.Point(12, 12);
            this.EditPanel.MinimumSize = new System.Drawing.Size(640, 543);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(640, 543);
            this.EditPanel.TabIndex = 0;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.BackColor = System.Drawing.Color.Black;
            this.MessageTextBox.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageTextBox.ForeColor = System.Drawing.Color.White;
            this.MessageTextBox.Location = new System.Drawing.Point(3, 452);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(634, 88);
            this.MessageTextBox.TabIndex = 3;
            this.MessageTextBox.Text = "";
            this.MessageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MessageTextBox_KeyPress);
            // 
            // ConsoleTextBox
            // 
            this.ConsoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsoleTextBox.BackColor = System.Drawing.Color.Black;
            this.ConsoleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConsoleTextBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConsoleTextBox.ForeColor = System.Drawing.Color.White;
            this.ConsoleTextBox.Location = new System.Drawing.Point(3, 3);
            this.ConsoleTextBox.Name = "ConsoleTextBox";
            this.ConsoleTextBox.ReadOnly = true;
            this.ConsoleTextBox.Size = new System.Drawing.Size(637, 443);
            this.ConsoleTextBox.TabIndex = 2;
            this.ConsoleTextBox.Text = "";
            this.ConsoleTextBox.TextChanged += new System.EventHandler(this.ConsoleTextBox_TextChanged);
            // 
            // TabTelnetDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 561);
            this.Controls.Add(this.EditPanel);
            this.Name = "TabTelnetDesigner";
            this.Text = "TabConsoleDesigner";
            this.EditPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.RichTextBox MessageTextBox;
        private System.Windows.Forms.RichTextBox ConsoleTextBox;

    }
}