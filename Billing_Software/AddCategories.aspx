<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategories.aspx.cs" Inherits="Billing_Software.AddCategories" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
        <link rel="stylesheet" href="stocks.css" />

</head>
<body>
    <form id="form1" runat="server">
   <div class="center">
            <br />
            <br />
            <h2>ADD CATEGORY</h2>
            <br />
     <label runat="server" id="Label1" class="label">Category</label>
     

        &nbsp 
       <asp:TextBox ID="category" runat="server"></asp:TextBox>
     <br />
        &nbsp 
            <input runat="server" id="btnBuy" type="button" class="btn" value="AddCategory" style="width:120px"/>
        

            <br />
            <br />
     
              <div class="scroll">
                <table id="tblData" runat="server" class="header" style="width: 494px; margin-left: 0px;" cellspacing="0" rules="none" border="0">
                    <thead style="background-color: #5D7B9D; color: white;">
                        <tr>
                        
                             <th style="width: 120px;">CategoryID</th>     
                             <th style="width: 120px;">CategoryName</th>

                        </tr>
                    </thead>
                    <tbody>
                       
                    </tbody>
                    <tfoot style="background-color: #5D7B9D; color: white;">
                        <tr>
                            <td colspan="5"></td>
                        </tr>
                    </tfoot>
                </table>
            </div>
        
            </div>
    </form>
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
     <script src="AddCategory.js"></script>
</body>
</html>
