function getTable() {
    $.ajax({
        type: "POST",
        url: "Stocks.aspx/BindTable",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var xmlDoc = $.parseXML(data.d);
            var xml = $(xmlDoc);
            var material = xml.find("MaterialTable");
            console.log(material);
            console.log(material.length);
            console.log($(material[0]).find("ItemName").text());
            var tbl = $("#tblData tbody");
            tbl.empty();
            tbl.append("<tr><th>SrNo</th><th>ItemName</th><th>Quantity</th><th>Price</th></tr>");
            if (material.length > 0) {
                for (var i = 0; i < material.length; i++) {
                    tbl.append("<tr><td>" + $(material[i]).find('SrNo').text() + "</td><td>" + $(material[i]).find('ItemName').text() + "</td><td>" + $(material[i]).find('Quantity').text() + "</td><td>" + $(material[i]).find('Price').text() + "</td><td></tr>");
                }
            }

        }
    });
}
$(document).ready(function () {
    getTable();
    $('#btnBuy').click(function () {
        var a = document.getElementById("ItemDropDownList").value;
        var b = document.getElementById("quantity").value;


        $.ajax({
            type: "POST",
            url: "Stocks.aspx/stock",
            data: '{ "Itemid": "' + a + '", "Quantity": "' + b + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                window.alert("Stock Updated");
                window.location.reload();
            }
        })
    })
});
