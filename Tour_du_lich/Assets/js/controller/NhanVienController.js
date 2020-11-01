$(function () {

    $("#btnAddNhanVien").click(function (e) {
        e.preventDefault();
        var nhanvien = {};
        nhanvien.manv = $("#them-ma-nhan-vien").val();
        nhanvien.tennv = $("#them-ten-nhan-vien").val();
        nhanvien.diachi = $("#them-dia-chi-nhan-vien").val();
        var flag = true;
        if (nhanvien.manv == "") {
            alert("Mã nhân viên không được rỗng");
            flag = false;
        }
        if (nhanvien.tennv == "") {
            alert("Tên nhân viên không được rỗng");
            flag = false;
        }
        if (nhanvien.diachi == "") {
            alert("Địa chỉ không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(nhanvien);
        $.ajax({
            type: "POST",
            url: '/NhanVien/QuanLyNhanVien',
            data: '{nhanvien: ' + JSON.stringify(nhanvien) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm nhân viên thành công");
                    window.location.href = "/NhanVien/QuanLyNhanVien";
                } else if (data.Code == "EXISTS") {
                    alert("Mã nhân viên đã tồn tại");

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

    $("#btnEditNhanVien").click(function (e) {
        e.preventDefault();
        var nhanvien = {};
        nhanvien.manv = $("#sua-ma-nhan-vien").val();
        nhanvien.tennv = $("#sua-ten-nhan-vien").val();
        nhanvien.diachi = $("#sua-dia-chi-nhan-vien").val();
        var flag = true;
        if (nhanvien.manv == "") {
            alert("Mã nhân viên không được rỗng");
            flag = false;
        }
        if (nhanvien.tennv == "") {
            alert("Tên nhân viên không được rỗng");
            flag = false;
        }
        if (nhanvien.diachi == "") {
            alert("Địa chỉ không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(nhanvien);
        $.ajax({
            type: "POST",
            url: '/NhanVien/EditNhanVien',
            data: '{nhanvien: ' + JSON.stringify(nhanvien) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/NhanVien/QuanLynhanvien";
                } else if (data.Code == "NOT_EXISTS") {
                    alert("Mã nhân viên không tồn tại");

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

    onClickDeleteNhanVien = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa nhân viên này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
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
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            )
                            window.location.href = "/NhanVien/QuanLyNhanVien";
                        }

                    },
                    error: function (data) {
                        alert(id)
                        console.log(data);
                        alert("Error while inserting data");
                        alert(data.Message);
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };

});

