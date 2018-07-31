namespace MicroBaseManager
{
    partial class MainForm
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
            this.NavigationBox = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.Watch = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Telnet = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.InformationButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.UsersButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusButton = new System.Windows.Forms.Button();
            this.InformationBox = new System.Windows.Forms.GroupBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.DataBasesList = new System.Windows.Forms.ListBox();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерВыгрузкиБазДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менеджерЗагрузкиБазДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьСправкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoTimer = new System.Windows.Forms.Timer(this.components);
            this.NavigationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.InformationBox.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavigationBox
            // 
            this.NavigationBox.BackColor = System.Drawing.Color.White;
            this.NavigationBox.Controls.Add(this.pictureBox6);
            this.NavigationBox.Controls.Add(this.Watch);
            this.NavigationBox.Controls.Add(this.pictureBox5);
            this.NavigationBox.Controls.Add(this.Telnet);
            this.NavigationBox.Controls.Add(this.pictureBox4);
            this.NavigationBox.Controls.Add(this.InformationButton);
            this.NavigationBox.Controls.Add(this.pictureBox3);
            this.NavigationBox.Controls.Add(this.SettingsButton);
            this.NavigationBox.Controls.Add(this.pictureBox2);
            this.NavigationBox.Controls.Add(this.UsersButton);
            this.NavigationBox.Controls.Add(this.pictureBox1);
            this.NavigationBox.Controls.Add(this.StatusButton);
            this.NavigationBox.Location = new System.Drawing.Point(12, 37);
            this.NavigationBox.Name = "NavigationBox";
            this.NavigationBox.Size = new System.Drawing.Size(200, 229);
            this.NavigationBox.TabIndex = 1;
            this.NavigationBox.TabStop = false;
            this.NavigationBox.Text = "Управление";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::MicroBaseManager.Properties.Resources.watch;
            this.pictureBox6.Location = new System.Drawing.Point(16, 126);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(29, 28);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 13;
            this.pictureBox6.TabStop = false;
            // 
            // Watch
            // 
            this.Watch.BackColor = System.Drawing.Color.Transparent;
            this.Watch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Watch.FlatAppearance.BorderSize = 0;
            this.Watch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Watch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Watch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Watch.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Watch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Watch.Location = new System.Drawing.Point(39, 126);
            this.Watch.Name = "Watch";
            this.Watch.Size = new System.Drawing.Size(125, 28);
            this.Watch.TabIndex = 12;
            this.Watch.Text = "Слежение";
            this.Watch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Watch.UseVisualStyleBackColor = false;
            this.Watch.Click += new System.EventHandler(this.Watch_Click);
            this.Watch.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.Watch.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::MicroBaseManager.Properties.Resources.command_prompt_glossy1;
            this.pictureBox5.Location = new System.Drawing.Point(16, 161);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // Telnet
            // 
            this.Telnet.BackColor = System.Drawing.Color.Transparent;
            this.Telnet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Telnet.FlatAppearance.BorderSize = 0;
            this.Telnet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.Telnet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.Telnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Telnet.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Telnet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Telnet.Location = new System.Drawing.Point(39, 161);
            this.Telnet.Name = "Telnet";
            this.Telnet.Size = new System.Drawing.Size(125, 28);
            this.Telnet.TabIndex = 10;
            this.Telnet.Text = "Консоль";
            this.Telnet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Telnet.UseVisualStyleBackColor = false;
            this.Telnet.Click += new System.EventHandler(this.Telnet_Click);
            this.Telnet.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.Telnet.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MicroBaseManager.Properties.Resources.img_542910;
            this.pictureBox4.Location = new System.Drawing.Point(16, 92);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // InformationButton
            // 
            this.InformationButton.BackColor = System.Drawing.Color.Transparent;
            this.InformationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InformationButton.FlatAppearance.BorderSize = 0;
            this.InformationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.InformationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.InformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InformationButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InformationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InformationButton.Location = new System.Drawing.Point(39, 92);
            this.InformationButton.Name = "InformationButton";
            this.InformationButton.Size = new System.Drawing.Size(125, 28);
            this.InformationButton.TabIndex = 8;
            this.InformationButton.Text = "Информация";
            this.InformationButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InformationButton.UseVisualStyleBackColor = false;
            this.InformationButton.Click += new System.EventHandler(this.InformationButton_Click);
            this.InformationButton.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.InformationButton.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MicroBaseManager.Properties.Resources.settingsOn;
            this.pictureBox3.Location = new System.Drawing.Point(16, 195);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.Location = new System.Drawing.Point(39, 195);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(125, 28);
            this.SettingsButton.TabIndex = 6;
            this.SettingsButton.Text = "Конфигурация";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            this.SettingsButton.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MicroBaseManager.Properties.Resources.icons8_customer_50;
            this.pictureBox2.Location = new System.Drawing.Point(16, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // UsersButton
            // 
            this.UsersButton.BackColor = System.Drawing.Color.Transparent;
            this.UsersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UsersButton.FlatAppearance.BorderSize = 0;
            this.UsersButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.UsersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.UsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsersButton.Location = new System.Drawing.Point(39, 58);
            this.UsersButton.Name = "UsersButton";
            this.UsersButton.Size = new System.Drawing.Size(125, 28);
            this.UsersButton.TabIndex = 4;
            this.UsersButton.Text = "Пользователи";
            this.UsersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UsersButton.UseVisualStyleBackColor = false;
            this.UsersButton.Click += new System.EventHandler(this.UsersButton_Click);
            this.UsersButton.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.UsersButton.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MicroBaseManager.Properties.Resources.start;
            this.pictureBox1.Location = new System.Drawing.Point(16, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // StatusButton
            // 
            this.StatusButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StatusButton.FlatAppearance.BorderSize = 0;
            this.StatusButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.StatusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.StatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusButton.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusButton.Location = new System.Drawing.Point(39, 24);
            this.StatusButton.Name = "StatusButton";
            this.StatusButton.Size = new System.Drawing.Size(125, 28);
            this.StatusButton.TabIndex = 2;
            this.StatusButton.Text = "Статус сервера";
            this.StatusButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StatusButton.UseVisualStyleBackColor = true;
            this.StatusButton.Click += new System.EventHandler(this.StatusButton_Click);
            this.StatusButton.MouseEnter += new System.EventHandler(this.StatusButton_MouseEnter);
            this.StatusButton.MouseLeave += new System.EventHandler(this.StatusButton_MouseLeave);
            // 
            // InformationBox
            // 
            this.InformationBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InformationBox.BackColor = System.Drawing.Color.White;
            this.InformationBox.Controls.Add(this.SearchBox);
            this.InformationBox.Controls.Add(this.DataBasesList);
            this.InformationBox.Location = new System.Drawing.Point(12, 272);
            this.InformationBox.Name = "InformationBox";
            this.InformationBox.Size = new System.Drawing.Size(200, 347);
            this.InformationBox.TabIndex = 2;
            this.InformationBox.TabStop = false;
            this.InformationBox.Text = "Базы данных";
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(6, 28);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(185, 28);
            this.SearchBox.TabIndex = 1;
            this.SearchBox.Text = "Поиск...";
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // DataBasesList
            // 
            this.DataBasesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DataBasesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DataBasesList.FormattingEnabled = true;
            this.DataBasesList.ItemHeight = 20;
            this.DataBasesList.Location = new System.Drawing.Point(6, 55);
            this.DataBasesList.Name = "DataBasesList";
            this.DataBasesList.Size = new System.Drawing.Size(185, 272);
            this.DataBasesList.TabIndex = 0;
            this.DataBasesList.Click += new System.EventHandler(this.DataBasesList_Click);
            this.DataBasesList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DataBasesList_DrawItem);
            this.DataBasesList.DoubleClick += new System.EventHandler(this.DataBasesList_DoubleClick);
            // 
            // Tabs
            // 
            this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.Tabs.Location = new System.Drawing.Point(3, 3);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(648, 576);
            this.Tabs.TabIndex = 0;
            this.Tabs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Tabs_DrawItem);
            this.Tabs.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.Tabs_ControlRemoved);
            this.Tabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tabs_MouseDown);
            this.Tabs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tabs_MouseMove);
            this.Tabs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tabs_MouseUp);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.Tabs);
            this.MainPanel.Location = new System.Drawing.Point(218, 37);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(654, 582);
            this.MainPanel.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.обновитьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(884, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "Главное меню";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менеджерВыгрузкиБазДанныхToolStripMenuItem,
            this.менеджерЗагрузкиБазДанныхToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // менеджерВыгрузкиБазДанныхToolStripMenuItem
            // 
            this.менеджерВыгрузкиБазДанныхToolStripMenuItem.Name = "менеджерВыгрузкиБазДанныхToolStripMenuItem";
            this.менеджерВыгрузкиБазДанныхToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.менеджерВыгрузкиБазДанныхToolStripMenuItem.Text = "Менеджер выгрузки баз данных";
            // 
            // менеджерЗагрузкиБазДанныхToolStripMenuItem
            // 
            this.менеджерЗагрузкиБазДанныхToolStripMenuItem.Name = "менеджерЗагрузкиБазДанныхToolStripMenuItem";
            this.менеджерЗагрузкиБазДанныхToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.менеджерЗагрузкиБазДанныхToolStripMenuItem.Text = "Менеджер загрузки баз данных";
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
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // InfoTimer
            // 
            this.InfoTimer.Interval = 1000;
            this.InfoTimer.Tick += new System.EventHandler(this.InfoTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 631);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.InformationBox);
            this.Controls.Add(this.NavigationBox);
            this.MinimumSize = new System.Drawing.Size(900, 670);
            this.Name = "MainForm";
            this.Text = "MicroBase Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.NavigationBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.InformationBox.ResumeLayout(false);
            this.InformationBox.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox NavigationBox;
        private System.Windows.Forms.GroupBox InformationBox;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button StatusButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button UsersButton;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button InformationButton;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Telnet;
        private System.Windows.Forms.ListBox DataBasesList;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьСправкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Timer InfoTimer;
        private System.Windows.Forms.ToolStripMenuItem менеджерВыгрузкиБазДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менеджерЗагрузкиБазДанныхToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Button Watch;
    }
}