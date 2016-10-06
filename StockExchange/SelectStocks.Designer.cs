namespace StockExchange
{
    partial class SelectStocks
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
            this.button1 = new System.Windows.Forms.Button();
            this.StockList = new System.Windows.Forms.ListView();
            this.stockBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Track";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StockList
            // 
            this.StockList.CheckBoxes = true;
            this.StockList.Location = new System.Drawing.Point(25, 29);
            this.StockList.Name = "StockList";
            this.StockList.Size = new System.Drawing.Size(633, 514);
            this.StockList.TabIndex = 2;
            this.StockList.UseCompatibleStateImageBehavior = false;
            this.StockList.View = System.Windows.Forms.View.Details;
            this.StockList.SelectedIndexChanged += new System.EventHandler(this.StockList_SelectedIndexChanged);
            // 
            // stockBox
            // 
            this.stockBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.stockBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.stockBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.stockBox.FormattingEnabled = true;
            this.stockBox.Location = new System.Drawing.Point(40, 554);
            this.stockBox.Name = "stockBox";
            this.stockBox.Size = new System.Drawing.Size(183, 37);
            this.stockBox.TabIndex = 4;
            this.stockBox.Text = "Stock Symbol";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(250, 549);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 550);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 50);
            this.button2.TabIndex = 6;
            this.button2.Text = "Remove Checked";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 614);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stockBox);
            this.Controls.Add(this.StockList);
            this.Controls.Add(this.button1);
            this.Name = "SelectStocks";
            this.Text = "SelectStocks";
            this.Load += new System.EventHandler(this.SelectStocks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView StockList;
        private System.Windows.Forms.ComboBox stockBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}