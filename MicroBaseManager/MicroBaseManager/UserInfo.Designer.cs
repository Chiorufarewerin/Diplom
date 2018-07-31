namespace MicroBaseManager
{
    partial class UserInfo
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
            this.EditLogin = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.Role = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Commands = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EditAccess = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CreatedBasesList = new System.Windows.Forms.ListBox();
            this.CreatedBases = new System.Windows.Forms.Label();
            this.MaxToCreate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.DBGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditPanel.Controls.Add(this.EditLogin);
            this.EditPanel.Controls.Add(this.label10);
            this.EditPanel.Controls.Add(this.Role);
            this.EditPanel.Controls.Add(this.Login);
            this.EditPanel.Controls.Add(this.label2);
            this.EditPanel.Controls.Add(this.label1);
            this.EditPanel.Controls.Add(this.Commands);
            this.EditPanel.Controls.Add(this.panel2);
            this.EditPanel.Location = new System.Drawing.Point(12, 12);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(414, 562);
            this.EditPanel.TabIndex = 0;
            // 
            // EditLogin
            // 
            this.EditLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditLogin.BackColor = System.Drawing.Color.Transparent;
            this.EditLogin.BackgroundImage = global::MicroBaseManager.Properties.Resources.Edit;
            this.EditLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EditLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EditLogin.FlatAppearance.BorderSize = 0;
            this.EditLogin.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.EditLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.EditLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EditLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditLogin.Location = new System.Drawing.Point(351, 16);
            this.EditLogin.Name = "EditLogin";
            this.EditLogin.Size = new System.Drawing.Size(57, 60);
            this.EditLogin.TabIndex = 16;
            this.EditLogin.UseVisualStyleBackColor = false;
            this.EditLogin.Click += new System.EventHandler(this.EditLogin_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Команды пользователя: ";
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Role.Location = new System.Drawing.Point(80, 45);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(31, 21);
            this.Role.TabIndex = 9;
            this.Role.Text = "{0}";
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(80, 16);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(31, 21);
            this.Login.TabIndex = 8;
            this.Login.Text = "{0}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Роль: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин: ";
            // 
            // Commands
            // 
            this.Commands.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Commands.AutoSize = true;
            this.Commands.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Commands.Location = new System.Drawing.Point(12, 81);
            this.Commands.MaximumSize = new System.Drawing.Size(360, 0);
            this.Commands.MinimumSize = new System.Drawing.Size(360, 0);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(360, 16);
            this.Commands.TabIndex = 13;
            this.Commands.Text = "                                      {0}";
            this.Commands.TextChanged += new System.EventHandler(this.Commands_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.EditAccess);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(0, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 394);
            this.panel2.TabIndex = 14;
            this.panel2.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // EditAccess
            // 
            this.EditAccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditAccess.BackColor = System.Drawing.Color.Transparent;
            this.EditAccess.BackgroundImage = global::MicroBaseManager.Properties.Resources.Edit;
            this.EditAccess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.EditAccess.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.EditAccess.FlatAppearance.BorderSize = 0;
            this.EditAccess.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.EditAccess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.EditAccess.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.EditAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditAccess.Location = new System.Drawing.Point(374, 133);
            this.EditAccess.Name = "EditAccess";
            this.EditAccess.Size = new System.Drawing.Size(34, 109);
            this.EditAccess.TabIndex = 19;
            this.EditAccess.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.CreatedBasesList);
            this.panel3.Controls.Add(this.CreatedBases);
            this.panel3.Controls.Add(this.MaxToCreate);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(14, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(394, 85);
            this.panel3.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Создано:";
            // 
            // CreatedBasesList
            // 
            this.CreatedBasesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatedBasesList.FormattingEnabled = true;
            this.CreatedBasesList.ItemHeight = 20;
            this.CreatedBasesList.Location = new System.Drawing.Point(0, 0);
            this.CreatedBasesList.Name = "CreatedBasesList";
            this.CreatedBasesList.Size = new System.Drawing.Size(230, 84);
            this.CreatedBasesList.TabIndex = 4;
            // 
            // CreatedBases
            // 
            this.CreatedBases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreatedBases.AutoSize = true;
            this.CreatedBases.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreatedBases.Location = new System.Drawing.Point(314, 0);
            this.CreatedBases.Name = "CreatedBases";
            this.CreatedBases.Size = new System.Drawing.Size(31, 21);
            this.CreatedBases.TabIndex = 6;
            this.CreatedBases.Text = "{0}";
            // 
            // MaxToCreate
            // 
            this.MaxToCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxToCreate.AutoSize = true;
            this.MaxToCreate.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxToCreate.Location = new System.Drawing.Point(314, 19);
            this.MaxToCreate.Name = "MaxToCreate";
            this.MaxToCreate.Size = new System.Drawing.Size(31, 21);
            this.MaxToCreate.TabIndex = 7;
            this.MaxToCreate.Text = "{0}";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Макс.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Созданные базы: ";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.DBGridView);
            this.panel4.Location = new System.Drawing.Point(16, 110);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 137);
            this.panel4.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Доступ к базам:";
            // 
            // DBGridView
            // 
            this.DBGridView.AllowUserToAddRows = false;
            this.DBGridView.AllowUserToDeleteRows = false;
            this.DBGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DBGridView.BackgroundColor = System.Drawing.Color.White;
            this.DBGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.DBGridView.GridColor = System.Drawing.Color.White;
            this.DBGridView.Location = new System.Drawing.Point(0, 23);
            this.DBGridView.Name = "DBGridView";
            this.DBGridView.ReadOnly = true;
            this.DBGridView.RowHeadersVisible = false;
            this.DBGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGridView.Size = new System.Drawing.Size(355, 111);
            this.DBGridView.TabIndex = 18;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 127.1574F;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "База данных";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 127.1574F;
            this.Column2.HeaderText = "Роли";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 577);
            this.Controls.Add(this.EditPanel);
            this.MinimumSize = new System.Drawing.Size(454, 473);
            this.Name = "UserInfo";
            this.Text = "Информация о пользователе";
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label MaxToCreate;
        private System.Windows.Forms.Label CreatedBases;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox CreatedBasesList;
        private System.Windows.Forms.Label Commands;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DBGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Button EditAccess;
        private System.Windows.Forms.Button EditLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}