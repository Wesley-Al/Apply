const urlAPI = '/API/';

//Cores primarias
const colorPrymary1Hex = "#02DDE8";
const colorPrymary2Hex = "#0297F2";
const colorPrymary3Hex = "#0944DB";
const colorPrymary4Hex = "#0F02F2";
const colorPrymary5Hex = "#5D00EB";

//Cores primarias
const colorPrymary1Rgb = "2, 221, 232";
const colorPrymary2Rgb = "2, 151, 242";
const colorPrymary3Rgb = "9, 68, 219";
const colorPrymary4Rgb = "15, 2, 242";
const colorPrymary5Rgb = "93, 0, 235";

document.addEventListener('DOMContentLoaded', () => {

})

const Grafico = {
    /**
     * Realiza a configuração do gráfico (não faz a renderização, apenas configura, utilize o Grafico.NewChart para renderizar um grafico, passando essa função como parâmetro)
     * @param {string} typeChar Tipo do grafico a ser renderizado 
     * @param {object} pdata Um objeto do tipo ChartData contendo dos dados a ser exibidos
     * @param {object} plabels Um objeto contendo as labels do grafico 
     * @returns void
     */
    ConfigChart: (typeChar, pChartData, plabels) => {
        try {

            var labels = plabels != undefined && plabels != null ? plabels : [
                'Empty'
            ];

            var data = pChartData != undefined && pChartData != null ? pChartData : {
                labels: labels,
                datasets: [{
                    label: 'Dataset',
                    backgroundColor: `rgb(${colorPrymary1Rgb})`,
                    borderWidth: 2,
                    borderColor: `rgb(${colorPrymary2Rgb})`,
                    data: [0]
                }]
            };

            var config = {
                type: typeChar != undefined && typeChar != null ? (typeChar).toString() : 'line',
                data,
                options: {
                    title: {
                        display: true,
                        fontSize: 20,
                        text: "Relatorio"
                    }
                }
            };

            return config;

        } catch (erro) {
            alert(erro);
        }
    },
    /**
     * Essa função faz a renderização de um grafico utilizando a tag canvas
     * @param {*} configChart Um objeto configuravel retornado pela função Grafico.ConfigChart
     * @param {} canvasId Id do canvas onde o grafico sera renderizado
     * @returns void
     */
    NewChart: (configChart, canvasId) => {
        try {
            if (configChart == undefined || configChart == null &&
                canvasId == undefined || canvasId == null) {
                return false;
            }

            var chart = new Chart(document.getElementById(canvasId.toString()),
                configChart);
        } catch (error) {
            alert(error);
        }
    }
}
/**
 * Função responsável pelas requisições para a API.
 * @param {AjaxOptions} pOptions Objeto contendo a configuração da requisição.
 */
const Ajax = (pOptions) => {
    try {
        if (pOptions == undefined || pOptions == null) {
            return false;
        }

        var http = new XMLHttpRequest();

        var options = AjaxOptions;

        options.onload = pOptions.onload != undefined && pOptions.onload != null ? pOptions.onload : AjaxOptions.onload;
        options.onerror = pOptions.onerror != undefined && pOptions.onerror != null ? pOptions.onerror : AjaxOptions.onerror;
        options.responseType = pOptions.responseType != undefined && pOptions.responseType != null ? pOptions.responseType : AjaxOptions.responseType;

        options.method = pOptions.method;
        options.url = pOptions.url;

        if (pOptions.setRequestHeader != undefined && pOptions.setRequestHeader != null) {
            options.setRequestHeader.name = pOptions.setRequestHeader.name != undefined && pOptions.setRequestHeader.name != null ? pOptions.setRequestHeader.name : AjaxOptions.setRequestHeader.name;
            options.setRequestHeader.value = pOptions.setRequestHeader.value != undefined && pOptions.setRequestHeader.value != null ? pOptions.setRequestHeader.value : AjaxOptions.setRequestHeader.value;
        }

        http.open(options.method, options.url);

        http.responseType = options.responseType;

        http.setRequestHeader(options.setRequestHeader.name, options.setRequestHeader.value);
        http.onload = options.onload;
        http.onerror = options.onerror;

        if (pOptions.data != null && pOptions.data != undefined) {
            var data = options.setRequestHeader.value == 'application/json' ? JSON.stringify(options.data) : encodeURI(options.data);

            http.send(data);
        } else {
            http.send();
        }

    } catch (error) {
        alert(error);
    }
}

const API = {
    /**
     *Requisições do tipo GET 
     * @param {Opções para a definição da requisição} options 
     */
    GET: (options) => {
        try {
            if (options == undefined || options == null) {
                return false;
            }
            Ajax(options);

        } catch (error) {
            alert(error);
        }
    },
    /**
     * 
     * @param {Opções para a definição da requisição} options 
     */
    POST: (options) => {
        try {

            Ajax(options);

        } catch (error) {
            alert(error);
        }

    }
}

const Elements = {
    /**
     * Retorna um elemento configurado por parametro.
     * @param {any} type Tipo do elemento: div, button, input, label, canvas, p, h1, etc.
     * @param {any} id
     * @param {any} name
     * @param {any} classe
     * @param {any} style
     * @param {any} onchange
     */
    Create: (type = null, id = '', name = '', classe = null, style = null, classList = null, onchange = null) => {
        try {
            if (type == null && type == undefined) {
                return null;
            }

            var element = document.createElement(type);

            if (onchange != null, onchange != undefined) {
                element.addEventListener('change', onchange);
            }

            if (style != null && style != undefined) {
                element.style = style;
            }

            element.id = id;

            if (classList != null && Array.isArray(classList)) {
                for (i = 0; i < classList.length; i++) {
                    element.classList.add(classList[i]);
                }
            } else if (classe != null) {
                element.classList.add(classe);
            }
            
            element.name = name;

            return element;
        } catch (error) {
            debugger;
            console.log(error);
        }
    }
}

const Scripts = {
    Grafico: Grafico,
    API: API,
    Elements: Elements
}