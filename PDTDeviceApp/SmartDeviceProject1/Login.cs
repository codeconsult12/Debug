using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using SmartDeviceProject1.DBClasses;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Web.Services;
using SmartDeviceProject1.DBClasses;
using SmartDeviceProject1.WebService;
using System.Xml;

namespace SmartDeviceProject1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

    
            try
            {
                if (File.Exists("Config.xml"))
                {
                    XmlTextReader textReader = new XmlTextReader("Config.xml");
                    textReader.Read();

                    string Location = "";
                    // If the node has value  
                    while (textReader.Read())
                    {
                        if (textReader.IsStartElement())
                        {
                            //return only when you have START tag  
                            switch (textReader.Name.ToString())
                            {

                                case "DeviceName":
                                    LbldeviceName.Text = textReader.ReadString();
                                    break;
                                case "CompanyName":
                                    LblCompanyName.Text = textReader.ReadString();
                                    break;
                                case "LocationId":
                                    Location += textReader.ReadString()+"-";
                                    break;
                                case "LocationName":
                                    Location += textReader.ReadString();
                                    break;
                          
                            }
                        }
                        // Move to fist element  
                        textReader.MoveToElement();



                    }
                    if (Location != "")
                    {


                        LblLocation.Text = Location;
                    }

                }
                else
                {
                    MessageBox.Show("Device not registered! Please Register your device first.");
                    DeviceManagement dm = new DeviceManagement();
                    dm.ShowDialog();
                    if (File.Exists("Config.xml") && dm.issaved == true)
                    {
                        string Location = "";
                        XmlTextReader textReader = new XmlTextReader("Config.xml");
                        textReader.Read();
                        // If the node has value  
                        while (textReader.Read())
                        {
                            if (textReader.IsStartElement())
                            {
                                //return only when you have START tag  
                                switch (textReader.Name.ToString())
                                {

                                    case "DeviceName":
                                        LbldeviceName.Text = textReader.ReadString();
                                        break;
                                    case "CompanyName":
                                        LblCompanyName.Text = textReader.ReadString();
                                        break;
                                    case "LocationId":
                                        Location += textReader.ReadString()+"-";
                                        break;
                                    case "LocationName":
                                        Location += textReader.ReadString();
                                        break;

                                }
                            }
                            // Move to fist element  
                            textReader.MoveToElement();



                        }
                        if (Location != "")
                        {


                            LblLocation.Text = Location;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Device couldn't registered! Contact your IT administrator");
                        Application.Exit();
                    }
                }
                DAL d = new DAL();
             LblIP.Text=d.GETIPAddress();
            }
            catch (Exception ex)
            {
                LblIP.Text = "Not Found";
            }
        }


        public bool CheckInternetConnection()
        {
            string url = "http://www.google.com";
            try
            {
                System.Net.WebRequest myRequest = System.Net.WebRequest.Create(url);
                System.Net.WebResponse myResponse = myRequest.GetResponse();

            }
            catch (System.Net.WebException)
            {
                return false;
            }

            return true;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginLogic();
        }
        private void LoginLogic()
        {
            Property p = new Property();
            DAL d = new DAL();
            DataTable item;
            Service service = new Service();
            service.Url = p.ServiceURL.Replace("\r\n", "");
            string[] str;
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (string.IsNullOrEmpty(this.txtUser.Text.Trim()))
                    {
                        this.txtUser.Focus();
                        throw new Exception("Invalid user id");
                    }

                    try
                    {

                        str = new string[] { "HHT_User_Setup_3000", p.CompanyId.ToString(), d.FormatString(this.txtUser.Text) };
                        item = service.GetData(str).Tables[0];
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                    if (item.Rows.Count == 0)
                    {
                        this.txtUser.SelectAll();
                        this.txtUser.Focus();
                        throw new Exception("User does not exist");
                    }
                    if (item.Rows[0]["Password"].ToString() != this.txtPassword.Text.Trim())
                    {
                        this.txtPassword.SelectAll();
                        this.txtPassword.Focus();
                        throw new Exception("Invalid password");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error! " + ex.Message);
                    Cursor.Current = Cursors.Default;
                    return;

                }
                List<UserRights> URData = new List<UserRights>();
                try
                {
                    URData = d.GetUserRights(txtUser.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ! " + ex.Message);
                    return;
                }

                if (URData == null)
                {
                    MessageBox.Show("Couldn't connect web service!");
                    return;
                }

                Cursor.Current = Cursors.Default;
                MainForm mf = new MainForm();

                mf.userrightdata = URData;
                mf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message);
            }
        }


        private void OnKeyDownHandlerUserId(Object sender, KeyEventArgs e)
        {
          
                try
                {
                    if (e.KeyValue == '\r')
                    {

                        if (!string.IsNullOrEmpty(this.txtUser.Text))
                        {

                            txtPassword.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Username is empty!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            
            
        }
        private void OnKeyDownHandlerPassword(Object sender, KeyEventArgs e)
        {
            
                try
                {
                    if (e.KeyValue == '\r')
                    {

                        if (!string.IsNullOrEmpty(this.txtPassword.Text))
                        {

                            LoginLogic();
                        }
                        else
                        {
                            MessageBox.Show("Password is empty!");
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            

        }

        private void Offline_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            Offlinelbl.Text = "Online";
        }

        private void Online_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Visible = false;
            Offlinelbl.Text = "Offline";
        }

    

        private void LoginMenu_Click(object sender, EventArgs e)
        {
            LoginLogic();
        }

        private void CloseMenu_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}