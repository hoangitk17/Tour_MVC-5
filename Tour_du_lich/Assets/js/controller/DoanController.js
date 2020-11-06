$(function () {

    $('#btn-add-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-1 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to add.<br/>");
            e.preventDefault();
        } else {
            $('#list-nv-add-2').append($(selectedOpts).clone());
            e.preventDefault();
        }


    });
    $('#btn-remove-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.<br/>");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }


    });

    $('#btn-up-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.<br/>");
            e.preventDefault();
        } else {
            $('#list-nv-add-2 option:selected').each(function () {
                $(this).insertBefore($(this).prev());
            });
            e.preventDefault();
        }

    });
    $('#btn-down-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.<br/>");
            e.preventDefault();
        } else {
            $('#list-nv-add-2 option:selected').each(function () {
                $(this).insertAfter($(this).next());
            });
            e.preventDefault();
        }

    });
    //////////////////////////////////////
    $("#btnAddDoan").click(function (e) {
        e.preventDefault();
        var Doan = {};
        Doan.madoan = $("#them-ma-doan").val();
        Doan.matour = $("#them-ma-tour").val();
        Doan.ngaybatdau = $("#them-ngay-bat-dau").val();
        Doan.ngayketthuc = $("#them-ngay-ket-thuc").val();
        Doan.khachs = [];
        $('#list-nv-add-2 option').each(function () {
            $(this).insertAfter($(this).next());
            var khach = {
                makh: $(this).val(),
                tenkh: $(this).text(),
            }
            Doan.khachs.push(khach);
        });
        var date_start = new Date($('#them-ngay-bat-dau').val());
        var date_end = new Date($('#them-ngay-ket-thuc').val());
        var flag = true;
        var result = "";
        if (date_start.getTime() > date_end.getTime()) {
            result += "Thời gian không hợp lệ<br/>";
            flag = false;
        }
        if (Doan.madoan == "") {
            result += "mã đoàn không được để trống<br/>";
            flag = false;
        }
        if (Doan.ngaybatdau == "") {
            result += "thời gian bắt đầu là bắt buộc<br/>";
            flag = false;
        }
        if (Doan.ngayketthuc == "") {
            result += "thời gian kết thúc là bắt buộc<br/>";
            flag = false;
        }
        if (Doan.khachs.length == 0) {
            result += "Khách không được để trống<br/>";
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
            url: '/Doan/QuanLyDoan',
            data: '{Doan: ' + JSON.stringify(Doan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/Doan/QuanLyDoan";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã đoàn đã tồn tại<br/>");

                }

            },
            error: function () {
                Swal.fire("Error while inserting data<br/>");
            }
        });
        return false;
    });

    $("#btnEditDoan").click(function (e) {
        e.preventDefault();
        var Doan = {};
        Doan.madoan = $("#sua-ma-doan").val();
        Doan.matour = $("#sua-ma-tour").val();
        Doan.ngaybatdau = $("#sua-ngay-bat-dau").val();
        Doan.ngayketthuc = $("#sua-ngay-ket-thuc").val();
        var date_start = new Date($('#sua-ngay-bat-dau').val());
        var date_end = new Date($('#sua-ngay-ket-thuc').val());
        var flag = true;
        var result = "";
        if (date_start.getTime() > date_end.getTime()) {
            result += "Thời gian không hợp lệ<br/>";
            flag = false;
        }
        if (Doan.madoan == "") {
            result += "mã đoàn không được để trống<br/>";
            flag = false;
        }
        if (Doan.ngaybatdau == "") {
            result += "thời gian bắt đầu là bắt buộc<br/>";
            flag = false;
        }
        if (Doan.ngayketthuc == "") {
            result += "thời gian kết thúc là bắt buộc<br/>";
            flag = false;
        }
        //if (Doan.khachs.length == 0) {
        //    result += "Địa điểm không được để trống<br/>";
        //    flag = false;
        //}
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
            url: '/Doan/EditDoan',
            data: '{Doan: ' + JSON.stringify(Doan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/Doan/QuanLyDoan";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã đoàn không tồn tại<br/>");

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

    onClickDeleteDoan = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa đoàn này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelmButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: '/Doan/DeleteDoan',
                    data: '{id: ' + JSON.stringify(id) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công',
                                'success'
                            ).then((value) => {
                                window.location.href = "/Doan/QuanLyDoan";
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
    onGetInfoDoan = (id) => {

        $.ajax({
            type: "POST",
            url: '/Doan/GetDoan',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-doan").val(data.madoan);
                    $("#sua-ma-tour").val(data.matour);
                    $("#sua-ngay-bat-dau").val(data.ngaybatdau);
                    $("#sua-ngay-ket-thuc").val(data.ngayketthuc);
                    $.each(data.khachs, function (i, khach) {
                        $('#list-nv-edit-2').append($('<option>', {
                            value: khach.makh,
                            text: khach.tenkh
                        }));
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
    };

    DoanhThuDoan = () => {
        var id_doan = $("#ma-doan").val();
        var thoigianbatdau = $("#thoi-gian-bat-dau").val();
        var thoigianketthuc = $("#thoi-gian-ket-thuc").val();
        $.ajax({
            type: "POST",
            url: '/DoanhThuDoan/DoanhThuDoan',
            data: '{id_doan: ' + JSON.stringify(id_doan) + ',thoigianbatdau: ' + JSON.stringify(thoigianbatdau) + ',thoigianketthuc: ' + JSON.stringify(thoigianketthuc) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thực hiện thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/DoanhThuDoan/DoanhThuDoan";
                    });
                }
            },
            error: function (data) {
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };

});


