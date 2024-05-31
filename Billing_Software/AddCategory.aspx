<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Billing_Software.AddCategory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="center">
            <br />
            <br />
            <h2>ADD STOCKS</h2>
            <br />
            <input runat="server" id="hide" type="text" />
            <br />
     

            <br />
     <label runat="server" id="Label1" class="label">Category</label>
     &nbsp 
     <asp:DropDownList ID="CategoryDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CategoryDropDownList_SelectedIndexChanged1"></asp:DropDownList>
     <br />
     <br />
            <label runat="server" id="lbl1" class="label">ItemName</label>
     &nbsp 
     <asp:DropDownList ID="ItemDropDownList" runat="server"></asp:DropDownList>

            <br />


     <br />
            <label runat="server" id="lbl4" class="error"></label>
            <br />

            <label runat="server" id="lbl2" class="label">Quantity</label>
            <input runat="server" id="quantity" type="number" />
            <br />



            <label runat="server" id="lbl5" class="error"></label>
            <br />

        
            <br />
            <label runat="server" id="lbl6" class="error"></label>
            <br />

            <input runat="server" id="btnBuy" type="button" class="btn" value="Add Stock"/>
        

            <br />
            <br />
     
              <div class="scroll">
                <table id="tblData" runat="server" class="header" style="width: 494px; margin-left: 0px;" cellspacing="0" rules="none" border="0">
                    <thead style="background-color: #5D7B9D; color: white;">
                        <tr>
                            <th style="width: 120px;" class="id_head">ItemId</th>
                             <th style="width: 120px;">Sr No</th>     
                             <th style="width: 120px;">ItemName</th>
                            <th style="width: 120px;">Quantity</th>
                            <th style="width: 120px;">Price</th>
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
</body>
</html>
