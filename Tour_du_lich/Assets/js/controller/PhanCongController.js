$(function () {

    $("#btnAddPhanCong").click(function (e) {
        e.preventDefault();
        var PhanCong = {};
        PhanCong.nhiemvu = $("#them-nhiem-vu").val();
        PhanCong.madoan = $("#them-ma-doan").val();
        PhanCong.manv = $("#them-ma-nhan-vien").val();
        var flag = true;
        var result = "";
        if (PhanCong.manv == "") {
            result += "Mã nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (PhanCong.madoan == "") {
            result += "Mã đoàn không được rỗng<br/>";
            flag = false;
        }
        if (PhanCong.nhiemvu == "") {
            result += "Nhiệm vụ không được rỗng<br/>";
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
            url: '/PhanCong/QuanLyPhanCong',
            data: '{PhanCong: ' + JSON.stringify(PhanCong) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/PhanCong/QuanLyPhanCong";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã nhân viên và Mã đoàn này đã tồn tại<br/>");

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

    $("#btnEditPhanCong").click(function (e) {
        e.preventDefault();
        var PhanCong = {};
        PhanCong.nhiemvu = $("#sua-nhiem-vu").val();
        PhanCong.madoan = $("#sua-ma-doan").val();
        PhanCong.manv = $("#sua-ma-nhan-vien").val();
        var flag = true;
        var result = "";
        if (PhanCong.manv == "") {
            result += "Mã nhân viên không được rỗng<br/>";
            flag = false;
        }
        if (PhanCong.madoan == "") {
            result += "Mã đoàn không được rỗng<br/>";
            flag = false;
        }
        if (PhanCong.nhiemvu == "") {
            result += "Nhiệm vụ không được rỗng<br/>";
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
            url: '/PhanCong/EditPhanCong',
            data: '{PhanCong: ' + JSON.stringify(PhanCong) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/PhanCong/QuanLyPhanCong";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã nhân viên và mã đoàn này không tồn tại không tồn tại<br/>");

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

    onClickDeletePhanCong = (id_nv, id_doan) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn phân công cho nhân viên này?',
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
                    url: '/PhanCong/DeletePhanCong',
                    data: '{id_nv: ' + JSON.stringify(id_nv) + ',id_doan: ' + JSON.stringify(id_doan) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success'
                            ).then((value) => {
                                window.location.href = "/PhanCong/QuanLyPhanCong";
                            });
                        }

                    },
                    error: function (data) {
                        Swal.fire(id_nv, id_doan)
                        console.log(data);
                        Swal.fire("Error while inserting data<br/>");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoPhanCong = (id_nv , id_doan) => {

        $.ajax({
            type: "POST",
            url: '/PhanCong/GetPhanCong',
            data: '{id_nv: ' + JSON.stringify(id_nv) + ', id_doan: ' + JSON.stringify(id_doan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-doan").val(data.madoan);
                    $("#sua-ma-nhan-vien").val(data.manv);
                    $("#sua-nhiem-vu").val(data.nhiemvu);

                }

            },
            error: function (data) {
                Swal.fire(id_nv, id_doan)
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };

});

