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
            Category: 0,
            Description: "",
            UsuCod: 0
        };

        Card.Title = `${document.getElementById(`Title`)?.value}`;
        Card.Amount = `${document.getElementById(`Amount`)?.value}`;
        Card.Type = `${document.getElementById(`selectType`)?.value}`;
        Card.Date = new Date(document.getElementById(`Date`)?.value?.replaceAll('-', '/'));
        Card.Description = document.getElementById(`Description`)?.value;
        Card.Category = document.getElementById(`Category`)?.value;
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
            CCTypeFixed : false,
            UsuCod: 0
        };        

        CategoryParameter.CCName = `${document.getElementById(`CategoryName`)?.value}`;        
        CategoryParameter.UsuCod = parseInt(recuperaUserCodCookie());

        options.data = CategoryParameter;
        options.method = 'POST';
        options.url = `${urlAPI}Category/CadastrarCategoria`;

        Scripts.API.POST(options);

    } catch (error) {
        Scripts.Elements.Message.Error(error);
        setTimeout(() => { Scripts.Elements.Message; }, 3000);
    }
}
