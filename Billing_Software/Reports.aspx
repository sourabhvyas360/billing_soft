<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Billing_Software.Reports" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Report-Date-Wise</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
            padding: 20px;
        }
        .container {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }
        .form-group label {
            font-weight: bold;
        }
        .form-group input {
            margin-top: 5px;
        }
        .scroll {
            margin-top: 20px;
        }
        .scroll table {
            width: 100%;
        }
        .scroll th, .scroll td {
            padding: 10px;
            text-align: left;
        }
        .scroll thead {
            background-color: #007bff;
            color: white;
        }
        .scroll tfoot {
            background-color: #007bff;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="mb-4">Generate Report</h2>
            <div class="form-group">
                <label for="ReportDrop">Select Report Type:</label>
                <asp:DropDownList ID="ReportDrop" runat="server" class="form-control">
                    <asp:ListItem Value="">Please Select</asp:ListItem>
                    <asp:ListItem>Date-Wise</asp:ListItem>
                    <asp:ListItem>Month-Wise</asp:ListItem>
                    <asp:ListItem>Year-Wise</asp:ListItem>
                  
                </asp:DropDownList>
            </div>

            <div class="form-group" id="date-group" style="display:none;">
                <label for="fdt">From Date:</label>
                <input type="date" id="fdt" runat="server" class="form-control" />
            </div>
            <div class="form-group" id="month-group" style="display:none;">
                <label for="mdt">From Month:</label>
                <input type="month" id="mdt" runat="server" class="form-control" />
            </div>
            <div class="form-group" id="year-group">
                <label for="ydt">From Year:</label>
                <input type="text" id="ydt" runat="server" class="form-control" />
            </div>

            <div class="form-group" id="date-group-to" style="display:none;">
                <label for="tdt">To Date:</label>
                <input type="date" id="tdt" runat="server" class="form-control" />
            </div>
            <div class="form-group" id="month-group-to" style="display:none;">
                <label for="mdt2">To Month:</label>
                <input type="month" id="mdt2" runat="server" class="form-control" />
            </div>
            <div class="form-group" id="year-group-to">
                <label for="ydt2">To Year:</label>
                <input type="text" id="ydt2" runat="server" class="form-control" />
            </div>

            <asp:Button ID="gnbtn" runat="server" Text="Generate Report" CssClass="btn btn-primary btn-block" />
        </div>

        <div class="container scroll mt-4">
            <table id="tblData" runat="server" class="table table-bordered">
                <thead>
                    
                </thead>
                <tbody>
                  
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                </tfoot>
            </table>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
    <script>

        function getTable() {

            var a = document.getElementById('fdt').value;
            var b = document.getElementById('tdt').value;

            $.ajax({
                type: "POST",
                url: "Reports.aspx/BindTable",
                data: '{ "FromDate": "' + a + '", "ToDate": "' + b + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {


                    var jsonData = JSON.parse(data.d);

                    var material = jsonData.MaterialTable;


                    console.log(material);
                    console.log(material.length);
                    console.log($(material[0]).find("ItemName").text());
                    var tbl = $("#tblData tbody");
                    tbl.empty();
                    tbl.append("<tr><th>ItemName</th><th>OrderDate</th><th>Amount</th><th>ProductQuantity</th></tr>");
                    if (material.length > 0) {
                        for (var i = 0; i < material.length; i++) {
                            tbl.append("<tr><td>" + material[i]['ItemName'] + "</td><td>" + material[i]['OrderDate'] + "</td><td>" + material[i]['Amount'] + "</td><td>" + material[i]['ProductQuantity'] + "</td><td>");


                        }
                    }

                },
                error: function (e) {
                    console.log(e);
                }
            });
        }

        function getTableM() {

            var a = document.getElementById('mdt').value;
            var b = document.getElementById('mdt2').value;

            $.ajax({
                type: "POST",
                url: "Reports.aspx/BindTable2",
                data: '{ "FromMonth": "' + a + '", "ToMonth": "' + b + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {


                    var jsonData = JSON.parse(data.d);

                    var material = jsonData.MaterialTable;


                    console.log(material);
                    console.log(material.length);
                    console.log($(material[0]).find("ItemName").text());
                    var tbl = $("#tblData tbody");
                    tbl.empty();
                    tbl.append("<tr><th>ItemName</th><th>Amount</th><th>ProductQuantity</th></tr>");
                    if (material.length > 0) {
                        for (var i = 0; i < material.length; i++) {
                            tbl.append("<tr><td>" + material[i]['ItemName'] + "</td><td>" + material[i]['Amount'] + "</td><td>" + material[i]['ProductQuantity'] + "</td><td>");


                        }
                    }

                },
                error: function (e) {
                    console.log(e);
                }
            });
        }
        function getTableY() {

            var a = document.getElementById('ydt').value;
            var b = document.getElementById('ydt2').value;

          
            $.ajax({
                type: "POST",
                url: "Reports.aspx/BindTable3",
                data: '{ "FromYear": "' + a + '", "ToYear": "' + b + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",

                success: function (data) {


                    var jsonData = JSON.parse(data.d);

                    var material = jsonData.MaterialTable;


                    console.log(material);
                    console.log(material.length);
                    console.log($(material[0]).find("ItemName").text());
                    var tbl = $("#tblData tbody");
                    tbl.empty();
                    tbl.append("<tr><th>ItemName</th><th>Amount</th><th>ProductQuantity</th></tr>");
                    if (material.length > 0) {
                        for (var i = 0; i < material.length; i++) {
                            tbl.append("<tr><td>" + material[i]['ItemName'] + "</td><td>" + material[i]['Amount'] + "</td><td>" + material[i]['ProductQuantity'] + "</td><td>");


                        }
                    }

                },
                error: function (e) {
                    console.log(e);
                }
            });
        }
        $(document).ready(function () {
            $('#<%= ReportDrop.ClientID %>').change(function () {
                var selectedValue = $(this).val();
                $('#date-group, #month-group, #year-group, #date-group-to, #month-group-to, #year-group-to').hide();
                if (selectedValue === 'Date-Wise') {
                    $('#date-group, #date-group-to').show();
                    $('#gnbtn').click(function (event) {
                        event.preventDefault();
                        getTable();
                        
                    })
                } else if (selectedValue === 'Month-Wise') {
                    $('#month-group, #month-group-to').show();
                    $('#gnbtn').click(function (event) {
                        event.preventDefault();
                        getTableM();
                       
                    })
                } else if (selectedValue === 'Year-Wise') {
                    $('#year-group, #year-group-to').show();
                    $('#gnbtn').click(function (event) {
                        event.preventDefault();
                        getTableY();

                    })
                }
            }).change(); 
        });


    </script>
       
</body>
</html>
