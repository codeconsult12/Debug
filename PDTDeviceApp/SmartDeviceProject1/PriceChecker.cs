using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Web;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using SmartDeviceProject1.WebService;

namespace SmartDeviceProject1
{
    public partial class PriceChecker : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        DAL dal = new DAL();
        Property p = new Property();
        private bool m_bIsItemValidated;
        private DataTable m_dtItem;

     
        static bool InternetConnected
        {
            get
            {
                int Description = 0;
                return InternetGetConnectedState(out Description, 0);
            }
        }
        public PriceChecker()
        {
            InitializeComponent();
        
     

          
          
        }

        public static bool WebRequestTest()
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


        private void OnKeyDownHandlerItemCode(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyValue == '\r')
                    {
                        this.ItemCode.Text=this.ItemCode.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(this.ItemCode.Text))
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(this.ItemCode.Text);
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void OnPaste(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.Control == true && e.KeyCode == Keys.V)
                    {
                        IDataObject ClipData = System.Windows.Forms.Clipboard.GetDataObject();
                        
                        if (ClipData.GetDataPresent(DataFormats.Text))
                        {
                            string s = System.Windows.Forms.Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                            Barcode.Text = s;
                        }
                    }
                 
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void OnKeyDownHandler(Object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (e.KeyValue == '\r')
                    {
                        this.Barcode.Text=this.Barcode.Text.Trim().ToUpper();
                        if (!string.IsNullOrEmpty(this.Barcode.Text))
                        {
                            Application.DoEvents();
                            Cursor.Current = Cursors.WaitCursor;
                            this.GetItemDetail(string.Empty);
                        }
                    }
                }
                catch (Exception exception)
                {
                  MessageBox.Show( exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

       

        private void Reset_Click(object sender, EventArgs e)
        {
            resetform();
        }
        public void resetform()
        {
            Barcode.Text = "";
            ItemCode.Text = "";
            CostPrice.Text = "";
            SalePrice.Text = "";
            Description.Text = "";
            Vendor.Text = "";
            PriceDll.Text = "";
            ComboBoxUnit.Refresh();
            ComboBoxUnit.DataSource = null;
            ComboBoxUnit.Items.Clear();

        }

        private void PriceChecker_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Close();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            resetform();
        }

        private void Barcode_TextChanged(object sender, EventArgs e)
        {

        }
        private void cmbUOM_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if ((!this.m_bIsItemValidated ? false : (int)this.ComboBoxUnit.Items.Count == 1))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Service service = new Service();
                        try
                        {
                            service.Url = p.ServiceURL.ToString();
                            string[] str = new string[] { "HHT_Barcodes_3000", p.CompanyId.ToString(), p.LocationId.ToString(), string.Empty, dal.FormatString(this.ItemCode.Text.ToString()) };
                            this.m_dtItem = service.GetData(str).Tables[0];
                            if (this.m_dtItem.Rows.Count > 1)
                            {
                                ComboBoxUnit.DisplayMember="UOM";
                                ComboBoxUnit.ValueMember = "UOM";
                                ComboBoxUnit.DataSource = m_dtItem;
                                //this.cmbUOM.set_StringData((
                                //    from r in this.m_dtItem.AsEnumerable()
                                //    select r.Field<string>("UOM")).ToArray<string>());
                            }
                        }
                        finally
                        {
                            if (service != null)
                            {
                                ((IDisposable)service).Dispose();
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void ComboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (this.ComboBoxUnit.SelectedIndex > -1 && this.m_dtItem !=null)
                    {
                        DataRow dataRow = this.m_dtItem.Select(string.Format("[UOM] = '{0}'", this.ComboBoxUnit.Text))[0];
                        this.Barcode.Text=(string)dataRow["Barcode"];
                        this.ItemCode.Text=(string)dataRow["Itemcode"];
                        this.SetItemDetail(dataRow);
                        
                 
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error! " + exception.Message);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void GetItemDetail(string Itemcode)
        {
            
            DataTable item;
            Service service;
            string[] str;
            try
            {
                string empty = string.Empty;
                DataRow dataRow = null;
                if (Itemcode.Length == 0)
                {
                    empty = (this.Barcode.Text.Length != 14 || !(this.Barcode.Text.Substring(0, 3) == "990") ? this.Barcode.Text : string.Format("{0}00000", this.Barcode.Text.Substring(0, 9)));
                    service = new Service();
                    try
                    {
                        service.Url = p.ServiceURL.ToString(); ;
                        str = new string[] { "HHT_Barcodes_3001", p.CompanyId, p.LocationId.ToString(), string.Empty, dal.FormatString(empty) };
                        item = service.GetData(str).Tables[0];
                        if (item.Rows.Count > 0)
                        {
                            dataRow = item.Rows[0];
                        }
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                else
                {
                    service = new Service();
                    try
                    {
                        service.Url = p.ServiceURL.ToString();
                        str = new string[] { "HHT_Barcodes_3000", p.CompanyId, p.LocationId, string.Empty, dal.FormatString(Itemcode) };
                        item = service.GetData(str).Tables[0];
                        if (item.Rows.Count > 0)
                        {
                            dataRow = item.Rows[0];
                        }
                    }
                    finally
                    {
                        if (service != null)
                        {
                            ((IDisposable)service).Dispose();
                        }
                    }
                }
                if (dataRow == null)
                {
                    if (this.Barcode.Text.Length == 0)
                    {
                        throw new Exception("Invalid itemcode");
                    }
                    throw new Exception("Invalid barcode");
                }
             
       
            
            
                ComboBox uIComboBox = this.ComboBoxUnit;
                str = new string[] { (string)dataRow["UOM"] };
                ComboBoxUnit.Refresh();
                ComboBoxUnit.DataSource = null;
                ComboBoxUnit.Items.Clear();
                uIComboBox.Refresh();
                uIComboBox.DataSource = null;
                uIComboBox.Items.Clear();
               
                ComboboxItem cbi = new ComboboxItem();
                int i=0;
                foreach (string st in str)
                {
                    cbi.Text=string.Empty;
                    cbi.Value = null;
                    cbi.Value = i.ToString();
                    cbi.Text = st.ToString();
                    uIComboBox.Items.Add(cbi);
                }
                if (uIComboBox != null && uIComboBox.Items.Count > 0)
                {
                    uIComboBox.SelectedIndex = 0;
                }
               
                this.ComboBoxUnit.SelectedIndexChanged+= new EventHandler(this.ComboBoxUnit_SelectedIndexChanged);
                this.SetItemDetail(dataRow);
   
                this.m_bIsItemValidated = true;
                this.Barcode.Focus();
                this.Barcode.SelectAll();
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (this.Barcode.Text.Length == 0)
                {
                    this.ItemCode.SelectAll();
                    this.ItemCode.Focus();
                }
                else
                {
                    this.Barcode.SelectAll();
                    this.Barcode.Focus();
                }
                throw exception;
            }
        }
        private void SetItemDetail(DataRow datarow)
        {
            try
            {
                this.Description.Text=datarow["Description"].ToString();
                this.Vendor.Text=string.Format("{0} {1}", datarow["Vendor Code"].ToString(), datarow["Vendor Name"].ToString());
                TextBox uITextBox = this.SalePrice;
                double num = double.Parse(datarow["Sales Price"].ToString());
                      uITextBox.Text=num.ToString("F");
                     
            
          
                this.ItemCode.Text = datarow["Description"].ToString();
                
                TextBox uITextBox1 = this.CostPrice;
                num = double.Parse(datarow["Unit Price"].ToString());
                uITextBox1.Text= num.ToString("F");
                this.Barcode.Text = (string)datarow["Barcode"];
                this.ItemCode.Text = (string)datarow["Itemcode"];
                if (p.PriceService == "http://IP:Port/service1.asmx")
                {
                    MessageBox.Show("Please configure price service in config.xml for promo price!");
                
                }
                else
                {
                    Service s = new Service();
                    s.Url = p.ServiceURL.Replace("\r\n", "");

                    try
                    {

                        string ddPrice = s.GETPrice(datarow["Itemcode"].ToString(), datarow["Barcode"].ToString(), datarow["UOM"].ToString());
                        TextBox uITextBox2 = this.PriceDll;
                        uITextBox2.Text = ddPrice;
                    }
                    finally
                    {
                        if (s != null)
                        {
                            ((IDisposable)s).Dispose();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}