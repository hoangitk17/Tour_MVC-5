$(function () {
    $("#btnAddDiaDiem").click(function (e) {
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#ma-dia-diem-them").val();
        diadiem.tendiadiem = $("#ten-dia-diem-them").val();
        var flag = true;
        var result = "";
        if (diadiem.madiadiem == "") {
            //$("#place-management #show-err-ma").addClass("show-err");
            //$("#place-management #show-err-ma").text("Mã không được để trống");
            result += "Mã địa điểm không được trống<br/>";
            flag = false;
        }
        if (diadiem.tendiadiem == "") {
            //$("#place-management #show-err-name").addClass("show-err");
            //$("#place-management #show-err-name").text("Tên không được để trống");
            result += "Tên địa điểm không được trống<br/>";
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
            url: '/DiaDiem/QuanLyDiaDiem',
            data: '{d: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thông Báo!',
                        'Thêm thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/DiaDiem/QuanLyDiaDiem";
                    });
                } else if(data.Code == "EXISTS") {
                    Swal.fire("Mã địa điểm đã tồn tại");

                }
                
            },
            error: function () {
                Swal.fire("Error while inserting data");
            }
        });
        return false;
    });

    $("#btnEditDiaDiem").click(function (e) {
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#sua-ma-dia-diem").val();
        diadiem.tendiadiem = $("#sua-ten-dia-diem").val();
        var flag = true;
        var result = "";
        if (diadiem.madiadiem == "") {
            //$("#place-management #show-err-ma").addClass("show-err");
            //$("#place-management #show-err-ma").text("Mã không được để trống");
            result += "Mã địa điểm không được trống<br/>";
            flag = false;
        }
        if (diadiem.tendiadiem == "") {
            //$("#place-management #show-err-name").addClass("show-err");
            //$("#place-management #show-err-name").text("Tên không được để trống");
            result += "Tên địa điểm không được trống<br/>";
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
            url: '/DiaDiem/EditDiaDiem',
            data: '{diadiem: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {                
                    Swal.fire(
                        'Thông Báo',
                        'Sửa thành công!',
                        'success'
                    ).then((value) => {
                        window.location.href = "/DiaDiem/QuanLyDiaDiem";
                    });

                } else if (data.Code == "NOT_EXISTS") {
                    Swal.fire("Mã loại tour không tồn tại");

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

    onDeleteDiaDiem = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa địa điểm này?',
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
                    url: '/DiaDiem/Delete',
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
                                window.location.href = "/DiaDiem/QuanLyDiaDiem";
                            });

                        } else if (data.Code == "EXISTS_FOREIGN_KEY") {
                            Swal.fire(
                                'Xóa thất bại!',
                                'Địa Điểm này đã tồn tại trong bảng khác',
                                'error'
                            )
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
    onGetInfoDiaDiem = (id) => {

        $.ajax({
            type: "POST",
            url: '/DiaDiem/GetDiaDiem',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-dia-diem").val(data.madiadiem);
                    $("#sua-ten-dia-diem").val(data.tendiadiem);

                }

            },
            error: function (data) {
                Swal.fire(id)
                console.log(data);
                Swal.fire("Error while inserting data");
                Swal.fire(data.Message);
            }
        });
    };
});



