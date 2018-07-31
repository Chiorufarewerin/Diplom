namespace MicroBaseManager.ClassesTabs
{
    partial class TabWatchDesigner
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
            this.WatchNotFound = new System.Windows.Forms.Label();
            this.EditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditPanel
            // 
            this.EditPanel.AutoScroll = true;
            this.EditPanel.Controls.Add(this.WatchNotFound);
            this.EditPanel.Location = new System.Drawing.Point(22, 9);
            this.EditPanel.MinimumSize = new System.Drawing.Size(640, 543);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(640, 543);
            this.EditPanel.TabIndex = 1;
            this.EditPanel.Resize += new System.EventHandler(this.EditPanel_Resize);
            // 
            // WatchNotFound
            // 
            this.WatchNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WatchNotFound.BackColor = System.Drawing.Color.Gainsboro;
            this.WatchNotFound.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WatchNotFound.Location = new System.Drawing.Point(3, 0);
            this.WatchNotFound.Name = "WatchNotFound";
            this.WatchNotFound.Size = new System.Drawing.Size(637, 543);
            this.WatchNotFound.TabIndex = 0;
            this.WatchNotFound.Text = "Переменные для слежки не выбраны";
            this.WatchNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabWatchDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.EditPanel);
            this.Name = "TabWatchDesigner";
            this.Text = "TabWatchDesigner";
            this.EditPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.Label WatchNotFound;
    }
}