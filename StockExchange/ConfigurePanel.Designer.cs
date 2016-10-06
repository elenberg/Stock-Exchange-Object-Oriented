namespace StockExchange
{
    partial class ConfigurePanel
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
            this.accept = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.remove = new System.Windows.Forms.Button();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.StockBox = new System.Windows.Forms.ComboBox();
            this.update = new System.Windows.Forms.Button();
            this.CompareAgainst = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.CheckBox();
            this.selectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(230, 538);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(234, 34);
            this.accept.TabIndex = 2;
            this.accept.Text = "Accept";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Panel 1",
            "Panel 2",
            "Panel 3",
            "Panel 4",
            "Panel 5",
            "Panel 6"});
            this.comboBox1.Location = new System.Drawing.Point(230, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 37);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Select A Panel";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.Enabled = false;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Portfolio",
            "Stock Price",
            "Stock Volume"});
            this.comboBox2.Location = new System.Drawing.Point(230, 77);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(234, 37);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "Chart Type";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // remove
            // 
            this.remove.Enabled = false;
            this.remove.Location = new System.Drawing.Point(230, 490);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(234, 41);
            this.remove.TabIndex = 6;
            this.remove.Text = "Remove Panel";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // selectionPanel
            // 
            this.selectionPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectionPanel.Controls.Add(this.open);
            this.selectionPanel.Controls.Add(this.StockBox);
            this.selectionPanel.Controls.Add(this.update);
            this.selectionPanel.Controls.Add(this.CompareAgainst);
            this.selectionPanel.Enabled = false;
            this.selectionPanel.Location = new System.Drawing.Point(230, 136);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(234, 329);
            this.selectionPanel.TabIndex = 7;
            this.selectionPanel.Visible = false;
            // 
            // StockBox
            // 
            this.StockBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.StockBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.StockBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.StockBox.FormattingEnabled = true;
            this.StockBox.Location = new System.Drawing.Point(20, 201);
            this.StockBox.Name = "StockBox";
            this.StockBox.Size = new System.Drawing.Size(182, 37);
            this.StockBox.TabIndex = 4;
            this.StockBox.Text = "Stock Symbol";
            this.StockBox.SelectedIndexChanged += new System.EventHandler(this.StockBox_SelectedIndexChanged);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(20, 272);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(193, 44);
            this.update.TabIndex = 3;
            this.update.Text = "Update Panel";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // CompareAgainst
            // 
            this.CompareAgainst.AutoSize = true;
            this.CompareAgainst.Location = new System.Drawing.Point(16, 15);
            this.CompareAgainst.Name = "CompareAgainst";
            this.CompareAgainst.Size = new System.Drawing.Size(132, 20);
            this.CompareAgainst.TabIndex = 1;
            this.CompareAgainst.Text = "Compare Against";
            // 
            // open
            // 
            this.open.AutoSize = true;
            this.open.Location = new System.Drawing.Point(20, 53);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(196, 24);
            this.open.TabIndex = 5;
            this.open.Text = "Open and Close Prices";
            this.open.UseVisualStyleBackColor = true;
            // 
            // ConfigurePanel
            // 
            this.AcceptButton = this.accept;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 586);
            this.Controls.Add(this.selectionPanel);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.accept);
            this.Name = "ConfigurePanel";
            this.Text = "ConfigurePanel";
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Label CompareAgainst;
        private System.Windows.Forms.ComboBox StockBox;
        private System.Windows.Forms.CheckBox open;
    }
}