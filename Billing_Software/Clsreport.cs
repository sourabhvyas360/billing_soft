using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace Billing_Software
{
    public class Clsreport
    {
        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");


        public DataSet ShowData(DateTime FromDate, DateTime ToDate)
        {


            SqlCommand cmd = new SqlCommand("dateSp", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FromDate", FromDate.Date);

            cmd.Parameters.AddWithValue("@ToDate", ToDate.Date);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            ds.Tables[0].TableName = "MaterialTable";
            con.Close();
            return ds;

        }

        public DataSet monthData(DateTime FromMonth, DateTime ToMonth)
        {


            SqlCommand cmd = new SqlCommand("monthSp", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FromMonth", FromMonth);

            cmd.Parameters.AddWithValue("@ToMonth", ToMonth);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            ds.Tables[0].TableName = "MaterialTable";
            con.Close();
            return ds;

        }


        public DataSet yearData(string FromYear, string ToYear)
        {


            SqlCommand cmd = new SqlCommand("yearSp", con);

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@FromYear", FromYear);

            cmd.Parameters.AddWithValue("@ToYear", ToYear);


            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds);
            ds.Tables[0].TableName = "MaterialTable";
            con.Close();
            return ds;

        }





    }
}