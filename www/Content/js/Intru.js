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
            TypeCard: "C",
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
        debugger;
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

var ImplementGrafico = async (dataOptions) => {
    try {
       
        var Wallet = await CarregaDados.Cards(dataOptions);

        var chartData = ChartData;

        var data = new Array;
        var dataSet = new Array;
        var label = new Array;
        var totalizador = 0;

        for (var m = 0; m < MonthColor.length; m++) {

            label.push(MonthColor[m].month);
        }

        for (var i = 0; i < TipoRegistroColor.length; i++) {
            var data = new Array;
            totalizador = 0;

            for (var m = 0; m < MonthColor.length; m++) {

                var cards = Wallet.Cards.filter(x => x.TimeString.indexOf(MonthColor[m].month) > -1 && x.Type == TipoRegistroColor[i].cod);
                var total = 0;

                for (var index = 0; index < cards.length; index++) {
                    total += parseFloat(cards[index].Amount.replaceAll("R$", "").replaceAll(",", "."));
                    totalizador += total;
                }
                
                data.push(total);
            }

            dataSet.push({
                label: TipoRegistroColor[i].name,
                data: data,
                backgroundColor: TipoRegistroColor[i].color,
                borderWidth: 2,
                borderColor: TipoRegistroColor[i].color
            });
           
            var divTotalizador = Scripts.Elements.Create('div', null, null,
                null, `background-color: ${TipoRegistroColor[i].color} !important; display: flex; align-items: center; justify-content: center;`, ['totalizador', 'cards']);

            var spanTotalizador = Scripts.Elements.Create('span', null, null,
                null);

            spanTotalizador.innerText = `Total ${TipoRegistroColor[i].name}: ${totalizador.toLocaleBR(totalizador)}`;

            divTotalizador.appendChild(spanTotalizador);
            divTotalizador.append(Scripts.Elements.Create('i', null, null,
                null, null, ["fas", "fa-coins"]));
            document.getElementById("totalizadores").appendChild(divTotalizador);
        }                     

        chartData.labels = label;
        chartData.datasets = dataSet;

        Scripts.Grafico.NewChart(Scripts.Grafico.ConfigChart('line', chartData),
            "graficoLine");

    } catch (error) {
        console.log(error);
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