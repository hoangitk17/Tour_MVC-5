﻿$(function () {
    $('#btn-add-them').click(function (e) {
        var selectedOpts = $('#list-add-1 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to add.");
            e.preventDefault();
        } else {
            $('#list-add-2').append($(selectedOpts).clone());
            e.preventDefault();
        }
        
 
    });
    $('#btn-remove-them').click(function (e) {
        var selectedOpts = $('#list-add-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }

        
    });

    $('#btn-up-them').click(function (e) {
        var selectedOpts = $('#list-add-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
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
            alert("Nothing to move.");
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
            alert("Nothing to add.");
            e.preventDefault();
        } else {
            $('#list-edit-2').append($(selectedOpts).clone());
            e.preventDefault();
        }


    });
    $('#btn-remove-sua').click(function (e) {
        var selectedOpts = $('#list-edit-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
            e.preventDefault();
        } else {
            $(selectedOpts).remove();
            e.preventDefault();
        }


    });

    $('#btn-up-sua').click(function (e) {
        var selectedOpts = $('#list-edit-2 option:selected');
        if (selectedOpts.length == 0) {
            alert("Nothing to move.");
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
            alert("Nothing to move.");
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
        alert("here");
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
            alert("Dữ liệu chưa nhập đủ");
            return false;
        }
        console.log(tour);
        alert("Data ok");
        $.ajax({
            type: "POST",
            url: '/Tour/QuanLyTour',
            data: '{insertTour: ' + JSON.stringify(tour) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    alert("Thêm Tour thành công");
                    window.location.href = "/Tour/QuanLyTour";
                    $('#close-them-dia-diem').click();
                } else if (data.Code == "EXISTS") {
                    alert("Mã tour đã tồn tại");

                }

            },
            error: function () {
                alert("Error while inserting data");
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
            alert("Dữ liệu chưa nhập đủ");
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
                    alert("Mã tour đã tồn tại");

                }

            },
            error: function () {
                alert("Error while inserting data");
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
            confirmButtonText: 'Yes, delete it!'
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
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            )
                            window.location.href = "/Tour/QuanLyTour";
                        } else if (data.Code == "EXISTS_FOREIGN_KEY") {
                            Swal.fire(
                                'Xóa thất bại!',
                                'Mã tour đã tồn tại trong bảng khác',
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
                alert(id)
                console.log(data);
                alert("Error while inserting data");
                alert(data.Message);
            }
        });
    };
});



