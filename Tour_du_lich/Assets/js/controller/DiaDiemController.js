$(function () {
    LoadData();
    $("#btnAddDiaDiem").click(function (e) {
        //alert("");
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#madiadiem").val();
        diadiem.tendiadiem = $("#tendiadiem").val();
        var flag = true;
        if (diadiem.madiadiem == "") {
            $("#place-management #show-err-ma").addClass("show-err");
            $("#place-management #show-err-ma").text("Mã không được để trống");
            flag = false;
        }
        if (diadiem.tendiadiem == "") {
            $("#place-management #show-err-name").addClass("show-err");
            $("#place-management #show-err-name").text("Tên không được để trống");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        $.ajax({
            type: "POST",
            url: 'QUANLYDIADIEM',
            data: '{d: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "201") {
                    alert("Thêm địa điểm thành công");
                    LoadData();
                    $('#close-them-dia-diem').click();
                } else if(data.Code == "400") {
                    alert("Mã địa điểm đã tồn tại");

                }
                
            },
            error: function (e) {
                alert(e.Message);
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
                    + "<td >" + item.tendiadiem + "</td>"+
                    `<td><button style="margin-right: 5px" type ="button" class="btn btn-warning" data-id="${item.madiadiem}" ><a style="text-decoration: none; color:#FFFFFF" href="/DiaDiem/Edit/${item.madiadiem}"> Sửa</a></button >`+
                    `<button type="button" class="btn btn-danger" data-id="${item.madiadiem}"><a style="text-decoration: none; color:#FFFFFF" href="/DiaDiem/Delete/${item.madiadiem}">Xóa</a></button>`+
                                    `</td >`+
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