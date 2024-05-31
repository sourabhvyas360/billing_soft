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

namespace Billing_Software
{
    public partial class Stocks : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldrop_cate();
            }
        }


        [WebMethod]
        public static Tuple<int, int> stock(int Itemid, int Quantity)
        {

            clsStocks up = new clsStocks();
            var result = up.Stock_Up(Itemid, Quantity);
            return result;
        }

        [WebMethod]
        public static string BindTable()
        {
            clsStocks sm1 = new clsStocks();
            string st = sm1.ShowData();
            return st;

        }

        private void filldrop_cate()
        {
            CategoryDropDownList.AppendDataBoundItems = true;
            CategoryDropDownList.DataSource = getuserdata_cat();
            CategoryDropDownList.DataTextField = "CategoryName";
            CategoryDropDownList.DataValueField = "CategoryID";
            CategoryDropDownList.DataBind();
            ListItem selectItem = new ListItem("Select Category", "0");
            selectItem.Selected = true;
            CategoryDropDownList.Items.Insert(0, selectItem);
            filldrop_item(0);
        }

        public DataTable getuserdata_cat()
        {
            using (SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%"))
            {
                using (SqlCommand cmd = new SqlCommand("getCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private DataTable getuserdatan_item(int categoryid)
        {
            using (SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%"))
            {
                using (SqlCommand cmd = new SqlCommand("getItem", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoryID", categoryid);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void filldrop_item(int categoryid)
        {
            DataTable itemData = getuserdatan_item(categoryid);
            ItemDropDownList.ClearSelection();
            ItemDropDownList.Items.Clear();
            ItemDropDownList.AppendDataBoundItems = true;
            ItemDropDownList.DataSource = itemData;
            ItemDropDownList.DataTextField = "ItemName";
            ItemDropDownList.DataValueField = "ItemID";
            ItemDropDownList.DataBind();

            ListItem selectItem = new ListItem("Select Item", "0");
            selectItem.Selected = true;
            ItemDropDownList.Items.Insert(0, selectItem);


        }

    

        protected void CategoryDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int categoryid = Convert.ToInt32(CategoryDropDownList.SelectedValue);
            filldrop_item(categoryid);
        }




    }
}