namespace SmartDeviceProject1
{
    partial class PriceChecker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ProductName = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.LabelCost = new System.Windows.Forms.Label();
            this.labelSale = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.labeldicountAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(74, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.Text = "Barcode";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Check";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductName
            // 
            this.ProductName.Location = new System.Drawing.Point(93, 81);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(126, 20);
            this.ProductName.Text = "-";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(93, 98);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(126, 20);
            this.Description.Text = "-";
            // 
            // LabelCost
            // 
            this.LabelCost.Location = new System.Drawing.Point(91, 120);
            this.LabelCost.Name = "LabelCost";
            this.LabelCost.Size = new System.Drawing.Size(129, 20);
            this.LabelCost.Text = "0.00";
            // 
            // labelSale
            // 
            this.labelSale.Location = new System.Drawing.Point(91, 141);
            this.labelSale.Name = "labelSale";
            this.labelSale.Size = new System.Drawing.Size(129, 20);
            this.labelSale.Text = "0.00";
            // 
            // labelDiscount
            // 
            this.labelDiscount.Location = new System.Drawing.Point(91, 162);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(129, 20);
            this.labelDiscount.Text = "0.00";
            // 
            // labeldicountAmount
            // 
            this.labeldicountAmount.Location = new System.Drawing.Point(91, 183);
            this.labeldicountAmount.Name = "labeldicountAmount";
            this.labeldicountAmount.Size = new System.Drawing.Size(129, 20);
            this.labeldicountAmount.Text = "0.00";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(2, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.Text = "Product";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(2, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.Text = "Description";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(2, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.Text = "Cost Price";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(2, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 17);
            this.label11.Text = "Sale Price";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(2, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.Text = "Disc. (%)";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(2, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 27);
            this.label13.Text = "Disc. Amt.";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(168, 248);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(72, 20);
            this.Reset.TabIndex = 13;
            this.Reset.Text = "Reset";
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(76, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 20);
            this.button2.TabIndex = 27;
            this.button2.Text = "Logout";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(-1, 248);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 20);
            this.button3.TabIndex = 28;
            this.button3.Text = "Back";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PriceChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labeldicountAmount);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.labelSale);
            this.Controls.Add(this.LabelCost);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Menu = this.mainMenu1;
            this.Name = "PriceChecker";
            this.Text = "PriceChecker";
            this.Load += new System.EventHandler(this.PriceChecker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ProductName;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Label LabelCost;
        private System.Windows.Forms.Label labelSale;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.Label labeldicountAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}