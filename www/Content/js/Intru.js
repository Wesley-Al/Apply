function Autenticar() {
    Usuario.AutenticaUsuario(document.getElementById('usuLogin').value, document.getElementById('senhaLogin').value);
}

function CadastraCard() {
    try {
        var options = AjaxOptions;
        var Card = {
            Title: "",
            Amount: "",
            Type: "",
            Date: Date(),
            CCCod: 0,
            Description: "",
            UsuCod: 0
        };

        Card.Title = `${document.getElementById(`Title`)?.value}`;
        Card.Amount = `${document.getElementById(`Amount`)?.value}`;
        Card.Type = `${document.getElementById(`selectType`)?.value}`;
        Card.Date = new Date(document.getElementById(`Date`)?.value?.replaceAll('-', '/'));
        Card.Description = document.getElementById(`Description`)?.value;
        Card.CCCod = document.getElementById(`Category`)?.value;
        Card.UsuCod = parseInt(recuperaUserCodCookie());

        options.data = Card;
        options.method = 'POST';
        options.url = `${urlAPI}Cards/CadastrarCard`;

        Scripts.API.POST(options);

    } catch (error) {
        Scripts.Elements.Message.Error(error);
        setTimeout(() => { Scripts.Elements.Message; }, 3000);
    }
}

