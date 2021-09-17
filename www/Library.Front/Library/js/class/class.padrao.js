/**
 * Esse script tem dependencia das seguintes bibliotecas:
 *
 * script.padrao.js
 *
 * */

const MonthColor = [
    {
        month: 'JAN',
        color: '#1060ff' 
    },
    {
        month: 'FEV',
        color: '#7542ff' 
    },
    {
        month: 'MAR',
        color: '#198e7c' 
    },
    {
        month: 'ABR',
        color: '#24b550' 
    },
    {
        month: 'MAIO',
        color: '#89e23c' 
    },
    {
        month: 'JUN',
        color: '#fef200' 
    },
    {
        month: 'JUL',
        color: '#fccc00'
    },
    {
        month: 'AGO',
        color: '#fe8f01'
    },
    {
        month: 'SET',
        color: '#f95201'
    },
    {
        month: 'OUT',
        color: '#7a1fa0'
    },
    {
        month: 'NOV',
        color: '#ab31aa'
    },
    {
        month: 'DEZ',
        color: '#fe0000'
    }
]

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
    onloadstart: (xhr, response, obj) => {  Scripts.Elements.Load.Create("Spin"); },
    onloadend: (xhr, response, obj) => { Scripts.Elements.Load.LoadRemove('load'); },
    onload: (xhr, response, obj) => { console.log(xhr); },
    onerror: (xhr, response, obj) => { Scripts.Elements.Load.LoadRemove('load'); console.log(xhr); },
    data: null,
    responseType: 'json',
    setRequestHeader: {
        name: 'Content-Type',
        value: 'application/json'
    }
}