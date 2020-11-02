$(function () {

    $("#btnAddChiPhi").click(function (e) {
        e.preventDefault();
        var ChiPhi = {};
        ChiPhi.ghichu = $("#them-ghi-chu").val();
        ChiPhi.madoan = $("#them-ma-doan").val();
        ChiPhi.maloaichiphi = $("#them-ma-loai-chi-phi").val();
        ChiPhi.giathanh = $("#them-gia-thanh").val();
        ChiPhi.machiphi = "";
        var flag = true;
        var result = "";
        if (ChiPhi.maloaichiphi == "") {
            result += "Mã loại chi phí không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.madoan == "") {
            result += "Mã đoàn không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.ghichu == "") {
            result += "Ghi chú không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.giathanh == "") {
            result += "Giá thành không được trống<br/>";
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
        console.log(ChiPhi);
        $.ajax({
            type: "POST",
            url: '/ChiPhi/QuanLyChiPhi',
            data: '{ChiPhi: ' + JSON.stringify(ChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thành Công!',
                        'Sửa thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiPhi/QuanLyChiPhi";
                    });
                    
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã nhân viên và Mã đoàn này đã tồn tại");

                }

            },
            error: function (data) {
                console.log(data);
                Swal.fire("Error while inserting data");
                Swal.fire(data.Message);
            }
        });
        return false;

    });

    $("#btnEditChiPhi").click(function (e) {
        e.preventDefault();
        var ChiPhi = {};
        ChiPhi.ghichu = $("#sua-ghi-chu").val();
        ChiPhi.madoan = $("#sua-ma-doan").val();
        ChiPhi.maloaichiphi = $("#sua-ma-loai-chi-phi").val();
        ChiPhi.giathanh = $("#sua-gia-thanh").val();
        ChiPhi.machiphi = "";
        var flag = true;
        var result = "";
        if (ChiPhi.maloaichiphi == "") {
            result += "Mã loại chi phí không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.madoan == "") {
            result += "Mã đoàn không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.ghichu == "") {
            result += "Ghi chú không được trống<br/>";
            flag = false;
        }
        if (ChiPhi.giathanh == "") {
            result += "Giá thành không được trống<br/>";
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
        console.log(ChiPhi);
        $.ajax({
            type: "POST",
            url: '/ChiPhi/EditChiPhi',
            data: '{ChiPhi: ' + JSON.stringify(ChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thành Công!',
                        'Sửa thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiPhi/QuanLyChiPhi";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã loại chi phí và mã đoàn này không tồn tại không tồn tại");

                }

            },
            error: function (data) {
                console.log(data);
                Swal.fire("Error while inserting data");
                Swal.fire(data.Message);
            }
        });
        return false;

    });

    onClickDeleteChiPhi = (id_chiphi, id_doan) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn chi phí này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng ý',
            cancelButtonText: 'Hủy',
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: '/ChiPhi/DeleteChiPhi',
                    data: '{id_chiphi: ' + JSON.stringify(id_chiphi) + ',id_doan: ' + JSON.stringify(id_doan) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success'
                            ).then((value) => {
                                window.location.href = "/ChiPhi/QuanLyChiPhi";
                            });    
                        }

                    },
                    error: function (data) {
                        Swal.fire(id_chiphi, id_doan)
                        console.log(data);
                        Swal.fire("Error while inserting data");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoChiPhi = (id_chiphi , id_doan) => {

        $.ajax({
            type: "POST",
            url: '/ChiPhi/GetChiPhi',
            data: '{id_chiphi: ' + JSON.stringify(id_chiphi) + ', id_doan: ' + JSON.stringify(id_doan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ghi-chu").val(data.ghichu);
                    $("#sua-ma-loai-chi-phi").val(data.maloaichiphi);
                    $("#sua-gia-thanh").val(data.giathanh);
                    $("#sua-ma-doan").val(data.madoan);

                }

            },
            error: function (data) {
                Swal.fire(id_chiphi, id_doan)
                console.log(data);
                Swal.fire("Error while inserting data");
                Swal.fire(data.Message);
            }
        });
    };

});

