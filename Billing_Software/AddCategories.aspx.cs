 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;

namespace Billing_Software
{
    public partial class AddCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTable();
            }
        }

        [WebMethod]
        public static string AddCat(string CategoryName)
        {

            ClsCategory ct = new ClsCategory();
            var result = ct.Add_Cate(CategoryName);
            return result;
        }

      
        [WebMethod]
        public static string BindTable()
        {
            ClsCategory sm1 = new ClsCategory();
            string st = sm1.ShowData();
            return st;

        }


    }
}