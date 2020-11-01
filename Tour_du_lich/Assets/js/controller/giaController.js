$(function () {
    $("#btnAddGia").click(function (e) {
        alert("here");
        e.preventDefault();
        var gia = {};
        gia.magia = $("#ma-gia-them").val();
        gia.matour = $("#ma-tour-them").val();
        gia.tgbd = $("#tgbd-them").val();
        gia.tgkt = $("#tgkt-them").val();
        gia.giatien = $("#gia-tien-them").val();
        var flag = true;
        if (gia.magia == "") {
            alert("mã giá không được để trống");
            flag = false;
        }
        if (gia.tgbd == "") {
            alert("thời gian bắt đầu là bắt buộc");
            flag = false;
        }
        if (gia.tgkt == "") {
            alert("thời gian kết thúc là bắt buộc");
            flag = false;
        }
        if (gia.giatien == "") {
            alert("giá tiền không được để trống");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        alert("Data ok");
        console.log({ gia });
        $.ajax({
            type: "POST",
            url: '/Gia/QuanLyGia',
            data: '{gia: ' + JSON.stringify(gia) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm giá tour thành công");
                    window.location.href = "/Gia/QuanLyGia";
                    $('#close-them-dia-diem').click();
                } else if (data.Code == "EXISTS") {
                    alert("Mã địa điểm đã tồn tại");

                }

            },
            error: function () {
                alert("Error while inserting data");
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
        var flag = true;
        if (gia.magia == "") {
            alert("mã giá không được để trống");
            flag = false;
        }
        if (gia.tgbd == "") {
            alert("thời gian bắt đầu là bắt buộc");
            flag = false;
        }
        if (gia.tgkt == "") {
            alert("thời gian kết thúc là bắt buộc");
            flag = false;
        }
        if (gia.giatien == "") {
            alert("giá tiền không được để trống");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        alert("Data ok");
        console.log({ gia });
        $.ajax({
            type: "POST",
            url: '/Gia/EditGia',
            data: '{gia: ' + JSON.stringify(gia) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/Gia/QuanLyGia";
                } else if (data.Code == "NOT_EXISTS") {
                    alert("Mã loại tour không tồn tại");

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

    onDeleteGia = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa địa điểm này?',
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
                    url: '/Gia/Delete',
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
                            window.location.href = "/Gia/QuanLyGia";
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };
});



