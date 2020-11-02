$(function () {
    $("#btnAddGia").click(function (e) {
        e.preventDefault();
        var gia = {};
        gia.magia = $("#ma-gia-them").val();
        gia.matour = $("#ma-tour-them").val();
        gia.tgbd = $("#tgbd-them").val();
        gia.tgkt = $("#tgkt-them").val();
        gia.giatien = $("#gia-tien-them").val();
        var flag = true;
        var result = "";
        if (gia.magia == "") {
            result += "Mã giá không được để trống<br/>";
            flag = false;
        }
        if (gia.tgbd == "") {
            result += "Thời gian bắt đầu là bắt buộc<br/>";
            flag = false;
        }
        if (gia.tgkt == "") {
            result += "Thời gian kết thúc là bắt buộc<br/>";
            flag = false;
        }
        if (gia.giatien == "") {
            result += "Giá tiền không được để trống<br/>";
            flag = false;
        }
        if (flag == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            );
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/Gia/QuanLyGia',
            data: '{gia: ' + JSON.stringify(gia) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success',
                    ).then((value) => {
                        window.location.href = "/Gia/QuanLyGia";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã địa điểm đã tồn tại<br/>");

                }

            },
            error: function () {
                Swal.fire("Error while inserting data<br/>");
            }
        });
        return false;
    });

    $("#btnEditGia").click(function (e) {
        e.preventDefault();
        var gia = {};
        gia.magia = $("#ma-gia-sua").val();
        gia.matour = $("#ma-tour-sua").val();
        gia.tgbd = $("#tgbd-sua").val();
        gia.tgkt = $("#tgkt-sua").val();
        gia.giatien = $("#gia-tien-sua").val();
        var date_start = new Date($('#tgbd-sua').val());
        var date_end = new Date($('#tgkt-sua').val());
        var flag = true;
        var result = "";
        if (date_start.getTime() > date_end.getTime()) {
            result += "Thời gian không hợp lệ<br/>";
            flag = false;
        }
        if (gia.magia == "") {
            result += "Mã giá không được để trống<br/>";
            flag = false;
        }
        if (gia.tgbd == "") {
            result += "Thời gian bắt đầu là bắt buộc<br/>";
            flag = false;
        }
        if (gia.tgkt == "") {
            result += "Thời gian kết thúc là bắt buộc<br/>";
            flag = false;
        }
        if (gia.giatien == "") {
            result += "Giá tiền không được để trống<br/>";
            flag = false;
        }
        if (flag == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            );
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/Gia/EditGia',
            data: '{gia: ' + JSON.stringify(gia) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success',
                    ).then((value) => {
                        window.location.href = "/Gia/QuanLyGia";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã giá không tồn tại<br/>");

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

    onDeleteGia = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa địa điểm này?',
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
                    url: '/Gia/Delete',
                    data: '{id: ' + JSON.stringify(id) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success',
                            ).then((value) => {
                                window.location.href = "/Gia/QuanLyGia";
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
    onGetInfoGia = (id) => {

        $.ajax({
            type: "POST",
            url: '/Gia/GetGia',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    console.log(data);
                    $("#ma-gia-sua").val(data.magia);
                    $("#ma-tour-sua").val(data.matour);
                    $("#tgbd-sua").val(data.tgbd);
                    $("#tgkt-sua").val(data.tgkt);
                    $("#gia-tien-sua").val(data.giatien);

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



