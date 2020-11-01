$(function () {

    $("#btnAddKhachHang").click(function (e) {
        e.preventDefault();
        var Khach = {};
        Khach.makh = $("#them-ma-khach-hang").val();
        Khach.tenkh = $("#them-ten-khach-hang").val();
        Khach.diachi = $("#them-dia-chi-khach-hang").val();
        Khach.sdt = $("#them-so-dien-thoai-khach-hang").val();
        Khach.gioitinh = $("input[name='gender']:checked").val();
        Khach.cmnd = $("#them-cmnd-khach-hang").val();
        
        var flag = true;
        if (Khach.makh == "") {
            alert("Mã khách hàng không được rỗng");
            flag = false;
        }
        if (Khach.tenkh == "") {
            alert("Tên khách hàng không được rỗng");
            flag = false;
        }
        if (Khach.diachi == "") {
            alert("Địa chỉ không được rỗng");
            flag = false;
        }
        if (Khach.sdt == "") {
            alert("Số điện thoại không được rỗng");
            flag = false;
        }
        if (Khach.cmnd == "") {
            alert("Chứng minh nhân dân không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(Khach);
        $.ajax({
            type: "POST",
            url: '/Khach/QuanLyKhach',
            data: '{Khach: ' + JSON.stringify(Khach) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm khách hàng thành công");
                    window.location.href = "/Khach/QuanLyKhach";
                } else if (data.Code == "EXISTS") {
                    alert("Mã khách hàng đã tồn tại");

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

    $("#btnEditKhach").click(function (e) {
        e.preventDefault();
        var Khach = {};
        Khach.makh = $("#sua-ma-khach-hang").val();
        Khach.tenkh = $("#sua-ten-khach-hang").val();
        Khach.diachi = $("#sua-dia-chi-khach-hang").val();
        Khach.sdt = $("#sua-so-dien-thoai-khach-hang").val();
        Khach.gioitinh = $("input[name='genderEdit']:checked").val();
        Khach.cmnd = $("#sua-cmnd-khach-hang").val();

        var flag = true;
        if (Khach.makh == "") {
            alert("Mã khách hàng không được rỗng");
            flag = false;
        }
        if (Khach.tenkh == "") {
            alert("Tên khách hàng không được rỗng");
            flag = false;
        }
        if (Khach.diachi == "") {
            alert("Địa chỉ không được rỗng");
            flag = false;
        }
        if (Khach.sdt == "") {
            alert("Số điện thoại không được rỗng");
            flag = false;
        }
        if (Khach.cmnd == "") {
            alert("Chứng minh nhân dân không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(Khach);
        $.ajax({
            type: "POST",
            url: '/Khach/EditKhach',
            data: '{Khach: ' + JSON.stringify(Khach) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/Khach/QuanLyKhach";
                } else if (data.Code == "NOT_EXISTS") {
                    alert("Mã Khách không tồn tại");

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

    onClickDeleteKhachHang = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa khách hàng này?',
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
                    url: '/Khach/DeleteKhach',
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
                            window.location.href = "/Khach/QuanLyKhach";
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

    onGetInfoKhachHang = (id) => {

        $.ajax({
            type: "POST",
            url: '/Khach/GetKhach',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    $("#sua-ma-khach-hang").val(data.makh);
                    $("#sua-ten-khach-hang").val(data.tenkh);
                    $("#sua-dia-chi-khach-hang").val(data.diachi);
                    $("#sua-so-dien-thoai-khach-hang").val(data.sdt);
                    $("#sua-cmnd-khach-hang").val(data.cmnd);
                    if (data.gioitinh == "Nam") {
                        $("#NamEdit").prop("checked", true);
                    } else {
                        $("#NuEdit").prop("checked", true);
                    }

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

