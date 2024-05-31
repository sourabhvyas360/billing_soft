using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;
namespace Billing_Software
{
    public class ClsCategory
    {
        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");
        SqlCommand cmd;

        public string ShowData()
        {
            cmd = new SqlCommand("ShowCate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ds.Tables[0].TableName = "CategoryTable";
            con.Close();
            return ds.GetXml();

        }

        public string Add_Cate(string CategoryName)
        {



            cmd = new SqlCommand("AddCategory", con);

            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
         

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return  CategoryName;
        }

    }
}