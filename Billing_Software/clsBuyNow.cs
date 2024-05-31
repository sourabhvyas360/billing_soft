using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace Billing_Software
{
    public class clsBuyNow
    {
        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");
        SqlCommand cmd;

        public Tuple<int, int> Buy_Now(int Itemid, int Quantity)
        {

            cmd = new SqlCommand("BuyNow", con);
    
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Itemid", Itemid);
            cmd.Parameters.AddWithValue("@ItemName", Itemid);  
            cmd.Parameters.AddWithValue("@ProductQuantity", Quantity);
           
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return new Tuple<int, int>(Itemid, Quantity);
        }

        public string ShowData()
        {
            cmd = new SqlCommand("sShowData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].TableName = "MaterialTable";
            con.Close();
            return ds.GetXml();

        }


    }
  }
