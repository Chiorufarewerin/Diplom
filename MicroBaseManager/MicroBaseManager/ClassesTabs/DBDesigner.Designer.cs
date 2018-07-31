namespace MicroBaseManager.ClassesTabs
{
    partial class DBDesigner
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
            this.WatchButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.OtborBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SortingTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ValuesGridView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValuesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.WatchButton);
            this.EditPanel.Controls.Add(this.UpdateButton);
            this.EditPanel.Controls.Add(this.OtborBox);
            this.EditPanel.Controls.Add(this.label2);
            this.EditPanel.Controls.Add(this.SortingTypeBox);
            this.EditPanel.Controls.Add(this.label1);
            this.EditPanel.Controls.Add(this.DeleteButton);
            this.EditPanel.Controls.Add(this.ReplaceButton);
            this.EditPanel.Controls.Add(this.AddButton);
            this.EditPanel.Controls.Add(this.ValuesGridView);
            this.EditPanel.Location = new System.Drawing.Point(12, 12);
            this.EditPanel.MinimumSize = new System.Drawing.Size(640, 543);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(988, 543);
            this.EditPanel.TabIndex = 0;
            // 
            // WatchButton
            // 
            this.WatchButton.Location = new System.Drawing.Point(309, 16);
            this.WatchButton.Name = "WatchButton";
            this.WatchButton.Size = new System.Drawing.Size(96, 32);
            this.WatchButton.TabIndex = 27;
            this.WatchButton.Text = "Следить";
            this.WatchButton.UseVisualStyleBackColor = true;
            this.WatchButton.Click += new System.EventHandler(this.WatchButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(882, 16);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(96, 32);
            this.UpdateButton.TabIndex = 26;
            this.UpdateButton.Text = "Обновить";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // OtborBox
            // 
            this.OtborBox.Location = new System.Drawing.Point(727, 19);
            this.OtborBox.Name = "OtborBox";
            this.OtborBox.Size = new System.Drawing.Size(149, 28);
            this.OtborBox.TabIndex = 25;
            this.OtborBox.TextChanged += new System.EventHandler(this.OtborBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(664, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Отбор:";
            // 
            // SortingTypeBox
            // 
            this.SortingTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortingTypeBox.FormattingEnabled = true;
            this.SortingTypeBox.Items.AddRange(new object[] {
            "Нет",
            "Возврастание",
            "Убывание"});
            this.SortingTypeBox.Location = new System.Drawing.Point(528, 19);
            this.SortingTypeBox.Name = "SortingTypeBox";
            this.SortingTypeBox.Size = new System.Drawing.Size(130, 28);
            this.SortingTypeBox.TabIndex = 23;
            this.SortingTypeBox.SelectedIndexChanged += new System.EventHandler(this.SortingTypeBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Сортировка: ";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(207, 16);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(96, 32);
            this.DeleteButton.TabIndex = 21;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Location = new System.Drawing.Point(105, 16);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(96, 32);
            this.ReplaceButton.TabIndex = 20;
            this.ReplaceButton.Text = "Изменить";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 16);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(96, 32);
            this.AddButton.TabIndex = 19;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ValuesGridView
            // 
            this.ValuesGridView.AllowUserToAddRows = false;
            this.ValuesGridView.AllowUserToDeleteRows = false;
            this.ValuesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ValuesGridView.BackgroundColor = System.Drawing.Color.White;
            this.ValuesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValuesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Role});
            this.ValuesGridView.GridColor = System.Drawing.Color.White;
            this.ValuesGridView.Location = new System.Drawing.Point(3, 54);
            this.ValuesGridView.Name = "ValuesGridView";
            this.ValuesGridView.ReadOnly = true;
            this.ValuesGridView.RowHeadersVisible = false;
            this.ValuesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ValuesGridView.Size = new System.Drawing.Size(982, 486);
            this.ValuesGridView.TabIndex = 18;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Login.FillWeight = 127.1574F;
            this.Login.Frozen = true;
            this.Login.HeaderText = "Переменная";
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 200;
            // 
            // Role
            // 
            this.Role.FillWeight = 127.1574F;
            this.Role.HeaderText = "Значение";
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // DBDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1017, 577);
            this.Controls.Add(this.EditPanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DBDesigner";
            this.Text = "DBDesigner";
            this.EditPanel.ResumeLayout(false);
            this.EditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValuesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.DataGridView ValuesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox OtborBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SortingTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button WatchButton;

    }
}