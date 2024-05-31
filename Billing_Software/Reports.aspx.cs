using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System;

using System.IO;
using Microsoft.SqlServer.Server;


namespace Billing_Software
{
    public partial class Reports : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");
        SqlCommand cmd;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        [WebMethod]
        public static string BindTable(DateTime FromDate, DateTime ToDate)
        {

            DataSet ds;
            Clsreport sm1 = new Clsreport();
            ds = sm1.ShowData(FromDate, ToDate);

            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;

        }
        [WebMethod]
        public static string BindTable2(DateTime FromMonth, DateTime ToMonth)
        {
            DataSet ds;
            Clsreport sm1 = new Clsreport();
            ds = sm1.monthData(FromMonth, ToMonth);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;
        }

        [WebMethod]
        public static string BindTable3( string FromYear,  string ToYear)
        {
            DataSet ds;
            Clsreport sm1 = new Clsreport();
            ds = sm1.yearData(FromYear, ToYear);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(ds);
            return JSONString;
        }

       
       


    }
}