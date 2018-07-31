namespace MicroBaseManager
{
    partial class TestConnectionForm
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
            this.TimerForBar = new System.Windows.Forms.Timer(this.components);
            this.HostPortLabel = new System.Windows.Forms.Label();
            this.ProgressBarConnection = new MicroBaseManager.TestConnectionForm.NewProgressBar();
            this.TestConnectionLabel = new System.Windows.Forms.Label();
            this.TimerForConnect = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimerForBar
            // 
            this.TimerForBar.Enabled = true;
            this.TimerForBar.Tick += new System.EventHandler(this.TimerForBar_Tick);
            // 
            // HostPortLabel
            // 
            this.HostPortLabel.AutoSize = true;
            this.HostPortLabel.ForeColor = System.Drawing.Color.White;
            this.HostPortLabel.Location = new System.Drawing.Point(12, 50);
            this.HostPortLabel.Name = "HostPortLabel";
            this.HostPortLabel.Size = new System.Drawing.Size(90, 20);
            this.HostPortLabel.TabIndex = 2;
            this.HostPortLabel.Text = "127.0.0.1:23";
            // 
            // ProgressBarConnection
            // 
            this.ProgressBarConnection.ForeColor = System.Drawing.Color.Lime;
            this.ProgressBarConnection.Location = new System.Drawing.Point(12, 86);
            this.ProgressBarConnection.Maximum = 50;
            this.ProgressBarConnection.Name = "ProgressBarConnection";
            this.ProgressBarConnection.Size = new System.Drawing.Size(392, 23);
            this.ProgressBarConnection.Step = 1;
            this.ProgressBarConnection.TabIndex = 1;
            // 
            // TestConnectionLabel
            // 
            this.TestConnectionLabel.AutoSize = true;
            this.TestConnectionLabel.ForeColor = System.Drawing.Color.White;
            this.TestConnectionLabel.Location = new System.Drawing.Point(112, 20);
            this.TestConnectionLabel.Name = "TestConnectionLabel";
            this.TestConnectionLabel.Size = new System.Drawing.Size(192, 20);
            this.TestConnectionLabel.TabIndex = 0;
            this.TestConnectionLabel.Text = "Проверка подключения: ";
            // 
            // TimerForConnect
            // 
            this.TimerForConnect.Enabled = true;
            this.TimerForConnect.Interval = 2000;
            this.TimerForConnect.Tick += new System.EventHandler(this.TimerForConnect_Tick);
            // 
            // TestConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 127);
            this.Controls.Add(this.HostPortLabel);
            this.Controls.Add(this.ProgressBarConnection);
            this.Controls.Add(this.TestConnectionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TestConnectionForm";
            this.Text = "Проверка подключения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestConnectionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestConnectionLabel;
        private System.Windows.Forms.Label HostPortLabel;
        private System.Windows.Forms.Timer TimerForBar;
        private System.Windows.Forms.Timer TimerForConnect;
        private TestConnectionForm.NewProgressBar ProgressBarConnection;
    }
}