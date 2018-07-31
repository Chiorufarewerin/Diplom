namespace MicroBaseManager.ClassesTabs
{
    partial class DBSettingsDesigner
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UsersDBGridView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CountVariablesLabel = new System.Windows.Forms.Label();
            this.CountConnectionsLabel = new System.Windows.Forms.Label();
            this.CountListenersLabel = new System.Windows.Forms.Label();
            this.EditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDBGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.CountListenersLabel);
            this.EditPanel.Controls.Add(this.CountConnectionsLabel);
            this.EditPanel.Controls.Add(this.CountVariablesLabel);
            this.EditPanel.Controls.Add(this.label3);
            this.EditPanel.Controls.Add(this.label2);
            this.EditPanel.Controls.Add(this.button2);
            this.EditPanel.Controls.Add(this.button1);
            this.EditPanel.Controls.Add(this.label1);
            this.EditPanel.Controls.Add(this.DeleteButton);
            this.EditPanel.Controls.Add(this.ReplaceButton);
            this.EditPanel.Controls.Add(this.AddButton);
            this.EditPanel.Controls.Add(this.UsersDBGridView);
            this.EditPanel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditPanel.Location = new System.Drawing.Point(18, 18);
            this.EditPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EditPanel.MinimumSize = new System.Drawing.Size(640, 543);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(640, 543);
            this.EditPanel.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(7, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 31);
            this.button2.TabIndex = 25;
            this.button2.Text = "Переименовать базу данных";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(7, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 31);
            this.button1.TabIndex = 24;
            this.button1.Text = "Удалить базу данных";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Количество переменных:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteButton.Location = new System.Drawing.Point(237, 173);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(111, 31);
            this.DeleteButton.TabIndex = 22;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReplaceButton.Location = new System.Drawing.Point(120, 173);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(111, 31);
            this.ReplaceButton.TabIndex = 21;
            this.ReplaceButton.Text = "Изменить";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddButton.Location = new System.Drawing.Point(3, 173);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(111, 31);
            this.AddButton.TabIndex = 20;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // UsersDBGridView
            // 
            this.UsersDBGridView.AllowUserToAddRows = false;
            this.UsersDBGridView.AllowUserToDeleteRows = false;
            this.UsersDBGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersDBGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UsersDBGridView.BackgroundColor = System.Drawing.Color.White;
            this.UsersDBGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDBGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Role});
            this.UsersDBGridView.GridColor = System.Drawing.Color.White;
            this.UsersDBGridView.Location = new System.Drawing.Point(3, 210);
            this.UsersDBGridView.Name = "UsersDBGridView";
            this.UsersDBGridView.ReadOnly = true;
            this.UsersDBGridView.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersDBGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.UsersDBGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersDBGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersDBGridView.Size = new System.Drawing.Size(634, 330);
            this.UsersDBGridView.TabIndex = 19;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.DefaultCellStyle = dataGridViewCellStyle1;
            this.Login.FillWeight = 127.1574F;
            this.Login.Frozen = true;
            this.Login.HeaderText = "Пользователь";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 150;
            // 
            // Role
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Role.DefaultCellStyle = dataGridViewCellStyle2;
            this.Role.FillWeight = 127.1574F;
            this.Role.HeaderText = "Доступ";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Количество подключений:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Количество слушателей:";
            // 
            // CountVariablesLabel
            // 
            this.CountVariablesLabel.AutoSize = true;
            this.CountVariablesLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountVariablesLabel.Location = new System.Drawing.Point(222, 79);
            this.CountVariablesLabel.Name = "CountVariablesLabel";
            this.CountVariablesLabel.Size = new System.Drawing.Size(152, 21);
            this.CountVariablesLabel.TabIndex = 28;
            this.CountVariablesLabel.Text = "CountVariablesLabel";
            // 
            // CountConnectionsLabel
            // 
            this.CountConnectionsLabel.AutoSize = true;
            this.CountConnectionsLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountConnectionsLabel.Location = new System.Drawing.Point(222, 110);
            this.CountConnectionsLabel.Name = "CountConnectionsLabel";
            this.CountConnectionsLabel.Size = new System.Drawing.Size(52, 21);
            this.CountConnectionsLabel.TabIndex = 29;
            this.CountConnectionsLabel.Text = "label4";
            // 
            // CountListenersLabel
            // 
            this.CountListenersLabel.AutoSize = true;
            this.CountListenersLabel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountListenersLabel.Location = new System.Drawing.Point(222, 140);
            this.CountListenersLabel.Name = "CountListenersLabel";
            this.CountListenersLabel.Size = new System.Drawing.Size(52, 21);
            this.CountListenersLabel.TabIndex = 30;
            this.CountListenersLabel.Text = "label4";
            // 
            // DBSettingsDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 576);
            this.Controls.Add(this.EditPanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DBSettingsDesigner";
            this.Text = "DBSettingsDesigner";
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDBGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.DataGridView UsersDBGridView;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.Label CountVariablesLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CountConnectionsLabel;
        private System.Windows.Forms.Label CountListenersLabel;
    }
}