namespace StockExchange
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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.iplabel = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.topLeft = new System.Windows.Forms.Panel();
            this.TopMiddle = new System.Windows.Forms.Panel();
            this.topRight = new System.Windows.Forms.Panel();
            this.bottomLeft = new System.Windows.Forms.Panel();
            this.bottomMiddle = new System.Windows.Forms.Panel();
            this.bottomRight = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectStocksToTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurePanelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HeaderPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderPanel.Controls.Add(this.button1);
            this.HeaderPanel.Controls.Add(this.portBox);
            this.HeaderPanel.Controls.Add(this.portLabel);
            this.HeaderPanel.Controls.Add(this.iplabel);
            this.HeaderPanel.Controls.Add(this.ipAddress);
            this.HeaderPanel.Location = new System.Drawing.Point(16, 47);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1505, 62);
            this.HeaderPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1378, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 33);
            this.button1.TabIndex = 5;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // portBox
            // 
            this.portBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.portBox.Location = new System.Drawing.Point(1264, 13);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(97, 30);
            this.portBox.TabIndex = 0;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(1216, 20);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(42, 20);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Port:";
            // 
            // iplabel
            // 
            this.iplabel.AutoSize = true;
            this.iplabel.Location = new System.Drawing.Point(917, 20);
            this.iplabel.Name = "iplabel";
            this.iplabel.Size = new System.Drawing.Size(91, 20);
            this.iplabel.TabIndex = 1;
            this.iplabel.Text = "IP Address:";
            // 
            // ipAddress
            // 
            this.ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ipAddress.Location = new System.Drawing.Point(1014, 13);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(183, 30);
            this.ipAddress.TabIndex = 0;
            // 
            // topLeft
            // 
            this.topLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topLeft.Location = new System.Drawing.Point(16, 126);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(483, 421);
            this.topLeft.TabIndex = 1;
            // 
            // TopMiddle
            // 
            this.TopMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TopMiddle.Location = new System.Drawing.Point(515, 126);
            this.TopMiddle.Name = "TopMiddle";
            this.TopMiddle.Size = new System.Drawing.Size(501, 421);
            this.TopMiddle.TabIndex = 2;
            // 
            // topRight
            // 
            this.topRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.topRight.Location = new System.Drawing.Point(1031, 126);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(490, 421);
            this.topRight.TabIndex = 2;
            // 
            // bottomLeft
            // 
            this.bottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomLeft.Location = new System.Drawing.Point(16, 584);
            this.bottomLeft.Name = "bottomLeft";
            this.bottomLeft.Size = new System.Drawing.Size(483, 440);
            this.bottomLeft.TabIndex = 2;
            // 
            // bottomMiddle
            // 
            this.bottomMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomMiddle.Location = new System.Drawing.Point(515, 584);
            this.bottomMiddle.Name = "bottomMiddle";
            this.bottomMiddle.Size = new System.Drawing.Size(501, 440);
            this.bottomMiddle.TabIndex = 2;
            // 
            // bottomRight
            // 
            this.bottomRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bottomRight.Location = new System.Drawing.Point(1031, 584);
            this.bottomRight.Name = "bottomRight";
            this.bottomRight.Size = new System.Drawing.Size(490, 440);
            this.bottomRight.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(74, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.selectStocksToTrackToolStripMenuItem,
            this.configurePanelsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1533, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromCSVToolStripMenuItem,
            this.writeToCSVToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // loadFromCSVToolStripMenuItem
            // 
            this.loadFromCSVToolStripMenuItem.Name = "loadFromCSVToolStripMenuItem";
            this.loadFromCSVToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.loadFromCSVToolStripMenuItem.Text = "Load from CSV";
            this.loadFromCSVToolStripMenuItem.Click += new System.EventHandler(this.loadFromCSVToolStripMenuItem_Click);
            // 
            // writeToCSVToolStripMenuItem
            // 
            this.writeToCSVToolStripMenuItem.Name = "writeToCSVToolStripMenuItem";
            this.writeToCSVToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.writeToCSVToolStripMenuItem.Text = "Write to CSV";
            this.writeToCSVToolStripMenuItem.Click += new System.EventHandler(this.writeToCSVToolStripMenuItem_Click);
            // 
            // selectStocksToTrackToolStripMenuItem
            // 
            this.selectStocksToTrackToolStripMenuItem.Name = "selectStocksToTrackToolStripMenuItem";
            this.selectStocksToTrackToolStripMenuItem.Size = new System.Drawing.Size(192, 29);
            this.selectStocksToTrackToolStripMenuItem.Text = "Select Stocks to Track";
            this.selectStocksToTrackToolStripMenuItem.Click += new System.EventHandler(this.selectStocksToTrackToolStripMenuItem_Click);
            // 
            // configurePanelsToolStripMenuItem
            // 
            this.configurePanelsToolStripMenuItem.Name = "configurePanelsToolStripMenuItem";
            this.configurePanelsToolStripMenuItem.Size = new System.Drawing.Size(156, 29);
            this.configurePanelsToolStripMenuItem.Text = "Configure Panels";
            this.configurePanelsToolStripMenuItem.Click += new System.EventHandler(this.configurePanelsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 1036);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.bottomRight);
            this.Controls.Add(this.bottomMiddle);
            this.Controls.Add(this.bottomLeft);
            this.Controls.Add(this.topRight);
            this.Controls.Add(this.TopMiddle);
            this.Controls.Add(this.topLeft);
            this.Controls.Add(this.HeaderPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "StockExchange";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel topLeft;
        private System.Windows.Forms.Panel TopMiddle;
        private System.Windows.Forms.Panel topRight;
        private System.Windows.Forms.Panel bottomLeft;
        private System.Windows.Forms.Panel bottomMiddle;
        private System.Windows.Forms.Panel bottomRight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectStocksToTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurePanelsToolStripMenuItem;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label iplabel;
        private System.Windows.Forms.TextBox ipAddress;
        private System.Windows.Forms.Button button1;
    }
}

