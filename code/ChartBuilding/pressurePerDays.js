const chartArea = document.getElementById("line-chart");

const myChart = new Chart(chartArea, {
    type: 'line',
    data: {
        labels: ['26.05', '27.05', '28.05', '29.05', '30.05', '31.05', '01.06', '02.06'],
        datasets: [{ 
                data: [],
                borderColor: "#0099cc",
                label: 'for Day',
            }, {
                data: [],
                borderColor: '#993333',
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
                    labelString: 'Pressure (mm Hg)',
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