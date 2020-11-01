$(function () {

    $("#btnAddLoaiChiPhi").click(function (e) {
        e.preventDefault();
        var LoaiChiPhi = {};
        LoaiChiPhi.maloaichiphi = $("#them-ma-loai-chi-phi").val();
        LoaiChiPhi.tenloaichiphi = $("#them-ten-loai-chi-phi").val();
        var flag = true;
        if (LoaiChiPhi.maloaichiphi == "") {
            alert("Mã loại chi phí không được rỗng");
            flag = false;
        }
        if (LoaiChiPhi.tenloaichiphi == "") {
            alert("Tên loại chi phí không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(LoaiChiPhi);
        $.ajax({
            type: "POST",
            url: '/LoaiChiPhi/QuanLyLoaiChiPhi',
            data: '{LoaiChiPhi: ' + JSON.stringify(LoaiChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm loại chi phí thành công");
                    window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
                } else if (data.Code == "EXISTS") {
                    alert("Mã loại chi phí đã tồn tại");

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

    $("#btnEditLoaiChiPhi").click(function (e) {
        e.preventDefault();
        var LoaiChiPhi = {};
        LoaiChiPhi.maloaichiphi = $("#sua-ma-loai-chi-phi").val();
        LoaiChiPhi.tenloaichiphi = $("#sua-ten-loai-chi-phi").val();
        var flag = true;
        if (LoaiChiPhi.maloaichiphi == "") {
            alert("Mã loại chi phí không được rỗng");
            flag = false;
        }
        if (LoaiChiPhi.tenloaichiphi == "") {
            alert("Tên loại chi phí không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(LoaiChiPhi);
        $.ajax({
            type: "POST",
            url: '/LoaiChiPhi/EditLoaiChiPhi',
            data: '{LoaiChiPhi: ' + JSON.stringify(LoaiChiPhi) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
                } else if (data.Code == "NOT_EXISTS") {
                    alert("Mã loại chi phí không tồn tại");

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

    onClickDeleteLoaiChiPhi = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa loại chi phí này?',
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
                    url: '/LoaiChiPhi/DeleteLoaiChiPhi',
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
                            window.location.href = "/LoaiChiPhi/QuanLyLoaiChiPhi";
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };

});

