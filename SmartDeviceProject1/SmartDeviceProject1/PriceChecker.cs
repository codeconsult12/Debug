using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;



using System.Reflection;namespace SmartDeviceProject1
{
   
    public partial class PriceChecker : Form
    {
        public PriceChecker()
        {
            InitializeComponent();
        }

        public void CheckPrice()
        {
            string result = "Not Found";
            List<PriceCheck> values = PriceCheck.GetCSV();
            PriceCheck objprice = new PriceCheck();
            if (values != null)
            {
                foreach (var i in values)
                {
                    if (i.Barcode == textBox1.Text.ToString().Trim())
                    {
                        result = "Found";
                        objprice = i;
                    }
                }
            }

            if (objprice != null && objprice.Barcode != null && objprice.Cost != null)
            {
                ProductName.Text = objprice.Name;
                Description.Text = objprice.Description;

                LabelCost.Text = objprice.Cost.ToString();
                labeldicountAmount.Text = objprice.Discount.ToString();
                labelDiscount.Text = objprice.DiscountPer.ToString();
                labelSale.Text = objprice.Sale.ToString();

            }
            else
            {
                resetform();
                MessageBox.Show(result);
            }
        }
        private void OnKeyDownHandler(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckPrice();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckPrice();
         
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            resetform();
        }
        public void resetform()
        {
            textBox1.Text = "";
            ProductName.Text = "-";
            Description.Text = "-";
            LabelCost.Text = "0.00";
            labeldicountAmount.Text = "0.00";
            labelDiscount.Text = "0.00";
            labelSale.Text = "0.00";
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
    }
    public class PriceCheck
    {
        public int ProductId;
        public string Barcode;
        public string Name;
        public string Description;
        public string Cost;
        public string Sale;
        public string Discount;
        public string DiscountPer;

        public static string[] ReadAllLines(string path)
        {
            if (File.Exists(path))
            {
                List<string> lines = new List<string>();
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                        lines.Add(reader.ReadLine());
                }
                return lines.ToArray();
            }
            return null;
        }
        public static List<PriceCheck> GetCSV()
        {
            List<PriceCheck> prduct = new List<PriceCheck>();

            PriceCheck product = new PriceCheck();
            product.ProductId = 1;
            product.Barcode = "123";
            product.Name = "Pepsi";
            product.Description = "Colddrink Brand";
            product.Cost = "30.00";
            product.Sale = "50.00";
            product.Discount = "10.00";
            product.DiscountPer = "20.00";
            prduct.Add(product);
            PriceCheck product1 = new PriceCheck();
            product1.ProductId = 2;
            product1.Barcode = "124";
            product1.Name = "7 up";
            product1.Description = "Colddrink Brand";
            product1.Cost = "30.00";
            product1.Sale = "50.00";
            product1.Discount = "05.00";
            product1.DiscountPer = "10.00";
            prduct.Add(product1);
            PriceCheck product2 = new PriceCheck();
            product2.ProductId = 3;
            product2.Barcode = "125";
            product2.Name = "Lays";
            product2.Description = "Snaks";
            product2.Cost = "50.00";
            product2.Sale = "70.00";
            product2.Discount = "07.00";
            product2.DiscountPer = "10.00";
            prduct.Add(product2);
            return prduct;
        }
    }
}