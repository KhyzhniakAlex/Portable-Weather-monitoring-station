const chartArea = document.getElementById("line-chart");

const myChart = new Chart(chartArea, {
    type: 'line',
    data: {
        labels: ['26.05', '27.05', '28.05', '29.05', '30.05', '31.05', '01.06', '02.06'],
        datasets: [{ 
                data: [16, 17.4, 15.7, 14, 17, 16.3, 15.2, 13.7],
                borderColor: "#ff0000",
                label: 'for Day',
            }, {
                data: [10, 12.2, 13.1, 12, 9.5, 11, 13, 12],
                borderColor: '#0000ff',
                label: 'for Night',
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
                scaleLabel: {
                    display: true,
                    labelString: 'Temperature (℃)',
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
                    labelString: 'Days',
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