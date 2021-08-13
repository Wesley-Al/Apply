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
    ConfigChart: (typeChar, pChartData, plabels) =>{
       try{        

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

       }catch(erro){
            alert(erro);
       }
    },
    /**
     * Essa função faz a renderização de um grafico utilizando a tag canvas
     * @param {*} configChart Um objeto configuravel retornado pela função Grafico.ConfigChart
     * @param {} canvasId Id do canvas onde o grafico sera renderizado
     * @returns void
     */
    NewChart: (configChart, canvasId) =>{
        try{
            if(configChart == undefined || configChart == null && 
                canvasId == undefined || canvasId == null){
                    return false;
            }

            var chart = new Chart(document.getElementById(canvasId.toString()),
                                configChart);
        }catch(error){
            alert(error);
        }
    }
}

const Ajax = (options) => {
    try{        
        if(options == undefined || options == null){
            return false;
        }

        var http = new XMLHttpRequest();

        http.open(options.Method, options.Url);

        http.responseType = options.responseType != undefined && options.responseType != null ? options.responseType : 'json';

        http.setRequestHeader('Content-Type', 'application/json');
        http.onload = (xhr, response, obj) =>{
            
        }

        http.response = (xhr, response, obj) => {
            
        }
        http.onerror = (xhr, response, obj) =>{            
            console.log(xhr);
        }

    http.send(JSON.stringify(Wallet));   
    }catch(error){
        alert(error);
    }
}

const API = {
    /**
     *Requisições do tipo GET 
     * @param {Opções para a definição da requisição} options 
     */
    GET: (options) =>{
        try{
            if(options == undefined || options == null){
                    return false;
            }
            Ajax(options);            

        }catch(error){
            alert(error);
        }        
    },
    /**
     * 
     * @param {Opções para a definição da requisição} options 
     */
    POST: (options) =>{
        try{

            Ajax(options);            
            
        }catch(error){
            alert(error);
        }        

    }   
}

const Scripts = {
    Grafico: Grafico,
    API: API    
}