namespace TransmitterCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UploadInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RadioTransmitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartSignalTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TransmitterTimer = new System.Windows.Forms.Timer(this.components);
            this.radioTransmitter1 = new TransmitterCalculator.Controls.RadioTransmitter();
            this.transmitter3 = new TransmitterCalculator.Controls.Transmitter();
            this.transmitter2 = new TransmitterCalculator.Controls.Transmitter();
            this.transmitter1 = new TransmitterCalculator.Controls.Transmitter();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.RadioTransmitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1434, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadInputToolStripMenuItem,
            this.SaveResultToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // UploadInputToolStripMenuItem
            // 
            this.UploadInputToolStripMenuItem.Name = "UploadInputToolStripMenuItem";
            this.UploadInputToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.UploadInputToolStripMenuItem.Text = "Загрузить данные";
            this.UploadInputToolStripMenuItem.Click += new System.EventHandler(this.UploadInputToolStripMenuItem_Click);
            // 
            // SaveResultToolStripMenuItem
            // 
            this.SaveResultToolStripMenuItem.Name = "SaveResultToolStripMenuItem";
            this.SaveResultToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.SaveResultToolStripMenuItem.Text = "Сохранить результат";
            this.SaveResultToolStripMenuItem.Click += new System.EventHandler(this.SaveResultToolStripMenuItem_Click);
            // 
            // RadioTransmitterToolStripMenuItem
            // 
            this.RadioTransmitterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartSignalTranslationToolStripMenuItem});
            this.RadioTransmitterToolStripMenuItem.Name = "RadioTransmitterToolStripMenuItem";
            this.RadioTransmitterToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.RadioTransmitterToolStripMenuItem.Text = "Радиопердатчик";
            // 
            // StartSignalTranslationToolStripMenuItem
            // 
            this.StartSignalTranslationToolStripMenuItem.Name = "StartSignalTranslationToolStripMenuItem";
            this.StartSignalTranslationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.StartSignalTranslationToolStripMenuItem.Text = "Начать отправку сигнала";
            this.StartSignalTranslationToolStripMenuItem.Click += new System.EventHandler(this.StartSignalTranslationToolStripMenuItem_Click);
            // 
            // TransmitterTimer
            // 
            this.TransmitterTimer.Interval = 1000;
            // 
            // radioTransmitter1
            // 
            this.radioTransmitter1.BackColor = System.Drawing.Color.Lime;
            this.radioTransmitter1.Location = new System.Drawing.Point(587, 406);
            this.radioTransmitter1.Name = "radioTransmitter1";
            this.radioTransmitter1.Size = new System.Drawing.Size(21, 24);
            this.radioTransmitter1.TabIndex = 3;
            // 
            // transmitter3
            // 
            this.transmitter3.BackColor = System.Drawing.SystemColors.Desktop;
            this.transmitter3.Location = new System.Drawing.Point(757, 274);
            this.transmitter3.Name = "transmitter3";
            this.transmitter3.Size = new System.Drawing.Size(15, 20);
            this.transmitter3.TabIndex = 2;
            // 
            // transmitter2
            // 
            this.transmitter2.BackColor = System.Drawing.SystemColors.Desktop;
            this.transmitter2.Location = new System.Drawing.Point(575, 274);
            this.transmitter2.Name = "transmitter2";
            this.transmitter2.Size = new System.Drawing.Size(15, 20);
            this.transmitter2.TabIndex = 1;
            // 
            // transmitter1
            // 
            this.transmitter1.BackColor = System.Drawing.SystemColors.Desktop;
            this.transmitter1.Location = new System.Drawing.Point(448, 275);
            this.transmitter1.Name = "transmitter1";
            this.transmitter1.Size = new System.Drawing.Size(15, 20);
            this.transmitter1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 961);
            this.Controls.Add(this.radioTransmitter1);
            this.Controls.Add(this.transmitter3);
            this.Controls.Add(this.transmitter2);
            this.Controls.Add(this.transmitter1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Transmitter transmitter1;
        private Controls.Transmitter transmitter2;
        private Controls.Transmitter transmitter3;
        private Controls.RadioTransmitter radioTransmitter1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveResultToolStripMenuItem;
        private System.Windows.Forms.Timer TransmitterTimer;
        private System.Windows.Forms.ToolStripMenuItem UploadInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RadioTransmitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartSignalTranslationToolStripMenuItem;
    }
}

