$(function () {

    $("#btnAddLoaiTour").click(function (e) {
        e.preventDefault();
        var loaitour = {};
        loaitour.maloai = $("#them-ma-loai-tour").val();
        loaitour.tenloai = $("#them-ten-loai-tour").val();
        var flag = true;
        var result = "";
        if (loaitour.maloai == "") {
            result += "Mã loại tour không được rỗng<br/>";
            flag = false;
        }
        if (loaitour.tenloai == "") {
            result += "Tên loại tour không được rỗng<br/>";
            flag = false;
        }
        if (flag == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/LoaiTour/QuanLyLoaiTour',
            data: '{loaitour: ' + JSON.stringify(loaitour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/LoaiTour/QuanLyLoaiTour";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã loại tour đã tồn tại<br/>");

                }

            },
            error: function (data) {
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
        return false;
       
    });

    $("#btnEditLoaiTour").click(function (e) {
        e.preventDefault();
        var loaitour = {};
        loaitour.maloai = $("#sua-ma-loai-tour").val();
        loaitour.tenloai = $("#sua-ten-loai-tour").val();
        var flag = true;
        var result = "";
        if (loaitour.maloai == "") {
            result += "Mã loại tour không được rỗng<br/>";
            flag = false;
        }
        if (loaitour.tenloai == "") {
            result += "Tên loại tour không được rỗng<br/>";
            flag = false;
        }
        if (flag == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/LoaiTour/EditLoaiTour',
            data: '{loaitour: ' + JSON.stringify(loaitour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/LoaiTour/QuanLyLoaiTour";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã loại tour không tồn tại<br/>");

                }

            },
            error: function (data) {
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
        return false;

    });


    onDeleteLoaiTour = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa loại tour này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng Ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: '/LoaiTour/DeleteTour',
                    data: '{id: ' + JSON.stringify(id) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success'
                            ).then((value) => {
                                window.location.href = "/LoaiTour/QuanLyLoaiTour";
                            });
                        }

                    },
                    error: function (data) {
                        Swal.fire(id)
                        console.log(data);
                        Swal.fire("Error while inserting data<br/>");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoLoaiTour = (id) => {

        $.ajax({
            type: "POST",
            url: '/LoaiTour/GetLoaiTour',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-loai-tour").val(data.maloai);
                    $("#sua-ten-loai-tour").val(data.tenloai);

                }

            },
            error: function (data) {
                Swal.fire(id)
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };
});

