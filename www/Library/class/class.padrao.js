const ChartData = {
    labels: [],
    datasets: [{
        label: '',
        backgroundColor: `rgb(${colorPrymary1Rgb})`,
        borderWidth: 2,
        borderColor: `rgb(${colorPrymary2Rgb})`,
        data: [0]
    }]
}

const AjaxOptions = {
    method: 'GET',
    url: null,
    onload: (xhr, response, obj) => { console.log(xhr); },
    onerror: (xhr, response, obj) => { console.log(xhr); },
    data: null,
    responseType: 'json',
    setRequestHeader: {
        name: 'Content-Type',
        value: 'application/json'
    }
}