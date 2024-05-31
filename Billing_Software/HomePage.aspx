<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Billing_Software.HomePage" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" href = "HomePage.css"/>
</head>
<body>
    <form id="form1" runat="server">

        
    <header>
        <h1>Billing Software</h1>
    </header>
    

        <br />

        <br />
        <br />

        <section id="categories" class="main-block category">
           <a href="BuyNowPage.aspx"><h2>Buy Now</h2></a> 
           
            
        </section>

        <section id="inventory" class="main-block inventory">
            <a href="Stocks.aspx"><h2>Inventory Management</h2></a>
           
        </section>

              <section id="AddCategory" class="main-block reports">
            <a href="AddCategories.aspx"><h2>AddCategory</h2></a>
         
        </section>

        <section id="reports" class="main-block reports">
            <a href="Reports.aspx"><h2>Reports</h2></a>
         
        </section>

    

    <footer>
        <p>&copy; 2024 Billing Software. All rights reserved.</p>
    </footer>

        
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
   
</body>
</html>
