namespace MicroBaseManager
{
    partial class AddNewConnectionForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.HostBox = new System.Windows.Forms.TextBox();
            this.PortBox = new System.Windows.Forms.NumericUpDown();
            this.OKButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.CheckConnectionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(12, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(121, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Наименование:";
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.ForeColor = System.Drawing.Color.White;
            this.HostLabel.Location = new System.Drawing.Point(84, 47);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(48, 20);
            this.HostLabel.TabIndex = 1;
            this.HostLabel.Text = "Хост:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.ForeColor = System.Drawing.Color.White;
            this.PortLabel.Location = new System.Drawing.Point(80, 80);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(52, 20);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "PORT:";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(138, 10);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(368, 28);
            this.NameBox.TabIndex = 1;
            // 
            // HostBox
            // 
            this.HostBox.Location = new System.Drawing.Point(138, 44);
            this.HostBox.Name = "HostBox";
            this.HostBox.Size = new System.Drawing.Size(368, 28);
            this.HostBox.TabIndex = 2;
            this.HostBox.Text = "127.0.0.1";
            this.HostBox.Click += new System.EventHandler(this.HostBox_Click);
            this.HostBox.TextChanged += new System.EventHandler(this.HostBox_TextChanged);
            this.HostBox.Enter += new System.EventHandler(this.HostBox_Enter);
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(138, 78);
            this.PortBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(368, 28);
            this.PortBox.TabIndex = 3;
            this.PortBox.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.PortBox.ValueChanged += new System.EventHandler(this.PortBox_ValueChanged);
            this.PortBox.Click += new System.EventHandler(this.PortBox_Click);
            this.PortBox.Enter += new System.EventHandler(this.PortBox_Enter);
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(374, 123);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(132, 39);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(236, 123);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(132, 39);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CheckConnectionButton
            // 
            this.CheckConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CheckConnectionButton.FlatAppearance.BorderSize = 0;
            this.CheckConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckConnectionButton.ForeColor = System.Drawing.Color.White;
            this.CheckConnectionButton.Location = new System.Drawing.Point(12, 123);
            this.CheckConnectionButton.Name = "CheckConnectionButton";
            this.CheckConnectionButton.Size = new System.Drawing.Size(206, 39);
            this.CheckConnectionButton.TabIndex = 4;
            this.CheckConnectionButton.Text = "Проверить подключение";
            this.CheckConnectionButton.UseVisualStyleBackColor = false;
            this.CheckConnectionButton.Click += new System.EventHandler(this.CheckConnectionButton_Click);
            // 
            // AddNewConnectionForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 174);
            this.Controls.Add(this.CheckConnectionButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.HostBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.HostLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNewConnectionForm";
            this.Text = "AddNewConnectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.PortBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox HostBox;
        private System.Windows.Forms.NumericUpDown PortBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button CheckConnectionButton;
    }
}