function CadastraCategoria() {
    try {        
        var options = AjaxOptions;
        var CategoryParameter = {
            CCName: "",
            CCTypeFixed: false,
            UsuCod: 0
        };

        CategoryParameter.CCName = `${document.getElementById(`CategoryName`)?.value}`;
        CategoryParameter.UsuCod = parseInt(recuperaUserCodCookie());
        CategoryParameter.CCTypeFixed = document.getElementById('TypeFixed').checked;

        options.data = CategoryParameter;
        options.method = 'POST';
        options.url = `${urlAPI}Category/CadastrarCategoria`;
        options.onload = (xhr, obj) => {
            try {
                var response = xhr.currentTarget.response;

                if (response.success != true) {
                    alert(response.erroMsg);
                } else {
                    AtualizaList.Category();
                }

            } catch (error) {
                alert(error);
            }
        }

        Scripts.API.POST(options);

    } catch (error) {
        Scripts.Elements.Message.Error(error);
        setTimeout(() => { Scripts.Elements.Message; }, 3000);
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
            document.getElementById('listCategoryUser')?.remove();

            ImplementaCategory();

        } catch (error) {
            alert(error);
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
                        Category = xhr.currentTarget.response.objeto ;
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

            options.url = `${urlAPI}Cards/GetById?usuCod=${recuperaUserCodCookie()}&dataJoined=${dataJoined}`;
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

var ImplementList = {
    Cards: (index, codCard, amount, timeString, title, description, codBank, codWallet) => {
        try {
            var card = Scripts.Elements.Create('li', null, null,
                null, null, ['list-group-item', 'd-flex', 'justify-content-between', 'align-items-start', 'cards']);

            card.dataset['cod'] = codCard;

            var cabecalho = Scripts.Elements.Create('div', null, null,
                null, 'width: 100%;', ['ms-2', 'me-auto']);

            cabecalho.appendChild(Scripts.Elements.Create('i', null, null,
                null, null, ['fas', 'fa-check-circle']));

            cabecalho.innerText = `${description} - ${amount}`;

            var titulo = Scripts.Elements.Create('div', null, null,
                'fw-bold', null);

            //titulo.innerText = title;

            //var spanIndex = Scripts.Elements.Create('span', 'listCard', null,
            //    null, null, ['badge', 'bg-primary', 'rounded-pill']);

            //spanIndex.innerText = index;

            var spanTime = Scripts.Elements.Create('span', 'listCard', null,
                null, null, ['badge', 'bg-primary', 'rounded-pill', 'spanTime']);

            spanTime.innerText = timeString;

            cabecalho.appendChild(titulo);
            cabecalho.appendChild(titulo);
            //cabecalho.appendChild(spanIndex);
            card.append(cabecalho);
            card.appendChild(spanTime);

            return card;

        } catch (error) {
            console.log(error);
        }
    },
    Category: (Category) => {
        try {

            debugger;

            var category = Scripts.Elements.Create('li', null, null,
                null, null, ['list-group-item', 'd-flex', 'justify-content-between', 'align-items-start', 'cards', 'categoryItem']);

            category.addEventListener('click', (element) => {
                Scripts.Elements.ToogleClass(element.currentTarget, 'cards', 'cardSelected', (element) => {
                    Scripts.ElementList.ToogleDisabledElement('categoryItem ', 'cardSelected', 'eraseCategory');
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

            return category;

        } catch (error) {
            console.log(error);
        }
    }
}

var ImplementaCategory = async () => {
    try {

        var Category = await CarregaDados.Category();       

        var ol = Scripts.Elements.Create('ol', 'listCategoryUser', null, null, 'width: 100%; height: 100% !important; overflow: auto !important;', ['list-group', 'list-group-numbered']);        

        for (var i = 0; i < Category.length; i++) {
            ol.appendChild(ImplementList.Category(Category[i]));            
        }

        document.getElementById("listCategory").appendChild(ol);
        
        var option;
        var lenSelect = document.getElementById('Category').children.length;

        for (var index = 0; index < lenSelect; index++) {
            document.getElementById('Category').removeChild(document.getElementById('Category').lastChild);
        }

        for (var index = 0; index < Category.length; index++) {
            option = Scripts.Elements.Create('option', null, 'optionsCategory');

            option.innerText = Category[index].ccName;
            option.value = Category[index].ccCod;

            document.getElementById('Category').append(option);
        }
    } catch (error) {
        console.log(error);
    }
}

var ImplementGrafico = async (dataOptions) => {
    try {

        var Wallet = await CarregaDados(dataOptions);

        var chartData = ChartData;

        var data = new Array;
        var dataSet = new Array;
        var label = new Array;
        var totalizador = 0;

        var ol = Scripts.Elements.Create('ol', 'listCard', null, null, 'height: 100% !important; overflow: auto !important;', ['list-group', 'list-group-numbered']);

        var configTime = null;

        for (var i = 0; i < Wallet.Cards.length; i++) {
            ol.appendChild(ImplementList.Cards(i + 1, Wallet.Cards[i]?.CodCard, Wallet.Cards[i]?.Amount,
                Wallet.Cards[i]?.TimeString, Wallet.Cards[i]?.title ?? ' - ', Wallet.Cards[i]?.Description));

            totalizador += parseFloat(Wallet.Cards[i].Amount.replaceAll("R$", "").replaceAll(",", "."));
        }

        for (var i = 0; i < MonthColor.length; i++) {
            var result = Wallet.Cards.filter(x => x.TimeString.indexOf(MonthColor[i].month) > -1);

            if (Array.isArray(result)) {
                var total = 0;
                for (var o = 0; o < result.length; o++) {
                    total += parseFloat(Wallet.Cards[o].Amount.replaceAll("R$", "").replaceAll(",", "."));
                }

                data.push(total);

            } else if (result != null) {
                data.push(parseFloat(result.Amount.replaceAll("R$", "").replaceAll(",", ".")));
            }

            label.push(MonthColor[i].month);
        }

        dataSet.push({
            label: ["Gastos"],
            data: data,
            backgroundColor: '#7542ff',
            borderWidth: 2,
            borderColor: '#7542ff'
        });

        document.getElementById("listCards").appendChild(ol);

        var divTotalizador = Scripts.Elements.Create('div', null, null,
            null, "display: flex; align-items: center; justify-content: center;", ['totalizador', 'cards']);

        var spanTotalizador = Scripts.Elements.Create('span', null, null,
            null);

        spanTotalizador.innerText = `Total: ${totalizador.toLocaleBR(totalizador)}`;

        divTotalizador.appendChild(spanTotalizador);
        divTotalizador.append(Scripts.Elements.Create('i', null, null,
            null, null, ["fas", "fa-coins"]));
        document.getElementById("listCards").appendChild(divTotalizador);

        chartData.labels = label;
        chartData.datasets = dataSet;

        Scripts.Grafico.NewChart(Scripts.Grafico.ConfigChart('line', chartData),
            "graficoLine");

    } catch (error) {
        console.log(error);
    }
}

var DeleteAll = {
    Category: async (itens) => {
        if (confirm('Deseja apagar as Categorias?')) {
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

var ImplementMonthsOptions = () => {
    try {

        for (var i = 0; i <= MonthColor.length; i++) {
            var checkbox = Scripts.Elements.Create('input', `option${MonthColor[i].month}`, 'month',
                'btn-check', null, null, (event) => { AtualizaDados(event, event.target); }, 'checkbox');

            var label = Scripts.Elements.Create('label', null, null,
                'btn-check', null, ['btn', 'btn-outline-primary']);

            checkbox.value = MonthColor[i].month;

            label.innerText = MonthColor[i].month;
            label.htmlFor = `option${MonthColor[i].month}`;

            document.getElementById('groupMonth').appendChild(checkbox);
            document.getElementById('groupMonth').appendChild(label);
        }

    } catch (Error) {

    }
}