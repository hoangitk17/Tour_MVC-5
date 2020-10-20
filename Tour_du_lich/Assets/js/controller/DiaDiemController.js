$(function () {
    $("#btnAddDiaDiem").click(function (e) {
        alert("here");
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#ma-dia-diem-them").val();
        diadiem.tendiadiem = $("#ten-dia-diem-them").val();
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
        alert("Data ok");
        $.ajax({
            type: "POST",
            url: '/DiaDiem/QuanLyDiaDiem',
            data: '{d: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm địa điểm thành công");
                    window.location.href = "/DiaDiem/QuanLyDiaDiem";
                    $('#close-them-dia-diem').click();
                } else if(data.Code == "EXISTS") {
                    alert("Mã địa điểm đã tồn tại");

                }
                
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        return false;
    });
});


