$(function () {

    $("#btnAddNhanVien").click(function (e) {
        e.preventDefault();
        var nhanvien = {};
        nhanvien.manv = $("#them-ma-nhan-vien").val();
        nhanvien.tennv = $("#them-ten-nhan-vien").val();
        nhanvien.diachi = $("#them-dia-chi-nhan-vien").val();
        var flag = true;
        var result = "";
        if (nhanvien.manv == "") {
            result += "Mã nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (nhanvien.tennv == "") {
            result += "Tên nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (nhanvien.diachi == "") {
            result += "Địa chỉ không được rỗng<br/>";
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
            url: '/NhanVien/QuanLyNhanVien',
            data: '{nhanvien: ' + JSON.stringify(nhanvien) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/NhanVien/QuanLyNhanVien";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã nhân viên đã tồn tại<br/>");

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

    $("#btnEditNhanVien").click(function (e) {
        e.preventDefault();
        var nhanvien = {};
        nhanvien.manv = $("#sua-ma-nhan-vien").val();
        nhanvien.tennv = $("#sua-ten-nhan-vien").val();
        nhanvien.diachi = $("#sua-dia-chi-nhan-vien").val();
        var flag = true;
        var result = "";
        if (nhanvien.manv == "") {
            result += "Mã nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (nhanvien.tennv == "") {
            result += "Tên nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (nhanvien.diachi == "") {
            result += "Địa chỉ không được rỗng<br/>";
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
            url: '/NhanVien/EditNhanVien',
            data: '{nhanvien: ' + JSON.stringify(nhanvien) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/NhanVien/QuanLyNhanVien";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã nhân viên không tồn tại<br/>");

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

    onClickDeleteNhanVien = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa nhân viên này?',
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
                    url: '/NhanVien/DeleteNhanVien',
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
                                window.location.href = "/NhanVien/QuanLyNhanVien";
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

    onGetInfoNhanVien = (id) => {

        $.ajax({
            type: "POST",
            url: '/NhanVien/GetNhanVien',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-nhan-vien").val(data.manv);
                    $("#sua-ten-nhan-vien").val(data.tennv);
                    $("#sua-dia-chi-nhan-vien").val(data.diachi);

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

