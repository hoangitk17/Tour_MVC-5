$(function () {

    $("#btnAddLoaiTour").click(function (e) {
        e.preventDefault();
        var loaitour = {};
        loaitour.maloai = $("#inputMaLoaiTour").val();
        loaitour.tenloai = $("#inputTenLoaiTour").val();
        var flag = true;
        if (loaitour.maloai == "") {
            alert("Mã loại tour không được rỗng");
            flag = false;
        }
        if (loaitour.tenloai == "") {
            alert("Tên loại tour không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(loaitour);
        $.ajax({
            type: "POST",
            url: '/LoaiTour/QuanLyLoaiTour',
            data: '{loaitour: ' + JSON.stringify(loaitour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                Swal.fire(
                    'Good job!',
                    'You clicked the button!',
                    'success'
                )
                if (data.Code == "SUCCESS") {
                    window.location.href = "/LoaiTour/QuanLyLoaiTour";         
                } else if (data.Code == "EXISTS") {
                    alert("Mã địa điểm đã tồn tại");

                }

            },
            error: function (data) {
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
        return false;
       
    });
});