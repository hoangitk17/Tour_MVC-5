$(function () {

    $("#btnAddLoaiChiPhi").click(function (e) {
        e.preventDefault();
        var LoaiChiPhi = {};
        LoaiChiPhi.maloaichiphi = $("#them-ma-loai-chi-phi").val();
        LoaiChiPhi.tenloaichiphi = $("#them-ten-loai-chi-phi").val();
        var flag = true;
        var result = "";
        if (LoaiChiPhi.maloaichiphi == "") {
            result += "Mã loại chi phí không được rỗng<br/>";
            flag = false;
        }
        if (LoaiChiPhi.tenloaichiphi == "") {
            result += "Tên loại chi phí không được rỗng<br/>";
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
            url: '/LoaiChiPhi/QuanLyLoaiChiPhi',
            data: '{LoaiChiPhi: ' + JSON.stringify(LoaiChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {             
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã loại chi phí đã tồn tại<br/>");

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

    $("#btnEditLoaiChiPhi").click(function (e) {
        e.preventDefault();
        var LoaiChiPhi = {};
        LoaiChiPhi.maloaichiphi = $("#sua-ma-loai-chi-phi").val();
        LoaiChiPhi.tenloaichiphi = $("#sua-ten-loai-chi-phi").val();
        var flag = true;
        var result = "";
        if (LoaiChiPhi.maloaichiphi == "") {
            result += "Mã loại chi phí không được rỗng<br/>";
            flag = false;
        }
        if (LoaiChiPhi.tenloaichiphi == "") {
            result += "Tên loại chi phí không được rỗng<br/>";
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
            url: '/LoaiChiPhi/EditLoaiChiPhi',
            data: '{LoaiChiPhi: ' + JSON.stringify(LoaiChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã loại chi phí không tồn tại<br/>");

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

    onClickDeleteLoaiChiPhi = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa loại chi phí này?',
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
                    url: '/LoaiChiPhi/DeleteLoaiChiPhi',
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
                                window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
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

    onGetInfoLoaiChiPhi = (id) => {

        $.ajax({
            type: "POST",
            url: '/LoaiChiPhi/GetLoaiChiPhi',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-loai-chi-phi").val(data.maloaichiphi);
                    $("#sua-ten-loai-chi-phi").val(data.tenloaichiphi);

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

