$(function () {

    $('#btn-add-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-1 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to add.");
            e.preventDefault();
        } else {
            $('#list-nv-add-2').append($(selectedOpts).clone());
            e.preventDefault();
        }


    });
    $('#btn-remove-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }


    });

    $('#btn-up-them-nv').click(function (e) {
        var selectedOpts = $('#list-nv-add-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
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
            alert("Nothing to move.");
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
        var flag = true;
        if (Doan.madoan == "") {
            alert("mã đoàn không được để trống");
            flag = false;
        }
        if (Doan.ngaybatdau == "") {
            alert("thời gian bắt đầu là bắt buộc");
            flag = false;
        }
        if (Doan.ngayketthuc == "") {
            alert("thời gian kết thúc là bắt buộc");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(Doan);
        $.ajax({
            type: "POST",
            url: '/Doan/QuanLyDoan',
            data: '{Doan: ' + JSON.stringify(Doan) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm đoàn thành công");
                    window.location.href = "/Doan/QuanLyDoan";
                } else if (data.Code == "EXISTS") {
                    alert("Mã đoàn đã tồn tại");

                }

            },
            error: function () {
                alert("Error while inserting data");
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
        var flag = true;
        if (Doan.madoan == "") {
            alert("mã đoàn không được để trống");
            flag = false;
        }
        if (Doan.ngaybatdau == "") {
            alert("thời gian bắt đầu là bắt buộc");
            flag = false;
        }
        if (Doan.ngayketthuc == "") {
            alert("thời gian kết thúc là bắt buộc");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
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
                    alert("Sửa thành công", data);
                    window.location.href = "/Doan/QuanLyDoan";
                } else if (data.Code == "NOT_EXISTS") {
                    alert("Mã đoàn không tồn tại");

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

    onClickDeleteDoan = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa đoàn này?',
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
                    url: '/Doan/DeleteDoan',
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
                            window.location.href = "/Doan/QuanLyDoan";
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
    onGetInfoDoan = (id) => {

        $.ajax({
            type: "POST",
            url: '/Doan/GetDoan',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    console.log(data);
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };
});



