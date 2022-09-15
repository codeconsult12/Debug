using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Web.Services;
using SmartDeviceProject1.DBClasses;
using SmartDeviceProject1.WebService;
using System.Net;


namespace SmartDeviceProject1
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
    public class DAL
    {
  
      public  string FormatString(string Value)
      {
          string str;
          try
          {
              str = (!string.IsNullOrEmpty(Value) ? Value.Replace("'", "''").Trim() : string.Empty);
          }
          catch (Exception exception)
          {
              throw exception;
          }
          return str; 
      }





      public List<UserRights> GetUserRights(string UserId)
      {
          Property p = new Property();
          Service service = new Service();
          service.Url = p.ServiceURL.Replace("\r\n", "");
          string[] str;

          try
          {

              DataTable dataTable = new DataTable();
              try
              {
                  str = new string[] { "HHT_User_Permission_3000", p.CompanyId, UserId, p.LocationId };
                  dataTable = service.GetData(str).Tables[0];
              }
              finally
              {
                  if (service != null)
                  {
                      ((IDisposable)service).Dispose();
                  }
              }
              List<UserRights> data = new List<UserRights>();
              foreach (DataRow row in dataTable.Rows)
              {
                  var obj = new UserRights()
                  {
                      HHTUserRoleCode = (string)row["HHT User Role Code"],
                      TransactionType = (row["Transaction Type"]).ToString()


                  };
                  data.Add(obj);
              }

              string path = "UserRightsData.csv";


              using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
              {
                  foreach (var arr in data)
                  {

                      sw.WriteLine(String.Join(",", new String[] { arr.HHTUserRoleCode.ToString(), arr.TransactionType }));
                  }
              }
              return data;
          }
          catch (Exception e)
          {
              throw e;
          }

      }

        public string GETIPAddress()
        {
            IPHostEntry IPHost = Dns.Resolve(Dns.GetHostName());
            IPAddress[] addressList = IPHost.AddressList;
            if (addressList.Length > 0)
            {
                StringBuilder address = new StringBuilder();
                foreach (IPAddress a in addressList)
                {
                    address.Append(a.ToString());
                    address.Append(" ");
                }
                return  address.ToString();
            }
            else
                return  "Not Found";
        }
        

        public UserRights StringToListUserRights(string line)
        {
            UserRights obj = new UserRights();
            var split = line.Split(',');
            obj.HHTUserRoleCode = split[0].ToString();
            obj.TransactionType = split[1].ToString();
            return obj;

        }


        public static void CreateDB()
        {
            try
            {
                SqlCeLib.ConnectionString = string.Format("Data Source={0};Password=a1pntbs1365*;Max Database Size=1000;", string.Concat("Data.sdf"));
                SqlCeLib.CreateDatabase();
                SqlCeLib.Execute("Create Table [Parameter]([Code] nvarchar(10), [Description] nvarchar(250), [Value] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Parameter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Location]([Code] nvarchar(10), [Name] nvarchar(250), [Location is a Warehouse] nvarchar(5))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Location] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Vendor]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On Vendor ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Customer]([Code] nvarchar(20), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On Customer ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Reason]([Code] nvarchar(10), [Description] nvarchar(250), [Type] nvarchar(10))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Reason] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transporter]([Code] nvarchar(10), [Name] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Transporter] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Setup]([AIF User Domain] nvarchar(250), [AIF User Name] nvarchar(250), [AIF User Password] nvarchar(250), [Version No.] nvarchar(10), [Location wise HHT Barcodes] nvarchar(5), [Download Purchase Invoice Line] nvarchar(5), [Download Purchase Return Line] nvarchar(5), [Download Sales Invoice Line] nvarchar(5), [Download Sales Return Line] nvarchar(5), [Download Transfer Shipment Line] nvarchar(5), [Download Transfer Receipt Line] nvarchar(5), [Show Purchase Invoice Line] nvarchar(5), [Show Purchase Return Line] nvarchar(5), [Show Sales Invoice Line] nvarchar(5), [Show Sales Return Line] nvarchar(5), [Show Transfer Shipment Line] nvarchar(5), [Show Transfer Receipt Line] nvarchar(5), [Check Item Validity - Stock] nvarchar(5), [Prompt on Invalid Barcode-SC] nvarchar(5), [Check Item Validity - Data] nvarchar(5), [Prompt on Invalid Barcode-Data] nvarchar(5), [Capture Reference No.] nvarchar(5), [Enable Auto Quantity - Data] nvarchar(5), [Enable Auto Quantity - SC] nvarchar(5), [iNTrack Web Service URL] nvarchar(250), [Download Path] nvarchar(250), [Update Path] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Role]([Code] nvarchar(20), [Name] nvarchar(250), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [HHT User Role] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Role Permission]([HHT User Role Code] nvarchar(20), [Transaction Type] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [HHT User Role Permission] ([HHT User Role Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Role Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Setup]([HHT User ID] nvarchar(20), [Password] nvarchar(10), [HHT User Name] nvarchar(250), [Backdated Document Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Show Cost Price] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Setup] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Setup] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT User Permission]([HHT User ID] nvarchar(20), [Location Code] nvarchar(10), [HHT User Role Code] nvarchar(20), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixHHTUserID On [HHT User Permission] ([HHT User ID])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT User Permission] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [HHT User Permission] ([HHT User ID], [Location Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Document Setup]([Location Code] nvarchar(10), [Transaction Type] nvarchar(20), [Backdated Document Allowed] nvarchar(5), [Negative Stock Allowed] nvarchar(5), [Show Inventory] nvarchar(5), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [HHT Document Setup] ([Location Code], [Transaction Type])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Barcodes]([Itemcode] nvarchar(20), [Barcode] nvarchar(80), [Description] nvarchar(250), [Vendor] nvarchar(1000), [Last Modified On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixItemcode On [HHT Barcodes] ([Itemcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixBarcode On [HHT Barcodes] ([Barcode])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixDescription On [HHT Barcodes] ([Description])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixLastModifiedOn On [HHT Barcodes] ([Last Modified On])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Item Category]([Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Item Category] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Product Group]([Item Category Code] nvarchar(10), [Code] nvarchar(10), [Description] nvarchar(250))", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCode On [Product Group] ([Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [Product Group] ([Item Category Code], [Code])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transaction Header]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Document Date] datetime, [Expected Date] datetime, [Closing Date] datetime, [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Receive] int, [Remarks] nvarchar(250), [Status] nvarchar(10), [Origin] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Index ixCombo On [Transaction Header] ([Transaction Type], [Transaction No.])", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [Transaction Line]([Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Line No.] int, [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Quantity] float, [Unit Price] float, [Amount] float, [Discount Perc.] float, [Discount Amount] float)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Transactions]([Line No.] int, [Transaction Type] nvarchar(10), [Transaction No.] nvarchar(20), [Source] nvarchar(20), [Source Name] nvarchar(250), [Destination] nvarchar(20), [Destination Name] nvarchar(250), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [FOC Item] int, [Reason Code] nvarchar(10), [Reference No.1] nvarchar(20), [Reference No.2] nvarchar(20), [Reference No.3] nvarchar(20), [Reference No.4] nvarchar(20), [Reference No.5] nvarchar(20), [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Stock Count Bin]([Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Enable Count] int)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
                SqlCeLib.Execute("Create Table [HHT Stock Count]([Line No.] int, [Count No.] nvarchar(20), [Location Code] nvarchar(20), [Bin Code] nvarchar(20), [Itemcode] nvarchar(20), [Barcode] nvarchar(20), [Description] nvarchar(250), [UOM] nvarchar(10), [Valid Item] int, [Quantity] float, [Unit Price] float, [Amount] float, [Status] nvarchar(10), [HHT User ID] nvarchar(20), [Created On] datetime)", SqlCeLib.ExecMode.NonQuery, new SqlCeParameter[0]);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                if (File.Exists(string.Concat("Data.sdf")))
                {
                    File.Delete(string.Concat("Data.sdf"));
                }
                throw exception;
            }
        }

        public List<UserRights> GetUserRightsDataFromCSV()
        {
            try
            {
                List<UserRights> list = new List<UserRights>();
                using (StreamReader sr = new StreamReader("UserRightsData.csv"))
                {
                    string currentLine;
                    // currentLine will be null when the StreamReader reaches the end of file
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        // Search, case insensitive, if the currentLine contains the searched keyword

                        if (currentLine != null)
                        {
                            UserRights csv = new UserRights();

                            csv = StringToListUserRights(currentLine);
                            if (list.Select(x => x.TransactionType == csv.TransactionType).Count() == 0)
                            {
                                list.Add(csv);
                            }

                        }


                    }
                }
                return list;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}
