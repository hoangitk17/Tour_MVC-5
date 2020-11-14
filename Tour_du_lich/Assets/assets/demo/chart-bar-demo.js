// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';


$(window).on('load', function () {
    var ctx;
    var myLineChart;
    $.ajax({
        type: "POST",
        url: '/DoanhThuTour/DoanhThuTour6Thang',
        data: {},
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.Code == "SUCCESS") {
                console.log("tours 2" + data.data[0]);
                console.log("tours 1" + data);
                console.log("tours" + data.data);
                console.log("tours 111" + data.arr);
                console.log("tours 222" + data.data.length);

                // Bar Chart Example
                    ctx = document.getElementById("myBarChart");
                    myLineChart = new Chart(ctx, {
                    type: 'bar',
                    data: {
                        labels: ["January", "February", "March", "April", "May", "June"],
                        datasets: [{
                            label: "Revenue",
                            backgroundColor: "rgba(2,117,216,1)",
                            borderColor: "rgba(2,117,216,1)",
                            data: [data.data[0], data.data[1], data.data[2], data.data[3], data.data[4], data.data[5]],
                        }],
                    },
                    options: {
                        scales: {
                            xAxes: [{
                                time: {
                                    unit: 'month'
                                },
                                gridLines: {
                                    display: false
                                },
                                ticks: {
                                    maxTicksLimit: 6
                                }
                            }],
                            yAxes: [{
                                ticks: {
                                    min: 0,
                                    max: data.data[6] + 5000,
                                    maxTicksLimit: 5
                                },
                                gridLines: {
                                    display: true
                                }
                            }],
                        },
                        legend: {
                            display: false
                        }
                    }
                });


                return true;
            }
            console.log("tours 111" + data.data);
            console.log("tours" + data.arr);
            console.log("success nhung fail")
        },
        error: function (data) {
            console.log(data);
            console.log("Fail luon")
            Swal.fire("Error while inserting data<br/>");
            Swal.fire(data.Message);
        }
    });
    console.log("error")
});