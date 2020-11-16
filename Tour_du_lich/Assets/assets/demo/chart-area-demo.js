// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';


$(function () {
    LoiNhuanTour = () => {
        var ctx;
        var myLineChart;
        var thoigianbatdau = $('#thoi-gian-bat-dau').val();
        var thoigianketthuc = $('#thoi-gian-ket-thuc').val();
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
            url: '/LoiNhuanTour/LoiNhuanTour',
            data: '{thoigianbatdau: ' + JSON.stringify(thoigianbatdau) + ',thoigianketthuc: ' + JSON.stringify(thoigianketthuc) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data.Code == "SUCCESS") {
                    console.log(data);
                    Swal.fire(
                        'Thông Báo',
                        'Thực hiện thành công',
                        'success'
                    )
                    //).then((value) => {
                    //    window.location.href = "/LoiNhuanTour/LoiNhuanTour";
                    // Area Chart Example
                    var res = data.total_price.toLocaleString() + " VNĐ";
                    $("#total").text(res);
                    $("#reset-area-chart").html('<canvas id="myAreaChart" width="100%" height="40"></canvas>');
                    ctx = document.getElementById("myAreaChart");
                    myLineChart = new Chart(ctx, {
                        type: 'line',
                        data: {
                            //labels: [data.tours[0], data.tours[1], data.tours[2], data.tours[3], data.tours[4], data.tours[5], data.tours[6], data.tours[7], data.tours[8], data.tours[9], data.tours[10], data.tours[11], data.tours[12], data.tours[13], data.tours[14], data.tours[15], data.tours[16], data.tours[17], data.tours[18], data.tours[19]],
                            labels: data.tours,
                            datasets: [{
                                label: "Sessions",
                                lineTension: 0.3,
                                backgroundColor: "rgba(2,117,216,0.2)",
                                borderColor: "rgba(2,117,216,1)",
                                pointRadius: 5,
                                pointBackgroundColor: "rgba(2,117,216,1)",
                                pointBorderColor: "rgba(255,255,255,0.8)",
                                pointHoverRadius: 5,
                                pointHoverBackgroundColor: "rgba(2,117,216,1)",
                                pointHitRadius: 50,
                                pointBorderWidth: 2,
                                //data: [data.data[0], data.data[1], data.data[2], data.data[3], data.data[4], data.data[5], data.data[6], data.data[7], data.data[8], data.data[9], data.data[10], data.data[11], data.data[12], data.data[13], data.data[14], data.data[15], data.data[16], data.data[17], data.data[18], data.data[19]],
                                data: data.data,
                            }],
                        },
                        options: {
                            scales: {
                                xAxes: [{
                                    time: {
                                        unit: 'date'
                                    },
                                    gridLines: {
                                        display: false
                                    },
                                    ticks: {
                                        maxTicksLimit: 7
                                    }
                                }],
                                yAxes: [{
                                    ticks: {
                                        min: 0,
                                        max: data.max + 10000000,
                                        maxTicksLimit: 5
                                    },
                                    gridLines: {
                                        color: "rgba(0, 0, 0, .125)",
                                    }
                                }],
                            },
                            legend: {
                                display: false
                            }
                        }
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
