$(function () {

    $("#btnAddChiTietTour").click(function (e) {
        e.preventDefault();
        var ChiTietTour = {};
        ChiTietTour.thutu = $("#them-thu-tu").val();
        ChiTietTour.matour = $("#them-ma-tour").val();
        ChiTietTour.madiadiem = $("#them-ma-dia-diem").val();
        var flag = true;
        var result = "";
        if (ChiTietTour.madiadiem == "") {
            result += "Mã địa điểm không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietTour.matour == "") {
            result += "Mã Tour không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietTour.thutu == "") {
            result += "Thứ Tự không được rỗng<br/>";
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
            url: '/ChiTietTour/QuanLyChiTietTour',
            data: '{ChiTietTour: ' + JSON.stringify(ChiTietTour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Thêm thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiTietTour/QuanLyChiTietTour";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã địa điểm và Mã Tour này đã tồn tại<br/>");

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

    $("#btnEditChiTietTour").click(function (e) {
        e.preventDefault();
        var ChiTietTour = {};
        ChiTietTour.thutu = $("#sua-thu-tu").val();
        ChiTietTour.matour = $("#sua-ma-tour").val();
        ChiTietTour.madiadiem = $("#sua-ma-dia-diem").val();
        var flag = true;
        var result = "";
        if (ChiTietTour.madiadiem == "") {
            result += "Mã địa điểm không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietTour.matour == "") {
            result += "Mã Tour không được rỗng<br/>";
            flag = false;
        }
        if (ChiTietTour.thutu == "") {
            result += "Thứ Tự không được rỗng<br/>";
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
            url: '/ChiTietTour/EditChiTietTour',
            data: '{ChiTietTour: ' + JSON.stringify(ChiTietTour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiTietTour/QuanLyChiTietTour";
                    });
                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã địa điểm và Mã Tour này không tồn tại không tồn tại<br/>");

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

    onClickDeleteChiTietTour = (matour, madiadiem) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn chi tiết tour này?',
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
                    url: '/ChiTietTour/DeleteChiTietTour',
                    data: '{matour: ' + JSON.stringify(matour) + ',madiadiem: ' + JSON.stringify(madiadiem) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Thông Báo',
                                'Xóa thành công!',
                                'success'
                            ).then((value) => {
                                window.location.href = "/ChiTietTour/QuanLyChiTietTour";
                            });
                        }

                    },
                    error: function (data) {
                        Swal.fire(matour, madiadiem)
                        console.log(data);
                        Swal.fire("Error while inserting data<br/>");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoChiTietTour = (matour , madiadiem) => {

        $.ajax({
            type: "POST",
            url: '/ChiTietTour/GetChiTietTour',
            data: '{matour: ' + JSON.stringify(matour) + ', madiadiem: ' + JSON.stringify(madiadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-tour").val(data.matour);
                    $("#sua-ma-dia-diem").val(data.madiadiem);
                    $("#sua-thu-tu").val(data.thutu);

                }

            },
            error: function (data) {
                Swal.fire(matour, madiadiem)
                console.log(data);
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };

});

