$(function () {
    LoadData();
    $("#btnAddDiaDiem").click(function (e) {
        //alert("");
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#madiadiem").val();
        diadiem.tendiadiem = $("#tendiadiem").val();
        $.ajax({
            type: "POST",
            url: 'QUANLYDIADIEM',
            data: '{d: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert("Data has been added successfully.");
                LoadData();
                $('#close-them-dia-diem').click();
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;
    });
});

function LoadData() {
    $("#tbldiadiem table tbody tr").remove();

    $.ajax({
        type: 'POST',
        url: 'getDiaDiem',
        dataType: 'json',
        data: { id: '1' },
        success: function (data) {

            var items = '';
            $.each(data.diadiemList, function (i, item) {
                var rows = "<tr>"
                    + "<td >" + item.madiadiem + "</td>"
                    + "<td >" + item.tendiadiem + "</td>"
                    + "</tr>";

                $('#tbldiadiem table tbody').append(rows);
            });

        },
        error: function (ex) {

            console.log(ex);
            var r = jQuery.parseJSON(response.responseText);
            console.log(r);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });

    return false;

}