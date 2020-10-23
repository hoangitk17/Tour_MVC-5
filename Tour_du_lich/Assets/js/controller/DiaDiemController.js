$(function () {
    $("#btnAddDiaDiem").click(function (e) {
        alert("here");
        e.preventDefault();
        var diadiem = {};
        diadiem.madiadiem = $("#ma-dia-diem-them").val();
        diadiem.tendiadiem = $("#ten-dia-diem-them").val();
        var flag = true;
        if (diadiem.madiadiem == "") {
            $("#place-management #show-err-ma").addClass("show-err");
            $("#place-management #show-err-ma").text("Mã không được để trống");
            flag = false;
        }
        if (diadiem.tendiadiem == "") {
            $("#place-management #show-err-name").addClass("show-err");
            $("#place-management #show-err-name").text("Tên không được để trống");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        alert("Data ok");
        $.ajax({
            type: "POST",
            url: '/DiaDiem/QuanLyDiaDiem',
            data: '{d: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm địa điểm thành công");
                    window.location.href = "/DiaDiem/QuanLyDiaDiem";
                    $('#close-them-dia-diem').click();
                } else if(data.Code == "EXISTS") {
                    alert("Mã địa điểm đã tồn tại");

                }
                
            },
            error: function () {
                alert("Error while inserting data");
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
        if (diadiem.madiadiem == "") {
            alert("Mã loại tour không được rỗng");
            flag = false;
        }
        if (diadiem.tendiadiem == "") {
            alert("Tên loại tour không được rỗng");
            flag = false;
        }
        if (flag == false) {
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        alert("data-edit");
        $.ajax({
            type: "POST",
            url: '/DiaDiem/EditDiaDiem',
            data: '{diadiem: ' + JSON.stringify(diadiem) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Sửa thành công");
                    window.location.href = "/DiaDiem/QuanLyDiaDiem";
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

    onDeleteDiaDiem = (id) => {
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
                    url: '/DiaDiem/Delete',
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
                            window.location.href = "/DiaDiem/QuanLyDiaDiem";
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };
});



