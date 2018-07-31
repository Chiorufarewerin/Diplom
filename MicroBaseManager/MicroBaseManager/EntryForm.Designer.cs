namespace MicroBaseManager
{
    partial class EntryForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.PanelOfConnections = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.импортПодключенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортПодключенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьСправкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConnection = new System.Windows.Forms.Button();
            this.ConnectionMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.подключитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьСоединениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelOfConnections.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.ConnectionMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelOfConnections
            // 
            this.PanelOfConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelOfConnections.AutoScroll = true;
            this.PanelOfConnections.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PanelOfConnections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelOfConnections.Controls.Add(this.SettingsButton);
            this.PanelOfConnections.Controls.Add(this.ConnectionButton);
            this.PanelOfConnections.Location = new System.Drawing.Point(12, 94);
            this.PanelOfConnections.Name = "PanelOfConnections";
            this.PanelOfConnections.Size = new System.Drawing.Size(835, 455);
            this.PanelOfConnections.TabIndex = 1;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = global::MicroBaseManager.Properties.Resources.settingsOn;
            this.SettingsButton.Location = new System.Drawing.Point(225, 55);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(29, 26);
            this.SettingsButton.TabIndex = 3;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.MouseEnter += new System.EventHandler(this.SettingsButton_MouseEnter);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.SettingsButton_MouseLeave);
            // 
            // ConnectionButton
            // 
            this.ConnectionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ConnectionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectionButton.Image = global::MicroBaseManager.Properties.Resources.ConnectButton;
            this.ConnectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConnectionButton.Location = new System.Drawing.Point(12, 12);
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.Size = new System.Drawing.Size(250, 76);
            this.ConnectionButton.TabIndex = 0;
            this.ConnectionButton.Text = "ConnectionButton";
            this.ConnectionButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ConnectionButton.UseVisualStyleBackColor = false;
            this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            this.ConnectionButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConnectionButton_MouseDown);
            this.ConnectionButton.MouseEnter += new System.EventHandler(this.ConnectionButton_MouseEnter);
            this.ConnectionButton.MouseLeave += new System.EventHandler(this.ConnectionButton_MouseLeave);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(859, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "Главное меню";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.импортПодключенийToolStripMenuItem,
            this.экспортПодключенийToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // импортПодключенийToolStripMenuItem
            // 
            this.импортПодключенийToolStripMenuItem.Name = "импортПодключенийToolStripMenuItem";
            this.импортПодключенийToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.импортПодключенийToolStripMenuItem.Text = "Импорт подключений";
            // 
            // экспортПодключенийToolStripMenuItem
            // 
            this.экспортПодключенийToolStripMenuItem.Name = "экспортПодключенийToolStripMenuItem";
            this.экспортПодключенийToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.экспортПодключенийToolStripMenuItem.Text = "Экспорт подключений";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.основныеToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // основныеToolStripMenuItem
            // 
            this.основныеToolStripMenuItem.Name = "основныеToolStripMenuItem";
            this.основныеToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.основныеToolStripMenuItem.Text = "Основные";
            this.основныеToolStripMenuItem.Click += new System.EventHandler(this.основныеToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьСправкуToolStripMenuItem,
            this.toolStripSeparator1,
            this.оПрограммеToolStripMenuItem1});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // открытьСправкуToolStripMenuItem
            // 
            this.открытьСправкуToolStripMenuItem.Name = "открытьСправкуToolStripMenuItem";
            this.открытьСправкуToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.открытьСправкуToolStripMenuItem.Text = "Открыть справку";
            this.открытьСправкуToolStripMenuItem.Click += new System.EventHandler(this.открытьСправкуToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.оПрограммеToolStripMenuItem1.Text = "О программе";
            this.оПрограммеToolStripMenuItem1.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // AddConnection
            // 
            this.AddConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddConnection.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.AddConnection.FlatAppearance.BorderSize = 0;
            this.AddConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddConnection.ForeColor = System.Drawing.Color.White;
            this.AddConnection.Image = ((System.Drawing.Image)(resources.GetObject("AddConnection.Image")));
            this.AddConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddConnection.Location = new System.Drawing.Point(12, 30);
            this.AddConnection.Name = "AddConnection";
            this.AddConnection.Size = new System.Drawing.Size(246, 61);
            this.AddConnection.TabIndex = 0;
            this.AddConnection.Text = "Добавить подключение";
            this.AddConnection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddConnection.UseVisualStyleBackColor = true;
            this.AddConnection.Click += new System.EventHandler(this.AddConnection_Click);
            // 
            // ConnectionMenu
            // 
            this.ConnectionMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьсяToolStripMenuItem,
            this.настройкаToolStripMenuItem,
            this.проверитьСоединениеToolStripMenuItem});
            this.ConnectionMenu.Name = "ConnectionMenu";
            this.ConnectionMenu.Size = new System.Drawing.Size(203, 70);
            // 
            // подключитьсяToolStripMenuItem
            // 
            this.подключитьсяToolStripMenuItem.Name = "подключитьсяToolStripMenuItem";
            this.подключитьсяToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.подключитьсяToolStripMenuItem.Text = "Подключиться";
            this.подключитьсяToolStripMenuItem.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // настройкаToolStripMenuItem
            // 
            this.настройкаToolStripMenuItem.Name = "настройкаToolStripMenuItem";
            this.настройкаToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.настройкаToolStripMenuItem.Text = "Настройка";
            this.настройкаToolStripMenuItem.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // проверитьСоединениеToolStripMenuItem
            // 
            this.проверитьСоединениеToolStripMenuItem.Name = "проверитьСоединениеToolStripMenuItem";
            this.проверитьСоединениеToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.проверитьСоединениеToolStripMenuItem.Text = "Проверить соединение";
            this.проверитьСоединениеToolStripMenuItem.Click += new System.EventHandler(this.проверитьСоединениеToolStripMenuItem_Click);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 561);
            this.Controls.Add(this.AddConnection);
            this.Controls.Add(this.PanelOfConnections);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "EntryForm";
            this.Text = "MicroBase Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EntryForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ButtonsLocationChange);
            this.PanelOfConnections.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ConnectionMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelOfConnections;
        private System.Windows.Forms.Button AddConnection;
        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem импортПодключенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортПодключенийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьСправкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ContextMenuStrip ConnectionMenu;
        private System.Windows.Forms.ToolStripMenuItem подключитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверитьСоединениеToolStripMenuItem;
    }
}