const chartArea = document.getElementById("line-chart");

const myChart = new Chart(chartArea, {
    type: 'line',
    data: {
        labels: ['1:00', '2:00', '3:00', '4:00', '5:00', '6:00', '7:00', '8:00', '9:00', '10:00', '11:00', '12:00'],
        datasets: [{ 
                data: [750, 753, 760, 764, 755.5, 749, 748, 751, 762, 765, 763, 767],
                label: "Atmosphere pressure (mm Hg)",
                borderColor: "#33cc33",
                yAxisID: 'first-y-axis',
            },
            { 
                data: [70, 63, 65, 52, 80, 100, 95, 84.4, 53, 59, 73, 51],
                label: "Humidity (%)",
                borderColor: "#0000ff",
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
                    labelString: 'Pressure',
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
                    labelString: 'Hours',
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