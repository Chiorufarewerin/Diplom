namespace MicroBaseManager
{
    partial class ChangeUserForm
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
            this.BasesBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CurrentList = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PossibleList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ToCurrent = new System.Windows.Forms.Button();
            this.FromCurrent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BasesBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BasesBox
            // 
            this.BasesBox.Location = new System.Drawing.Point(154, 115);
            this.BasesBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BasesBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.BasesBox.Name = "BasesBox";
            this.BasesBox.Size = new System.Drawing.Size(419, 28);
            this.BasesBox.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Макс. число баз*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(68, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Команды:";
            // 
            // RoleBox
            // 
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(154, 78);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(419, 28);
            this.RoleBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(101, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Роль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Пароль:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.ForeColor = System.Drawing.Color.White;
            this.NameLabel.Location = new System.Drawing.Point(90, 13);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(58, 20);
            this.NameLabel.TabIndex = 22;
            this.NameLabel.Text = "Логин:";
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(303, 377);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(132, 39);
            this.Cancel.TabIndex = 20;
            this.Cancel.Text = "Отмена";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatAppearance.BorderSize = 0;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(441, 377);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(132, 39);
            this.OKButton.TabIndex = 21;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(154, 44);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(419, 28);
            this.PasswordBox.TabIndex = 19;
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(154, 10);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(419, 28);
            this.LoginBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(95, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(477, 17);
            this.label2.TabIndex = 31;
            this.label2.Text = "* - Максимальное число создания баз данных пользователю (-1 - неограничено)";
            // 
            // CurrentList
            // 
            this.CurrentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentList.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentList.FormattingEnabled = true;
            this.CurrentList.ItemHeight = 18;
            this.CurrentList.Location = new System.Drawing.Point(154, 194);
            this.CurrentList.Name = "CurrentList";
            this.CurrentList.Size = new System.Drawing.Size(182, 148);
            this.CurrentList.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(208, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Текущие";
            // 
            // PossibleList
            // 
            this.PossibleList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PossibleList.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PossibleList.FormattingEnabled = true;
            this.PossibleList.ItemHeight = 18;
            this.PossibleList.Location = new System.Drawing.Point(389, 194);
            this.PossibleList.Name = "PossibleList";
            this.PossibleList.Size = new System.Drawing.Size(183, 148);
            this.PossibleList.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(437, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Возможные";
            // 
            // ToCurrent
            // 
            this.ToCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ToCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ToCurrent.BackgroundImage = global::MicroBaseManager.Properties.Resources.arrow_reverse;
            this.ToCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ToCurrent.FlatAppearance.BorderSize = 0;
            this.ToCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToCurrent.ForeColor = System.Drawing.Color.White;
            this.ToCurrent.Location = new System.Drawing.Point(342, 217);
            this.ToCurrent.Name = "ToCurrent";
            this.ToCurrent.Size = new System.Drawing.Size(41, 38);
            this.ToCurrent.TabIndex = 36;
            this.ToCurrent.UseVisualStyleBackColor = false;
            this.ToCurrent.Click += new System.EventHandler(this.ToCurrent_Click);
            // 
            // FromCurrent
            // 
            this.FromCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FromCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FromCurrent.BackgroundImage = global::MicroBaseManager.Properties.Resources.arrow;
            this.FromCurrent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FromCurrent.FlatAppearance.BorderSize = 0;
            this.FromCurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FromCurrent.ForeColor = System.Drawing.Color.White;
            this.FromCurrent.Location = new System.Drawing.Point(342, 261);
            this.FromCurrent.Name = "FromCurrent";
            this.FromCurrent.Size = new System.Drawing.Size(41, 38);
            this.FromCurrent.TabIndex = 37;
            this.FromCurrent.UseVisualStyleBackColor = false;
            this.FromCurrent.Click += new System.EventHandler(this.FromCurrent_Click);
            // 
            // ChangeUserForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(584, 428);
            this.Controls.Add(this.FromCurrent);
            this.Controls.Add(this.ToCurrent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PossibleList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CurrentList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BasesBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.LoginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(600, 10000);
            this.MinimumSize = new System.Drawing.Size(600, 467);
            this.Name = "ChangeUserForm";
            this.Text = "Изменить пользователя";
            ((System.ComponentModel.ISupportInitialize)(this.BasesBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown BasesBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox CurrentList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox PossibleList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ToCurrent;
        private System.Windows.Forms.Button FromCurrent;

    }
}