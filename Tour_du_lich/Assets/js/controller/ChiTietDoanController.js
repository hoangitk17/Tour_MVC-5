$(function () {

    $("#btnAddChiTietDoan").click(function (e) {
        e.preventDefault();
        var ChiTietDoan = {};
        ChiTietDoan.mota = $("#them-mo-ta").val();
        ChiTietDoan.madoan = $("#them-ma-doan").val();
        ChiTietDoan.makh = $("#them-ma-khach-hang").val();
        var flag = true;
        var result = "";
        if (ChiTietDoan.makh == "") {
            result += "Mã khách hàng không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietDoan.madoan == "") {
            result += "Mã đoàn không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietDoan.mota == "") {
            result += "Mô tả không được rỗng<br/>";
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
            url: '/ChiTietDoan/QuanLyChiTietDoan',
            data: '{ChiTietDoan: ' + JSON.stringify(ChiTietDoan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiTietDoan/QuanLyChiTietDoan";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã khách hàng và Mã đoàn này đã tồn tại<br/>");

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

    $("#btnEditChiTietDoan").click(function (e) {
        e.preventDefault();
        var ChiTietDoan = {};
        ChiTietDoan.mota = $("#sua-mo-ta").val();
        ChiTietDoan.madoan = $("#sua-ma-doan").val();
        ChiTietDoan.makh = $("#sua-ma-khach-hang").val();
        var flag = true;
        var result = "";
        if (ChiTietDoan.makh == "") {
            result += "Mã khách hàng không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietDoan.madoan == "") {
            result += "Mã đoàn không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietDoan.mota == "") {
            result += "Mô tả không được rỗng<br/>";
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
            url: '/ChiTietDoan/EditChiTietDoan',
            data: '{ChiTietDoan: ' + JSON.stringify(ChiTietDoan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiTietDoan/QuanLyChiTietDoan";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã khách hàng và Mã đoàn này không tồn tại không tồn tại<br/>");

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

    onClickDeleteChiTietDoan = (madoan, makh) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn chi tiết Đoàn này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: '/ChiTietDoan/DeleteChiTietDoan',
                    data: '{madoan: ' + JSON.stringify(madoan) + ',makh: ' + JSON.stringify(makh) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success'
                            ).then((value) => {
                                window.location.href = "/ChiTietDoan/QuanLyChiTietDoan";
                            });
                        }

                    },
                    error: function (data) {
                        Swal.fire(madoan, makh)
                        console.log(data);
                        Swal.fire("Error while inserting data<br/>");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoChiTietDoan = (madoan , makh) => {

        $.ajax({
            type: "POST",
            url: '/ChiTietDoan/GetChiTietDoan',
            data: '{madoan: ' + JSON.stringify(madoan) + ', makh: ' + JSON.stringify(makh) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-doan").val(data.madoan);
                    $("#sua-ma-khach-hang").val(data.makh);
                    $("#sua-mo-ta").val(data.mota);

                }

            },
            error: function (data) {
                Swal.fire(madoan, makh)
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };

});

