$(function () {

    $("#btnAddLoaiTour").click(function (e) {
        e.preventDefault();
        var loaitour = {};
        loaitour.maloai = $("#them-ma-loai-tour").val();
        loaitour.tenloai = $("#them-ten-loai-tour").val();
        var flag = true;
        if (loaitour.maloai == "") {
            alert("Mã loại tour không được rỗng");
            flag = false;
        }
        if (loaitour.tenloai == "") {
            alert("Tên loại tour không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(loaitour);
        $.ajax({
            type: "POST",
            url: '/LoaiTour/QuanLyLoaiTour',
            data: '{loaitour: ' + JSON.stringify(loaitour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm mã loại tour thành công");
                    window.location.href = "/LoaiTour/QuanLyLoaiTour";         
                } else if (data.Code == "EXISTS") {
                    alert("Mã loại tour đã tồn tại");

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

    $("#btnEditLoaiTour").click(function (e) {
        e.preventDefault();
        var loaitour = {};
        loaitour.maloai = $("#sua-ma-loai-tour").val();
        loaitour.tenloai = $("#sua-ten-loai-tour").val();
        var flag = true;
        if (loaitour.maloai == "") {
            alert("Mã loại tour không được rỗng");
            flag = false;
        }
        if (loaitour.tenloai == "") {
            alert("Tên loại tour không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(loaitour);
        $.ajax({
            type: "POST",
            url: '/LoaiTour/EditLoaiTour',
            data: '{loaitour: ' + JSON.stringify(loaitour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/LoaiTour/QuanLyLoaiTour";
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


    onDeleteLoaiTour = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa loại tour này?',
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
                    url: '/LoaiTour/DeleteTour',
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
                            window.location.href = "/LoaiTour/QuanLyLoaiTour";
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

    onGetInfoLoaiTour = (id) => {

        $.ajax({
            type: "POST",
            url: '/LoaiTour/GetLoaiTour',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-loai-tour").val(data.maloai);
                    $("#sua-ten-loai-tour").val(data.tenloai);

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

