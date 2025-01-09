document.addEventListener('DOMContentLoaded', async () => {

    const clientElement = document.getElementById('time-client');
    const responseElement = document.getElementById('time-response');
    const numberPhone = document.getElementById('number-client');

    const numberClient = `591${numberPhone.value}`;

    const timeAnalityc = await getStaticsTime(numberClient);

    if (timeAnalityc.error === 0) {
        clientElement.innerText = timeAnalityc.data[1];
        responseElement.innerText = timeAnalityc.data[0];
    }

    const textChat = await getChatMessage(numberClient);

    
    if (textChat.error != 0) {
        //TODO ERROR
        return;
    }
    const resultAnalityc = await getAnalitycChat({ message: textChat?.data??'Hola buenas noches' });

    if (resultAnalityc.error != 0) {
        //TODO ERROR
        return;
    }

    const dataSet = resultAnalityc.data.nouns.slice(0, 10).map((data) => [data.noun, data.count]);
    const dataSetEntities = resultAnalityc.data.entities.slice(0, 10).map(data => { return { name: data.entity, y: data.count, entities: data.texts.slice(0, 10).join('\n') }; });
    const dataSetVerbs = resultAnalityc.data.verbs.slice(0, 10).map((data) => [data.verb, data.count]);

    showChartNoun(dataSet);
    showChartVerb(dataSetVerbs);
    showEntities(dataSetEntities);



});

function delayTime(time) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve();
        }, time);
    });
}
function showChartNoun(dataSet) {
    Highcharts.chart('container-nouns', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Sustantivos'
        },
        subtitle: {
            text: 'Textos mas usados en la conversacion'
        },
        legend: {
            enabled: false
        },
        xAxis: {
            type: 'category',
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Frecuencia',
            },
            tickInterval: 1
        },

        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                },
                groupPadding: 0.1
            }
        },
        series: [
            {
                type: 'bar',
                name: 'Frecuencia',
                data: dataSet
            }
        ],

    });
}

function showChartVerb(dataSet) {
    Highcharts.chart('container-verbs', {
        chart: {
            type: 'bar'
        },
        title: {
            text: 'Verbos'
        },
        subtitle: {
            text: 'Textos mas usados en la conversacion'
        },
        legend: {
            enabled: false
        },
        xAxis: {
            type: 'category',
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Frecuencia',
            },
            tickInterval: 1
        },

        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true
                },
                groupPadding: 0.1
            }
        },
        series: [
            {
                type: 'bar',
                name: 'Frecuencia',
                data: dataSet
            }
        ],

    });
}

function showEntities(datSetEntities) {

    Highcharts.chart('container-entities', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Entidades'
        },
        subtitle: {
            text: 'Entidades mas usadas'
        },
        accessibility: {
            announceNewData: {
                enabled: true
            }
        },
        xAxis: {
            type: 'category',
            title: {
                text: 'Entidades'
            }
        },
        yAxis: {
            title: {
                text: 'Frecuencia'
            }

        },
        legend: {
            enabled: false
        },
        plotOptions: {
            series: {
                borderWidth: 0,
                dataLabels: {
                    enabled: true,

                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:16px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: ' +
                '<b>{point.y}</b> del total<br/>' +
                '<b>{point.entities}</b> of entidades<br/>'
        },

        series: [
            {
                name: 'Entidades',
                colorByPoint: true,
                data: datSetEntities
            }
        ],

    });

}
