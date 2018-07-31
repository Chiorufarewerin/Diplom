namespace MicroBaseManager.ClassesTabs
{
    partial class WatchVariable
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.VariableChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.VariableWatchBox = new System.Windows.Forms.GroupBox();
            this.StopWatch = new System.Windows.Forms.Button();
            this.BackColorSwitch = new System.Windows.Forms.PictureBox();
            this.ForeColorSwitch = new System.Windows.Forms.PictureBox();
            this.PeriodBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorDialogBox = new System.Windows.Forms.ColorDialog();
            this.Updater = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VariableChart)).BeginInit();
            this.VariableWatchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColorSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForeColorSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).BeginInit();
            this.SuspendLayout();
            // 
            // VariableChart
            // 
            this.VariableChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableChart.BackColor = System.Drawing.Color.Transparent;
            this.VariableChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VariableChart.BorderlineWidth = 0;
            this.VariableChart.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.VariableChart.BorderSkin.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            this.VariableChart.BorderSkin.BackImageTransparentColor = System.Drawing.Color.Yellow;
            this.VariableChart.BorderSkin.BackSecondaryColor = System.Drawing.Color.Yellow;
            this.VariableChart.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IsMarksNextToAxis = false;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisX.LabelAutoFitStyle = System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont;
            chartArea1.AxisX.LabelStyle.Format = "hh:mm:ss";
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea1.AxisY.IsMarksNextToAxis = false;
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkDownwardDiagonal;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.VariableChart.ChartAreas.Add(chartArea1);
            this.VariableChart.Location = new System.Drawing.Point(8, 114);
            this.VariableChart.Margin = new System.Windows.Forms.Padding(4);
            this.VariableChart.Name = "VariableChart";
            this.VariableChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = System.Drawing.Color.Indigo;
            series1.EmptyPointStyle.BorderWidth = 0;
            series1.EmptyPointStyle.LabelBorderWidth = 0;
            series1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.IsVisibleInLegend = false;
            series1.LabelBorderWidth = 0;
            series1.MarkerBorderWidth = 0;
            series1.MarkerSize = 0;
            series1.Name = "VariableSerie";
            series1.SmartLabelStyle.CalloutLineWidth = 0;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.VariableChart.Series.Add(series1);
            this.VariableChart.Size = new System.Drawing.Size(593, 124);
            this.VariableChart.TabIndex = 1;
            // 
            // VariableWatchBox
            // 
            this.VariableWatchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableWatchBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.VariableWatchBox.Controls.Add(this.CurrentValueLabel);
            this.VariableWatchBox.Controls.Add(this.label3);
            this.VariableWatchBox.Controls.Add(this.StopWatch);
            this.VariableWatchBox.Controls.Add(this.BackColorSwitch);
            this.VariableWatchBox.Controls.Add(this.ForeColorSwitch);
            this.VariableWatchBox.Controls.Add(this.PeriodBox);
            this.VariableWatchBox.Controls.Add(this.label2);
            this.VariableWatchBox.Controls.Add(this.label1);
            this.VariableWatchBox.Controls.Add(this.VariableChart);
            this.VariableWatchBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VariableWatchBox.Location = new System.Drawing.Point(18, 4);
            this.VariableWatchBox.Margin = new System.Windows.Forms.Padding(4);
            this.VariableWatchBox.Name = "VariableWatchBox";
            this.VariableWatchBox.Padding = new System.Windows.Forms.Padding(4);
            this.VariableWatchBox.Size = new System.Drawing.Size(609, 296);
            this.VariableWatchBox.TabIndex = 2;
            this.VariableWatchBox.TabStop = false;
            this.VariableWatchBox.Text = "Переменная {0} из базы данных {1}";
            // 
            // StopWatch
            // 
            this.StopWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopWatch.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopWatch.Location = new System.Drawing.Point(475, 23);
            this.StopWatch.Name = "StopWatch";
            this.StopWatch.Size = new System.Drawing.Size(127, 62);
            this.StopWatch.TabIndex = 3;
            this.StopWatch.Text = "Перестать следить";
            this.StopWatch.UseVisualStyleBackColor = true;
            this.StopWatch.Click += new System.EventHandler(this.StopWatch_Click);
            // 
            // BackColorSwitch
            // 
            this.BackColorSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BackColorSwitch.Location = new System.Drawing.Point(359, 58);
            this.BackColorSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.BackColorSwitch.Name = "BackColorSwitch";
            this.BackColorSwitch.Size = new System.Drawing.Size(110, 26);
            this.BackColorSwitch.TabIndex = 6;
            this.BackColorSwitch.TabStop = false;
            this.BackColorSwitch.Click += new System.EventHandler(this.BackColorSwitch_Click);
            // 
            // ForeColorSwitch
            // 
            this.ForeColorSwitch.BackColor = System.Drawing.Color.Indigo;
            this.ForeColorSwitch.Location = new System.Drawing.Point(236, 58);
            this.ForeColorSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.ForeColorSwitch.Name = "ForeColorSwitch";
            this.ForeColorSwitch.Size = new System.Drawing.Size(114, 26);
            this.ForeColorSwitch.TabIndex = 5;
            this.ForeColorSwitch.TabStop = false;
            this.ForeColorSwitch.Click += new System.EventHandler(this.ForeColorSwitch_Click);
            // 
            // PeriodBox
            // 
            this.PeriodBox.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PeriodBox.Location = new System.Drawing.Point(236, 24);
            this.PeriodBox.Margin = new System.Windows.Forms.Padding(4);
            this.PeriodBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PeriodBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.PeriodBox.Name = "PeriodBox";
            this.PeriodBox.Size = new System.Drawing.Size(232, 28);
            this.PeriodBox.TabIndex = 4;
            this.PeriodBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PeriodBox.ValueChanged += new System.EventHandler(this.PeriodBox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выбрать цвет: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Период обновления (мс):";
            // 
            // Updater
            // 
            this.Updater.Interval = 1000;
            this.Updater.Tick += new System.EventHandler(this.Updater_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Текущее значение:";
            // 
            // CurrentValueLabel
            // 
            this.CurrentValueLabel.AutoSize = true;
            this.CurrentValueLabel.Location = new System.Drawing.Point(232, 85);
            this.CurrentValueLabel.Name = "CurrentValueLabel";
            this.CurrentValueLabel.Size = new System.Drawing.Size(31, 21);
            this.CurrentValueLabel.TabIndex = 8;
            this.CurrentValueLabel.Text = "{0}";
            // 
            // WatchVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.VariableWatchBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WatchVariable";
            this.Size = new System.Drawing.Size(633, 310);
            ((System.ComponentModel.ISupportInitialize)(this.VariableChart)).EndInit();
            this.VariableWatchBox.ResumeLayout(false);
            this.VariableWatchBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackColorSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForeColorSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PeriodBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart VariableChart;
        private System.Windows.Forms.GroupBox VariableWatchBox;
        private System.Windows.Forms.PictureBox BackColorSwitch;
        private System.Windows.Forms.PictureBox ForeColorSwitch;
        private System.Windows.Forms.NumericUpDown PeriodBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog ColorDialogBox;
        private System.Windows.Forms.Timer Updater;
        private System.Windows.Forms.Button StopWatch;
        private System.Windows.Forms.Label CurrentValueLabel;
        private System.Windows.Forms.Label label3;
    }
}
