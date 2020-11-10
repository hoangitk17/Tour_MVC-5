$(function () {
    $('#btn-add-them').click(function (e) {
        var selectedOpts = $('#list-add-1 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to add.");
            e.preventDefault();
        } else {
            $('#list-add-2').append($(selectedOpts).clone());
            e.preventDefault();
        }
        
 
    });
    $('#btn-remove-them').click(function (e) {
        var selectedOpts = $('#list-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }

        
    });

    $('#btn-up-them').click(function (e) {
        var selectedOpts = $('#list-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $('#list-add-2 option:selected').each(function () {
                $(this).insertBefore($(this).prev());
            });
            e.preventDefault();
        }
        
    });
    $('#btn-down-them').click(function (e) {
        var selectedOpts = $('#list-add-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $('#list-add-2 option:selected').each(function () {
                $(this).insertAfter($(this).next());
            });
            e.preventDefault();
        }

    });
    //////////////////////////////////////
    $('#btn-add-sua').click(function (e) {
        var selectedOpts = $('#list-edit-1 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to add.");
            e.preventDefault();
        } else {
            $('#list-edit-2').append($(selectedOpts).clone());
            e.preventDefault();
        }


    });
    $('#btn-remove-sua').click(function (e) {
        var selectedOpts = $('#list-edit-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }


    });

    $('#btn-up-sua').click(function (e) {
        var selectedOpts = $('#list-edit-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $('#list-edit-2 option:selected').each(function () {
                $(this).insertBefore($(this).prev());
            });
            e.preventDefault();
        }

    });
    $('#btn-down-sua').click(function (e) {
        var selectedOpts = $('#list-edit-2 option:selected');
        if (selectedOpts.length == 0) {
            Swal.fire("Nothing to move.");
            e.preventDefault();
        } else {
            $('#list-edit-2 option:selected').each(function () {
                $(this).insertAfter($(this).next());
            });
            e.preventDefault();
        }

    });
    /////////////////////////////////////////////////////
    $("#btnAddTour").click(function (e) {
        e.preventDefault();
        var tour = {};
        tour.matour = $("#ma-tour-them").val();
        tour.tentour = $("#ten-tour-them").val();
        tour.maloai = $("#ma-loai-tour-them option:selected").val();
        tour.dacdiem = $("#dac-diem-them").val();
        tour.diadiems = [];
        $('#list-add-2 option').each(function () {
            $(this).insertAfter($(this).next());
            var diadiem = {
                madiadiem: $(this).val(),
                tendiadiem: $(this).text(),
            }
            tour.diadiems.push(diadiem);
        });
        var flag = true;
        if (tour.matour == "") {

            flag = false;
        }
        if (tour.tentour == "") {

            flag = false;
        }
        if (flag == false) {
            Swal.fire("Dữ liệu chưa nhập đủ");
            return false;
        }
        if (tour.diadiems.length == 0) {
            Swal.fire(
                'Lỗi!',
                'Địa điểm không được để trống',
                'error'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/Tour/QuanLyTour',
            data: '{insertTour: ' + JSON.stringify(tour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thành Công!',
                        'Thêm tour thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/Tour/QuanLyTour";
                    });
                } else if (data.Code == "EXISTS") {
                    Swal.fire(
                        'Thêm thất bại!',
                        'Mã tour đã tồn tại. Vui lòng nhập mã tour khác',
                        'error'
                    )

                }

            },
            error: function () {
                Swal.fire("Error while inserting data");
            }
        });
        return false;
    });

    $("#btnEditTour").click(function (e) {
        e.preventDefault();
        var tour = {};
        tour.matour = $("#ma-tour-sua").val();
        tour.tentour = $("#ten-tour-sua").val();
        tour.maloai = $("#ma-loai-tour-sua option:selected").val();
        tour.dacdiem = $("#dac-diem-sua").val();
        tour.diadiems = [];
        $('#list-edit-2 option').each(function () {
            $(this).insertAfter($(this).next());
            var diadiem = {
                madiadiem: $(this).val(),
                tendiadiem: $(this).text(),
            }
            tour.diadiems.push(diadiem);
        });
        var flag = true;
        if (tour.matour == "") {

            flag = false;
        }
        if (tour.tentour == "") {

            flag = false;
        }
        if (flag == false) {
            Swal.fire("Dữ liệu chưa nhập đủ");
            return false;
        }
        if (tour.diadiems.length == 0) {
            Swal.fire(
                'Lỗi!',
                'Địa điểm không được để trống',
                'error'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/Tour/EditTour',
            data: '{tour: ' + JSON.stringify(tour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    Swal.fire(
                        'Thành Công!',
                        'Sửa tour thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/Tour/QuanLyTour";
                    });
                   
                } else if (data.Code == "EXISTS") {
                    Swal.fire("Mã tour đã tồn tại");

                }

            },
            error: function () {
                Swal.fire("Error while inserting data");
            }
        });
        return false;
    });



    onDeleteTour = (id) => {
        Swal.fire({
            title: 'Bạn có chắc chắn muốn xóa tour này?',
            text: "Không thể khôi phục sau khi xóa!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Đồng Ý',
            cancelButtonText: 'Hủy'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: '/Tour/Delete',
                    data: '{id: ' + JSON.stringify(id) + '}',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.Code == "SUCCESS") {
                            Swal.fire(
                                'Xóa thành công!',
                                'Xóa tour thành công',
                                'success'
                            ).then((value) => {
                                window.location.href = "/Tour/QuanLyTour";
                            });
                          
                        } else if (data.Code == "EXISTS_FOREIGN_KEY") {
                            Swal.fire(
                                'Xóa thất bại!',
                                'Mã tour đã tồn tại trong bảng khác',
                                'error'
                            )
                      
                        }

                    },
                    error: function (data) {
                        Swal.fire(id)
                        console.log(data);
                        Swal.fire("Error while inserting data");
                        Swal.fire(data.Message);
                    }
                });

            }
        })
    };

    onGetInfoTour = (id) => {

        $.ajax({
            type: "POST",
            url: '/Tour/GetTour',
            data: '{id: ' + JSON.stringify(id) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    
                    $("#ma-tour-sua").val(data.tour.matour);
                    $("#ten-tour-sua").val(data.tour.tentour);
                    $("#dac-diem-sua").val(data.tour.dacdiem);
                    $("#ma-loai-tour-sua").val(data.tour.maloai);
                   
                    $.each(data.tour.diadiems, function (i, diadiem) {
                        $('#list-edit-2').append($('<option>', {
                            value: diadiem.madiadiem,
                            text: diadiem.tendiadiem
                        }));
                    });
                    console.log(data);
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

    DoanhThuTour = () => {
        var id_tour = $("#ma-tour").val();
        var thoigianbatdau = $("#thoi-gian-bat-dau").val();
        var thoigianketthuc = $("#thoi-gian-ket-thuc").val();
        var date_start = new Date($('#thoi-gian-bat-dau').val());
        var date_end = new Date($('#thoi-gian-ket-thuc').val());
        var result = "";
        var flag_tour = true;
        if (date_start.getTime() > date_end.getTime()) {
            result += "Thời gian không hợp lệ<br/>";
            flag_tour = false;
        }
        if (thoigianbatdau == "") {
            result += "Thời gian bắt đầu là bắt buộc<br/>";
            flag_tour = false;
        }
        if (thoigianketthuc == "") {
            result += "Thời gian kết thúc là bắt buộc<br/>";
            flag_tour = false;
        }
        if (flag_tour == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/DoanhThuTour/DoanhThuTour',
            data: '{id_tour: ' + JSON.stringify(id_tour) + ',thoigianbatdau: ' + JSON.stringify(thoigianbatdau) + ',thoigianketthuc: ' + JSON.stringify(thoigianketthuc) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    console.log("success")
                    Swal.fire(
                        'Thông Báo',
                        'Thực hiện thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/DoanhThuTour/DoanhThuTour";
                    });
                }
                console.log(data);
                console.log("success nhung fail")
            },
            error: function (data) {
                console.log(data);
                console.log("Fail luon")
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };


    ChiPhiTour = () => {
        var id_tour = $("#ma-tour").val();
        var thoigianbatdau = $("#thoi-gian-bat-dau").val();
        var thoigianketthuc = $("#thoi-gian-ket-thuc").val();
        var date_start = new Date($('#thoi-gian-bat-dau').val());
        var date_end = new Date($('#thoi-gian-ket-thuc').val());
        var result = "";
        var flag_tour = true;
        if (date_start.getTime() > date_end.getTime()) {
            result += "Thời gian không hợp lệ<br/>";
            flag_tour = false;
        }
        if (thoigianbatdau == "") {
            result += "Thời gian bắt đầu là bắt buộc<br/>";
            flag_tour = false;
        }
        if (thoigianketthuc == "") {
            result += "Thời gian kết thúc là bắt buộc<br/>";
            flag_tour = false;
        }
        if (flag_tour == false) {
            Swal.fire(
                'Thông Báo',
                result,
                'info'
            )
            return false;
        }
        $.ajax({
            type: "POST",
            url: '/ChiPhiTour/ChiPhiTour',
            data: '{id_tour: ' + JSON.stringify(id_tour) + ',thoigianbatdau: ' + JSON.stringify(thoigianbatdau) + ',thoigianketthuc: ' + JSON.stringify(thoigianketthuc) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    console.log("success")
                    Swal.fire(
                        'Thông Báo',
                        'Thực hiện thành công',
                        'success'
                    ).then((value) => {
                        window.location.href = "/ChiPhiTour/ChiPhiTour";
                    });
                }
                console.log(data);
                console.log("success nhung fail")
            },
            error: function (data) {
                console.log(data);
                console.log("Fail luon")
                Swal.fire("Error while inserting data<br/>");
                Swal.fire(data.Message);
            }
        });
    };

});



