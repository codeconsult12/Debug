namespace SmartDeviceProject1
{
    partial class DeviceManagement
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
            this.SaveMenu = new System.Windows.Forms.MenuItem();
            this.ResetMenu = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LocationCombo = new System.Windows.Forms.ComboBox();
            this.TxtServiceURL = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDeviceId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDeviceName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TimeZoneCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.SaveMenu);
            this.mainMenu1.MenuItems.Add(this.ResetMenu);
            // 
            // SaveMenu
            // 
            this.SaveMenu.Text = "Save";
            this.SaveMenu.Click += new System.EventHandler(this.SaveMenu_Click);
            // 
            // ResetMenu
            // 
            this.ResetMenu.Text = "Reset";
            this.ResetMenu.Click += new System.EventHandler(this.BackMenu_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.Text = "Service URL";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.Text = "Company";
            // 
            // CompanyCombo
            // 
            this.CompanyCombo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.CompanyCombo.Location = new System.Drawing.Point(77, 47);
            this.CompanyCombo.Name = "CompanyCombo";
            this.CompanyCombo.Size = new System.Drawing.Size(159, 20);
            this.CompanyCombo.TabIndex = 4;
            this.CompanyCombo.SelectedIndexChanged += new System.EventHandler(this.CompanyCombo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.Text = "Location";
            // 
            // LocationCombo
            // 
            this.LocationCombo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.LocationCombo.Location = new System.Drawing.Point(77, 85);
            this.LocationCombo.Name = "LocationCombo";
            this.LocationCombo.Size = new System.Drawing.Size(159, 20);
            this.LocationCombo.TabIndex = 7;
            this.LocationCombo.TextChanged += new System.EventHandler(this.LocationCombo_SelectedIndexChanged);
            // 
            // TxtServiceURL
            // 
            this.TxtServiceURL.AcceptsReturn = true;
            this.TxtServiceURL.AcceptsTab = true;
            this.TxtServiceURL.Location = new System.Drawing.Point(77, 12);
            this.TxtServiceURL.Multiline = true;
            this.TxtServiceURL.Name = "TxtServiceURL";
            this.TxtServiceURL.Size = new System.Drawing.Size(159, 21);
            this.TxtServiceURL.TabIndex = 8;
            this.TxtServiceURL.Text = "http://IP/PDTService/Services.asmx";
            this.TxtServiceURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(2, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "Dev. Id";
            // 
            // TxtDeviceId
            // 
            this.TxtDeviceId.Location = new System.Drawing.Point(77, 123);
            this.TxtDeviceId.Name = "TxtDeviceId";
            this.TxtDeviceId.Size = new System.Drawing.Size(159, 21);
            this.TxtDeviceId.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(2, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.Text = "Dev. Name";
            // 
            // TxtDeviceName
            // 
            this.TxtDeviceName.Location = new System.Drawing.Point(77, 160);
            this.TxtDeviceName.Name = "TxtDeviceName";
            this.TxtDeviceName.Size = new System.Drawing.Size(159, 21);
            this.TxtDeviceName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(2, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.Text = "Time Zone";
            // 
            // TimeZoneCombo
            // 
            this.TimeZoneCombo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.TimeZoneCombo.Location = new System.Drawing.Point(77, 197);
            this.TimeZoneCombo.Name = "TimeZoneCombo";
            this.TimeZoneCombo.Size = new System.Drawing.Size(160, 20);
            this.TimeZoneCombo.TabIndex = 20;
            // 
            // DeviceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.TimeZoneCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtDeviceName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtDeviceId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtServiceURL);
            this.Controls.Add(this.LocationCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompanyCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "DeviceManagement";
            this.Text = "DeviceManagement";
            this.Load += new System.EventHandler(this.DeviceManagement_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DeviceManagement_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CompanyCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox LocationCombo;
        
        private System.Windows.Forms.TextBox TxtServiceURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDeviceId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDeviceName;
        private System.Windows.Forms.MenuItem SaveMenu;
        private System.Windows.Forms.MenuItem ResetMenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TimeZoneCombo;
    }
}