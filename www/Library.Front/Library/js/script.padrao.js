/**
 * Esse script tem dependencia das seguintes bibliotecas:
 * 
 * class.padrao.js
 * style.padrao.js
 * 
 * Terceiros:
 * 
 *  Bootstrap 5.1 ou superior. 
 *  ChartJS;.
 * 
 * */

const url = new URL(document.URL);
const urlHost = `${url.protocol}//${url.host}`;
//const urlAPI = `${urlHost}/api/`;
//const urlAPI = `http://intru/api/`;
//const urlAPI = `https://intru.herokuapp.com/`;
const urlAPI = `https://localhost:44382/`;

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
    
    var URLHOST = new URL(window.location.href);

    var ext = URLHOST.host.indexOf('intru') > -1;

    if (ext != null && ext != undefined) {
        if (ext != true) {
            return;
        }        
    }

    var cod = recuperaUserCodCookie();

    if (cod == '' || cod == null || cod == undefined) {
        if (window.location.href == `${urlHost}/Security/Login/`) {
            return;
        }

        logOut();
    }
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
 * @param {any} asyncRequest Um booleano indicando se a requisição é assincrona, o valor padrão é true
 */
const Ajax = (pOptions, asyncRequest = true) => {
    try {
        if (pOptions == undefined || pOptions == null) {
            return false;
        }

        if (typeof (asyncRequest) != "boolean") {
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

        http.open(options.method, options.url, asyncRequest);

        http.responseType = options.responseType;

        http.setRequestHeader(options.setRequestHeader.name, options.setRequestHeader.value);
        http.onload = options.onload;
        http.onerror = options.onerror;

        http.onloadstart = pOptions.onloadstart != undefined && pOptions.onloadstart != null ? pOptions.onloadstart : AjaxOptions.onloadstart;
        http.onloadend = pOptions.onloadend != undefined && pOptions.onloadend != null ? pOptions.onloadend : AjaxOptions.onloadend;

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
    Create: (type = null, id = '', name = '', classe = null, style = null, classList = null, onchange = null, typeButton = null) => {
        try {
            if (type == null && type == undefined) {
                return null;
            }

            var element = document.createElement(type);

            if (typeButton != null && typeButton != undefined) {
                if(type == 'input'){
                    element.type = typeButton;
                }                
            }

            if (onchange != null, onchange != undefined) {
                element.addEventListener('change', onchange);
            }

            if (style != null && style != undefined) {
                element.style = style;
            }

            if (id != null && id != undefined) {
                element.id = id;
            }            

            if (classList != null && Array.isArray(classList)) {
                for (i = 0; i < classList.length; i++) {
                    element.classList.add(classList[i]);
                }
            } else if (classe != null) {
                element.classList.add(classe);
            }

            if (name != null && name != undefined) {
                element.name = name;
            }            

            return element;
        } catch (error) {
            console.log(error);
        }
    },

    /**
     * Renderiza um elemento de load na tela
     * @param {any} type Tipo do load que sera renderizado, o tipo padrão é "Spin" (Spin, Growing)
     * @param {any} idElement Id do elemento onde o load sera renderizado
     * @param {any} style Tipo de cor ()
     */
    Load: {
        Create: (type, idElement, strStyle, strSpinnerColor) => {
            try {

                var span;
                var div;
                var spinnerColor = strSpinnerColor == null || strSpinnerColor == undefined ? "var(--colorPrymary5)" : strSpinnerColor;
                var style = strStyle == null || strStyle == undefined ? `z-index: 999 !important; position: fixed !important; left: 50%;`
                    + `top: 50% !important; bottom: 0 !important; color: ${spinnerColor} !important;` : strStyle;

                switch (type) {
                    case "Spin":
                        div = Elements.Create('div', 'load', null, null, style, ["spinner-border", "text-primary"]);
                        span = Elements.Create('span', 'loadSpan', "visually-hidden", null);

                        div.appendChild(span);

                        break;

                    case "Growing":
                        div = Elements.Create('div', 'loadMestre', null, null, style);

                        var divSpinner = Elements.Create('div', 'divGrowing', null, null, `z-index: 150 !important; color: ${spinnerColor} !important;`, ["spinner-grow", "text-primary"]);
                        span = Elements.Create('span', 'loadGrowing', "visually-hidden", null);

                        divSpinner.appendChild(span);
                        div.appendChild(divSpinner);

                        break;

                    default:
                        div = Elements.Create('div', 'load', null, null, style, ["spinner-border", "text-primary"]);
                        span = Elements.Create('span', 'loadSpan', null, "visually-hidden");

                        div.appendChild(span);

                        break;
                }

                if (idElement == null || idElement == undefined) {
                    document.body.appendChild(div);

                } else {
                    document.getElementById(idElement).appendChild(div);
                }

            } catch (error) {
                console.log(error);
            }
        },
        LoadRemove: (load) => {

            try {
                if (load == null || load == undefined) {
                    alert("O Load não pode ser nulo");
                    return
                }

                var ld = document.getElementById(load);
                
                if (ld != null && ld != undefined) {
                    ld.remove();
                }
                
            } catch (error) {
                console.log(error);
            }
        }
    },
    Message: {
        Remove: () => {
            document.querySelectorAll('.messageError').forEach((obj, index) => { obj.remove(); });
            document.querySelectorAll('.messageSuccess').forEach((obj, index) => { obj.remove(); });
        },
        Success: (msg) => {
            try {
                Message.Remove();
            } catch (error) { }

            var div = Scripts.Elements.Create('div', null, 'message', 'messageSuccess');
            var divContent = Scripts.Elements.Create('div', 'messageContent', null, 'messageContent');
            var span = Scripts.Elements.Create('span');
            // var iconTrash = Scripts.Elements.Create('i', null, null, null, null, ['fas', 'fa-eraser']);
            var icon = Scripts.Elements.Create('i', null, null, null, null, ['fas', 'fa-check', 'iconMessage']);

            span.textContent = msg;
            //span.appendChild(iconTrash);

            divContent.appendChild(span);

            div.appendChild(divContent);
            div.appendChild(icon);

            document.body.appendChild(div);
        },
        Error: (msg) => {
            try {
                Message.Remove();
            } catch (error) { }
            
            var div = Scripts.Elements.Create('div', null, 'message', 'messageError');
            var divContent = Scripts.Elements.Create('div', 'messageContent', null, 'messageContent');
            var span = Scripts.Elements.Create('span');
            // var iconTrash = Scripts.Elements.Create('i', null, null, null, null, ['fas', 'fa-eraser']);
            var icon = Scripts.Elements.Create('i', null, null, null, null, ['fas', 'fa-bug', 'iconMessage']);

            span.textContent = msg;
            //span.appendChild(iconTrash);

            divContent.appendChild(span);

            div.appendChild(divContent);
            div.appendChild(icon);

            document.body.appendChild(div);
        }
    },
    ToogleClass: (element, stringClassBefore, stringClassAfter, callback) => {
        try {
            var classList = element?.classList;

            classList?.toggle(stringClassBefore)
            classList?.toggle(stringClassAfter)

            if (callback != null && callback != undefined && typeof(callback) == 'function') {
                callback(element);
            }

        } catch (error) {
            alert(error)
        }
    }
}

const ElementList = {
    ToogleDisabledElement: (className, classIdentify, idElementDisable) => {

        var selected = document.querySelectorAll(`.${className}`);
        var existSelected = false;
        var classList = null;

        for (var i = 0; i < selected?.length; i++) {
            classList = selected[i].classList;

            if (classList?.value?.indexOf(`${classIdentify}`) != -1) {
                existSelected = true;
                break;
            }
        }

        if (existSelected) {
            document.getElementById(`${idElementDisable}`).disabled = false;
        } else {
            document.getElementById(`${idElementDisable}`).disabled = true;
        }

    }
}

const Scripts = {
    Grafico: Grafico,
    API: API,
    Elements: Elements,
    ElementList: ElementList
}

var logOut = function () {    
    Scripts.Elements.Message.Error("Redirecionando para o login...");
    document.cookie = `username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
    document.cookie = `usercod=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
    setTimeout(() => { window.location.href = `${urlHost}/Security/Login/`; }, 1800);
}

function selectAll(className, type, stringClassBefore, stringClassAfter) {
    try {
        var elements = null;        

        switch (type) {
            case 'li':
                elements = document.querySelectorAll(`.${className}`);

                for (var index = 0; index < elements?.length; index++) {
                    Scripts.Elements
                        .ToogleClass(elements[index], stringClassBefore, stringClassAfter);
                }

                break;

            case 'checkBox':
                elements = document.querySelectorAll(`.${className}`);

                for (var index = 0; index < elements?.length; index++) {
                    if (elements[i]?.checked == true) {
                        elements[i].checked = false;

                    } else {
                        elements[i].checked = true;
                    }
                }

                break;
        }

        return elements;

    } catch (error) {
        alert(error);
    }
}

var recuperaUserNameCookie = function () {    
    try {
        var cookie = document.cookie.split(';');
        var name = '';
        if (cookie.find(x => x.indexOf('username=') > -1) != undefined) {
            name = cookie.find(x => x.indexOf('username=') > -1).replaceAll('username=', '')
        }

        return name;
    } catch (error) {
        return null;
    }
};

var recuperaUserCodCookie = function () {    
    try {
        var cookie = document.cookie.split(';');
        var cod = '';
        if (cookie.find(x => x.indexOf('usercod=') > -1) != undefined) {
            cod = parseInt(cookie.find(x => x.indexOf('usercod=') > -1).replaceAll('usercod=', ''));
        }

        return cod;
        
    } catch (error) {
        return null;
    }    
};

var DeleteAll = {
    Category: async (itens) => {
        if (confirm('Deseja apagar todas as Categorias?')) {
            return new Promise((resolve) => {
                var options = AjaxOptions;

                if (itens?.length > 0) {
                    var categorys = {
                        UsuCod: recuperaUserCodCookie(),
                        CCCodList: itens
                    }

                    options.url = `${urlAPI}Category/DeleteCategorys`;
                    options.data = categorys;
                } else {
                    options.url = `${urlAPI}Category/DeleteAllCategorys`;
                    options.data = recuperaUserCodCookie();

                }

                options.method = 'POST';

                options.onload = (xhr, obj) => {

                    var response = xhr.currentTarget.response;

                    if (response != null && response != undefined) {
                        if (response.success == false) {
                            alert(`Ocorreu um erro durante o processo: ${response.erroMsg}.`);
                            resolve(false);
                        } else if (response?.objeto != null && response?.objeto?.length > 0) {
                            alert(response.objeto.join('\n'));
                        }

                        AtualizaList.Category();
                        resolve(true);
                    } else {
                        alert("Nenhum dado foi excluído.");
                    }
                }

                Scripts.API.POST(options);
            });
        }
    }   
}

var AtualizaDados = (event, element) => {
    try {
        // var icon = Scripts.Elements.Create('i', 'icoRefresh', null, null, null, ['far', 'fa-dot-circle']);

        var options = document.querySelectorAll('input[name=month]:checked');

        if (options.length > 0) {
            document.getElementById('icoRefresh').classList;
        }

    } catch (Error) {

    }
}

var AtualizaList = {
    Category: () => {
        try {
            document.getElementById('listGroup')?.remove();

            ImplementList("Category");

        } catch (error) {
            alert(error);
        }
    },
    Cards: () => {
        try {

            var inputs = document.querySelectorAll('input[name=month]:checked');
            var options = new Array();

            for (var i = 0; i < inputs.length; i++) {
                options.push(inputs[i].value);
            }

            document.getElementById('monthOptions').innerText = options.join(' - ') == "" ? 'All' : options.join(' - ');

            var divCarrousel = document.querySelectorAll('div[name=frameCarrousel]');

            document.getElementsByClassName('totalizador')[0]?.remove();
            document.getElementById('listGroup')?.remove();
            document.getElementById('graficoLine')?.remove()
            document.getElementById('graficoBar')?.remove();

            divCarrousel[0].appendChild(Scripts.Elements.Create('canvas', 'graficoLine'));
            divCarrousel[1].appendChild(Scripts.Elements.Create('canvas', 'graficoBar'));

            ImplementGrafico(options);

        } catch (Error) {
            alert(Error);
        }
    }
}

var CarregaDados = {
    Category: async () => {
        return new Promise((resolve) => {
            var options = AjaxOptions;

            options.url = `${urlAPI}Category/GetAllByUsuCod?usuCod=${recuperaUserCodCookie()}`;
            options.method = 'POST';
            options.async = false;

            options.onload = (xhr, obj) => {

                if (xhr.currentTarget.response != null && xhr.currentTarget.response != undefined) {
                    if (xhr.currentTarget.response.success == false) {
                        Scripts.Elements.Message.Error(`Ocorreu um erro: ${xhr.currentTarget.response.erroMsg}`);
                        resolve(null);
                    }

                    var Category;

                    if (xhr.currentTarget.response.objeto != undefined && xhr.currentTarget.response.objeto != null) {
                        Category = xhr.currentTarget.response.objeto;
                    } else {
                        Category = [];
                    }

                    resolve(Category);
                } else {
                    alert("Nenhuma categoria foi encontrada");
                }
            }

            Scripts.API.POST(options);
        });
    },
    Cards: async (dataOptions) => {
        return new Promise((resolve) => {
            var options = AjaxOptions;
            var dataJoined = dataOptions != null && dataOptions != undefined ? dataOptions.join(',') : '';

            //options.url = `${urlAPI}Syncronize/GetById?usuCod=${recuperaUserCodCookie()}&dataJoined=${dataJoined}`;
            options.url = `${urlAPI}Cards/GetByUsuCod?usuCod=${recuperaUserCodCookie()}&dataJoined=${dataJoined}`;
            options.method = 'POST';
            options.async = false;

            options.onload = (xhr, obj) => {
                
                if (xhr.currentTarget.response != null && xhr.currentTarget.response != undefined) {
                    if (xhr.currentTarget.response.success == false) {
                        Scripts.Elements.Message.Error(`Ocorreu um erro: ${xhr.currentTarget.response.erroMsg}`);
                        resolve(null);
                    }

                    var Wallet;

                    if (xhr.currentTarget.response.Objeto != undefined && xhr.currentTarget.response.Objeto != null) {
                        Wallet = xhr.currentTarget.response.Objeto;
                    } else {
                        Wallet = {
                            Cards: [],
                            Payments: [],
                            FlowClosed: []
                        }
                    }

                    resolve(Wallet);
                } else {
                    alert("Nenhuma carteira foi encontrada");
                }
            }

            if (dataOptions != null && dataOptions != undefined) {
                if (dataOptions.length > 0) {
                    dataJoined = dataOptions.join(',');
                }
            }

            /*  options.data = { 
                  usuCod: recuperaUserCodCookie(),
                  dataJoined: dataJoined
              };*/

            Scripts.API.POST(options);
        });
    }
}

var ImplementCardsList = {
    Cards: (index, codCard, amount, timeString, title, description, codBank, codWallet) => {
        try {
            var card = Scripts.Elements.Create('li', null, null,
                null, null, ['list-group-item', 'listItem', 'd-flex', 'justify-content-between', 'align-items-start', 'cards']);

            card.addEventListener('click', (element) => {
                Scripts.Elements.ToogleClass(element.currentTarget, 'cards', 'cardSelected', (element) => {
                    
                    Scripts.ElementList.ToogleDisabledElement('listItem ', 'cardSelected', 'erase');
                });
            });

            card.dataset['cod'] = codCard;

            var cabecalho = Scripts.Elements.Create('div', null, null,
                null, 'width: 100%;', ['ms-2', 'me-auto']);

            cabecalho.appendChild(Scripts.Elements.Create('i', null, null,
                null, null, ['fas', 'fa-check-circle']));

            cabecalho.innerText = `${title} - ${amount}`;

            var titulo = Scripts.Elements.Create('div', null, null,
                'fw-bold', null);            

            var spanTime = Scripts.Elements.Create('span', 'listGroup', null,
                null, null, ['badge', 'bg-primary', 'rounded-pill', 'spanTime']);

            var spanEdit = Scripts.Elements.Create('span', 'listGroup', null,
                null, null, ['badge', 'bg-primary', 'rounded-pill', 'spanTime']);

            var container = Scripts.Elements.Create('div', null, null, 'containerAction');

            spanTime.innerText = timeString;

            spanEdit.appendChild(Scripts.Elements.Create('i', null , null,
                null, null, ['far', 'fa-edit', 'spanTime']))

            spanEdit.addEventListener('click', (element) => {

                document.body.insertAdjacentHTML('beforeEnd', 
                `<div class="modal fade show" id="modalEdit" tabindex="-1" aria-labelledby="exampleModalLiveLabel" aria-modal="true" role="dialog" style="display: block;">    
                    <div class="modal-dialog">
                        <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                            <button type="button" onclick="fecharModal(this);" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body">
                        <div style="display: flex; gap: 56px; flex-wrap: wrap; justify-content: flex-start;">
                        <div class="mb-3">
                            <label for="disabledTextInput" class="form-label">Tipo</label>
                            <div class="selectionType">
                                <div class="btn-group dropend">
                                    <select style="background-color: cadetblue;" id="selectType" class="btn btn-secondary dropdown-toggle selectPrymary" data-bs-toggle="dropdown" aria-expanded="true">
                                        <option style="color: var(--colorPrymary5) !important; font-weight: bold !important; background-color: white !important; " class="dropdown-item-text">Selecione um tipo de Registro</option>
                                        <option class="dropdown-item optionSelect" value="0">Renda</option>
                                        <option class="dropdown-item optionSelect" value="1">Débito</option>
                                        <option class="dropdown-item optionSelect" value="2">Empréstimo</option>
                                    </select>
                                </div>
                            </div>

                            <label for="Title" class="form-label">Titulo</label>
                            <input id="Title" type="text" class="form-control" placeholder="Titulo do Registro">

                            <label for="Amount" class="form-label">Valor</label>
                            <input id="Amount" type="text" class="form-control" placeholder="Valor do Registro">
                        </div>
                        <div class="mb-3">
                            <label for="Date" class="form-label">Data</label>
                            <input id="Date" value="${'2022-04-01'}" type="date" class="form-control" placeholder="Data do Registro">

                            <label for="Category" class="form-label">Categoria</label>
                            <select id="Category" class="form-select"><option value="10">Salario</option><option value="11">Faturas</option><option value="12">Fatura Mensal</option><option value="13">Despesa</option></select>
                            
                        </div>
                        <div class="mb-3">
                            <label for="Description" class="form-label">Descrição</label>
                            <textarea id="Description" class="form-control"></textarea>
                        </div>                        
                    </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                        </div>
                    </div>
                </div>`);
            })

            container.appendChild(spanEdit);
            container.appendChild(spanTime);

            cabecalho.appendChild(titulo);
            cabecalho.appendChild(titulo);
            //cabecalho.appendChild(spanIndex);
            card.append(cabecalho);
            card.appendChild(container);

            return card;

        } catch (error) {
            console.log(error);
        }
    },
    Category: (Category) => {
        try {

            var category = Scripts.Elements.Create('li', null, null,
                null, null, ['list-group-item', 'd-flex', 'justify-content-between', 'align-items-start', 'cards', 'listItem']);

            var edit = Scripts.Elements.Create('i', null, null,
                null, null, ['fas', 'fa-pen', 'editItem']);

            category.addEventListener('click', (element) => {
                Scripts.Elements.ToogleClass(element.currentTarget, 'cards', 'cardSelected', (element) => {
                   
                    Scripts.ElementList.ToogleDisabledElement('listItem ', 'cardSelected', 'erase');
                });
            });

            category.dataset['cod'] = Category.ccCod;

            var cabecalho = Scripts.Elements.Create('div', null, null,
                null, 'width: 100%;', ['ms-2', 'me-auto']);

            cabecalho.appendChild(Scripts.Elements.Create('i', null, null,
                null, null, ['fas', 'fa-check-circle']));

            cabecalho.innerText = `${Category.ccName}`;

            var titulo = Scripts.Elements.Create('div', null, null,
                'fw-bold', null);

            var spanFixed = Scripts.Elements.Create('span', 'listcategory', null,
                null, null, ['badge', 'bg-primary', 'rounded-pill', 'spanTime']);

            spanFixed.innerText = Category.ccTypeFixed != false ? "Fixo" : "";

            cabecalho.appendChild(titulo);
            //cabecalho.appendChild(spanIndex);
            category.append(cabecalho);
            category.appendChild(spanFixed);
            category.appendChild(edit);
            return category;

        } catch (error) {
            console.log(error);
        }
    }
}

var fecharModal = (element) =>{
    document.getElementById('modalEdit').remove();
}

var ImplementList = async (type) => {
    try {           

        var ol = Scripts.Elements.Create('ol', 'listGroup', null, null, 'width: 100%; height: 100% !important; overflow: auto !important;', ['list-group', 'list-group-numbered']);
        var option;

        if (type == "Category") {
            var Category = await CarregaDados.Category();
            var lenSelect = document.getElementById('Category').children.length;

            for (var i = 0; i < Category.length; i++) {
                ol.appendChild(ImplementCardsList.Category(Category[i]));
            }

            document.querySelector("div[name=list]").appendChild(ol);

            for (var index = 0; index < lenSelect; index++) {
                document.getElementById('Category').removeChild(document.getElementById('Category').lastChild);
            }

            for (var index = 0; index < Category.length; index++) {
                option = Scripts.Elements.Create('option', null, 'optionsCategory');

                option.innerText = Category[index].ccName;
                option.value = Category[index].ccCod;

                document.getElementById('Category').append(option);
            }

        }
        else if (type == "Cards") {

            var Wallet = await CarregaDados.Cards();

            var totalizador = 0;

            var ol = Scripts.Elements.Create('ol', 'listGroup', null, null, 'height: 100% !important; overflow: auto !important;', ['list-group', 'list-group-numbered']);         

            for (var i = 0; i < Wallet.Cards.length; i++) {
                ol.appendChild(ImplementCardsList.Cards(i + 1, Wallet.Cards[i]?.CodCard, Wallet.Cards[i]?.Amount,
                    Wallet.Cards[i]?.TimeString, Wallet.Cards[i]?.title ?? ' - ', Wallet.Cards[i]?.Description));

                totalizador += parseFloat(Wallet.Cards[i].Amount.replaceAll("R$", "").replaceAll(",", "."));
            }          

            document.querySelector("div[name=list]").appendChild(ol);

            var divTotalizador = Scripts.Elements.Create('div', null, null,
                null, "display: flex; align-items: center; justify-content: center;", ['totalizador', 'cards']);

            var spanTotalizador = Scripts.Elements.Create('span', null, null,
                null);

            spanTotalizador.innerText = `Total: ${totalizador.toLocaleBR(totalizador)}`;

            divTotalizador.appendChild(spanTotalizador);
            divTotalizador.append(Scripts.Elements.Create('i', null, null,
                null, null, ["fas", "fa-coins"]));
            document.getElementById("listGroup").appendChild(divTotalizador);
        }
       
        document.getElementById('erase').addEventListener('click', (target, obj) => {
           
            var selected = document.querySelectorAll('.listItem');
            var existSelected = false;
            var classList = null;
            var itens = new Array();

            for (var i = 0; i < selected?.length; i++) {
                classList = selected[i].classList;

                if (classList?.value?.indexOf('cardSelected') != -1) {
                    itens.push(parseInt(selected[i]
                        .dataset['cod']));
                    existSelected = true;
                }
            }

            if (existSelected) {
                DeleteAll.Category(itens);
            }

        });

        document.getElementById('selectAll').addEventListener('click', (target, obj) => {
           
            selectAll('listItem', 'li', 'cards', 'cardSelected');
            Scripts.ElementList.ToogleDisabledElement('listItem ', 'cardSelected', 'erase');
        });
      
    } catch (error) {
        console.log(error);
    }
}


//Métodos nativos reescritos

Number.prototype.toLocaleBR = (number) => {
    return number.toLocaleString('pt-BR', { minimumFractionDigits: 2, style: 'currency', currency: 'BRL' });
}