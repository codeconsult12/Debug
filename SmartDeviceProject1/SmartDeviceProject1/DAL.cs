using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;


namespace SmartDeviceProject1
{
    public class DAL
    {
       // String connString = @"Data Source=DESKTOP-MAII30Q\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MCEApp";
       // String connString = "Data Source=116.202.214.159;Initial Catalog=datalog;Persist Security Info=False;User ID=userdatalog;Password=qazwsx@1;";
        String connString = @"Data Source=\Program Files\SmartDeviceProject1\MyDatabase#1.sdf;Password=ehtisham123";
         
       

        public DataSet GetAllProducts()
        {
            String SQL = "select * from Product";

            SqlCeConnection con = new SqlCeConnection(connString);
            con.Open();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                //                DataSet1 ds = new DataSet1();
                //               var lstProduct = ds.Product.ToList();



                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();

                ///conn.Open(); 
                da.Fill(ds);
                ///conn.Close();

                return ds;

            }
            catch (Exception e)
            {

            }
            return null;
        }
    }
}
