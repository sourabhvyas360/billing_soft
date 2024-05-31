function getTable() {
    $.ajax({
        type: "POST",
        url: "AddCategories.aspx/BindTable",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var xmlDoc = $.parseXML(data.d);
            var xml = $(xmlDoc);
            var category = xml.find("CategoryTable");
            console.log(category);
            console.log(category.length);
            console.log($(category[0]).find("CategoryName").text());
            var tbl = $("#tblData tbody");
            tbl.empty();
            tbl.append("<tr><th>CategoryID</th><th>CategoryName</th></tr>");
            if (category.length > 0) {
                for (var i = 0; i < category.length; i++) {
                    tbl.append("<tr><td>" + $(category[i]).find('CategoryID').text() + "</td><td>" + $(category[i]).find('CategoryName').text() + "</td><td>");
                }
            }

        }
    });
}

$(document).ready(function () {
    getTable();
    $('#btnBuy').click(function () {
        var a = document.getElementById("category").value;

        $.ajax({
            type: "POST",
            url: "AddCategories.aspx/AddCat",
            data: '{ "CategoryName": "' + a + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                window.alert("Category Added");
                window.location.reload();
            }
        })
    })
});