const chartArea = document.getElementById("line-chart");

const myChart = new Chart(chartArea, {
    type: 'line',
    data: {
        labels: ['20 (6:00)', '21 (7:00)', '22 (8:00)', '21 (9:00)', '22 (10:00)', '22 (11:00)', '24 (12:00)', '23 (13:00)', '21 (14:00)', '21 (15:00)', '25 (16:00)', '26 (17:00)'],
        datasets: [{ 
                data: [10, 11.4, 13.7, 13, 13, 14.3, 14.2, 14.7, 15.5, 16, 14, 14.9],
                label: "Temperature (℃)",
                borderColor: "#ff0000",
                yAxisID: 'first-y-axis',
            },
            { 
                data: [70, 63.8, 77, 67, 80, 100, 95, 84.4, 90, 97, 95, 98],
                label: "Humidity (%)",
                borderColor: "#0000cc",
                yAxisID: 'second-y-axis'
            }
        ]
    },
    options: {
        legend: {
            labels: {
                fontSize: 13,
            }
        },
        scales: {
            yAxes: [{
                id: 'first-y-axis',
                scaleLabel: {
                    display: true,
                    labelString: 'Temperature',
                    fontFamily: 'sans-serif',
                    fontSize: 18,
                },
                ticks: {
                    fontSize: 14,
                }
            }, {
                id: 'second-y-axis',
                position: 'right',
                scaleLabel: {
                    display: true,
                    labelString: 'Humidity',
                    fontFamily: 'sans-serif',
                    fontSize: 18,
                },
                ticks: {
                    fontSize: 14,
                }
            }],
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: 'Heat Index per 12 Hours',
                    fontFamily: 'sans-serif',
                    fontSize: 18,
                },
                ticks: {
                    fontSize: 14,
                }
            }]
        }
    }
});