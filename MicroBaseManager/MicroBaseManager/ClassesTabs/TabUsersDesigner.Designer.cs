namespace MicroBaseManager.ClassesTabs
{
    partial class TabUsersDesigner
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
            this.PermissionDenied = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UserLabel = new System.Windows.Forms.Label();
            this.OpenInfoUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.EditPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditPanel.BackColor = System.Drawing.Color.White;
            this.EditPanel.Controls.Add(this.PermissionDenied);
            this.EditPanel.Controls.Add(this.panel2);
            this.EditPanel.Controls.Add(this.label3);
            this.EditPanel.Controls.Add(this.UsersGridView);
            this.EditPanel.Controls.Add(this.label1);
            this.EditPanel.Controls.Add(this.MainPanel);
            this.EditPanel.Location = new System.Drawing.Point(12, 12);
            this.EditPanel.MinimumSize = new System.Drawing.Size(640, 543);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(765, 543);
            this.EditPanel.TabIndex = 0;
            // 
            // PermissionDenied
            // 
            this.PermissionDenied.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PermissionDenied.BackColor = System.Drawing.Color.Gainsboro;
            this.PermissionDenied.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PermissionDenied.Location = new System.Drawing.Point(16, 132);
            this.PermissionDenied.Name = "PermissionDenied";
            this.PermissionDenied.Size = new System.Drawing.Size(734, 394);
            this.PermissionDenied.TabIndex = 23;
            this.PermissionDenied.Text = "Недостаточно прав";
            this.PermissionDenied.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.RegisterButton);
            this.panel2.Controls.Add(this.LoginButton);
            this.panel2.Controls.Add(this.UserLabel);
            this.panel2.Controls.Add(this.OpenInfoUser);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 100);
            this.panel2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ваше имя пользователя:  ";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(402, 49);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(223, 30);
            this.RegisterButton.TabIndex = 19;
            this.RegisterButton.Text = "Зарегистрировать нового";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(206, 49);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(190, 30);
            this.LoginButton.TabIndex = 20;
            this.LoginButton.Text = "Сменить пользователя";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UserLabel.Location = new System.Drawing.Point(214, 11);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(50, 21);
            this.UserLabel.TabIndex = 2;
            this.UserLabel.Text = "Guest";
            // 
            // OpenInfoUser
            // 
            this.OpenInfoUser.Location = new System.Drawing.Point(16, 49);
            this.OpenInfoUser.Name = "OpenInfoUser";
            this.OpenInfoUser.Size = new System.Drawing.Size(184, 30);
            this.OpenInfoUser.TabIndex = 3;
            this.OpenInfoUser.Text = "Открыть информацию";
            this.OpenInfoUser.UseVisualStyleBackColor = true;
            this.OpenInfoUser.Click += new System.EventHandler(this.OpenInfoUser_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(78, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(609, 37);
            this.label3.TabIndex = 18;
            this.label3.Text = "Управление пользователями";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsersGridView
            // 
            this.UsersGridView.AllowUserToAddRows = false;
            this.UsersGridView.AllowUserToDeleteRows = false;
            this.UsersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UsersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersGridView.BackgroundColor = System.Drawing.Color.White;
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Login,
            this.Role});
            this.UsersGridView.GridColor = System.Drawing.Color.White;
            this.UsersGridView.Location = new System.Drawing.Point(16, 132);
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.ReadOnly = true;
            this.UsersGridView.RowHeadersVisible = false;
            this.UsersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersGridView.Size = new System.Drawing.Size(302, 394);
            this.UsersGridView.TabIndex = 17;
            this.UsersGridView.SelectionChanged += new System.EventHandler(this.UsersGridView_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 30.68528F;
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 30;
            // 
            // Login
            // 
            this.Login.FillWeight = 127.1574F;
            this.Login.HeaderText = "Пользователь";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            // 
            // Role
            // 
            this.Role.FillWeight = 127.1574F;
            this.Role.HeaderText = "Роль";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(324, 132);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(426, 394);
            this.MainPanel.TabIndex = 22;
            // 
            // TabUsersDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 612);
            this.Controls.Add(this.EditPanel);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(805, 651);
            this.Name = "TabUsersDesigner";
            this.Text = "TabUsersDesigner";
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Button OpenInfoUser;
        private System.Windows.Forms.DataGridView UsersGridView;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel EditPanel;
        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.Label PermissionDenied;
    }
}