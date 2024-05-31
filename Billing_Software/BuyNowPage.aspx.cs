using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.IO;
using Microsoft.SqlServer.Server;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Configuration;
using System.Net;
using System.Net.Mail;




namespace Billing_Software
{
    public partial class BuyNowPage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
               filldrop_cate();
               BindTable();
             
            }
        }



    
        [WebMethod]
        public static string pdfcrea()
        {
            string companyName = "Intellidata";
            SqlConnection con = new SqlConnection("Data Source=RELIABLESERVER\\SQLEXPRESS;Initial Catalog=Bwork;User ID=rely;Password=R1sofRel3@$5%");
            SqlCommand cmd = new SqlCommand("pdfData", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            da.Fill(dt);

            int orderNo = Convert.ToInt32(dt.Rows[0]["OrderID"]);
            dt.TableName = "PdfData";
            con.Close();

            

            string pdfPath = HttpContext.Current.Server.MapPath("~/GeneratedPDFs/Invoice_" + orderNo + ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath)); // Ensure the directory exists

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    // Generate Invoice (Bill) Header
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Invoice/Bill</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Order No: </b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    // Generate Invoice (Bill) Items Grid
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th style = 'background-color: #D20B0C;color:#000000'>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");

                    // Export HTML String as PDF
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                    }
                }
            }

            // Return the URL to the generated PDF
            string pdfUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/GeneratedPDFs/Invoice_" + orderNo + ".pdf";
            return pdfUrl;
        }

        [WebMethod]
        public static Tuple<int, int> BuyNow(int Itemid, int Quantity)
        {

            clsBuyNow bn = new clsBuyNow();
            var result = bn.Buy_Now(Itemid, Quantity);

            return result;
        }


        [WebMethod]
        public static string BindTable()
        {
            clsBuyNow sm1 = new clsBuyNow();
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
            System.Web.UI.WebControls.ListItem selectItem = new System.Web.UI.WebControls.ListItem("Select Category", "0");

 
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
            string itemDT = JsonConvert.SerializeObject(itemData);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "createItem", "javascript:createItem('" + itemDT + "');", true);

            ItemDropDownList.ClearSelection();
            ItemDropDownList.Items.Clear();
            ItemDropDownList.AppendDataBoundItems = true;
            ItemDropDownList.DataSource = itemData;
            ItemDropDownList.DataTextField = "ItemName";
            ItemDropDownList.DataValueField = "ItemID";
            ItemDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem selectItem = new System.Web.UI.WebControls.ListItem("Select Item", "0");
            selectItem.Selected = true;
            ItemDropDownList.Items.Insert(0, selectItem);


        }

    

        protected void CategoryDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
             //int categoryid = ;
            filldrop_item(Convert.ToInt32(CategoryDropDownList.SelectedValue));
        }
        }

   

}


    


        
