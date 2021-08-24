const Usuario = {
    AutenticaUsuario: (pUsuario, pSenha) => {
        var Usuario = {
            UsuarioLogin: pUsuario,
            Senha: pSenha
        }

        var option = AjaxOptions;

        option.onload = (xhr, response, obj) => {
            var response = xhr.target.response;
            
            if (response.success == true) {
                if (response.objeto != null) {
                    document.cookie = `username=${response.objeto.UsuNome}; path=/;`;
                    document.cookie = `username=${response.objeto.UsuCod}; path=/;`;

                    Scripts.Elements.Message.Success("Efetuando o Login...");
                    Scripts.Elements.Load.Create('Growing', 'messageContent', 'width: 1rem !important; height: 1rem !important;', 'var(--colorPrymary6)');                    

                    setTimeout(() => { window.location.href = `${urlAPI}/Nubank/index.html`; }, 3000);

                } else {
                    Scripts.Elements.Message.Error(response.erroMsg);
                }
            } else {
                Scripts.Elements.Message.Error(`Ocorreu um erro durante o processo: ${response.erroMsg}`);
            }
        }

        option.data = Usuario;
        option.method = 'POST';
        option.url = `${urlAPI}/api/Security/Autentication`;
        Scripts.API.POST(option);
    },
    CadastraUsuario: (pUsuario, pSenha, nomeUsuario) => {
        var Usuario = {
            UsuarioLogin: pUsuario,
            Senha: pSenha,
            NomeUsuario: nomeUsuario
        }

        var option = AjaxOptions;

        option.onload = (xhr, response, obj) => {
            var response = xhr.target.response;
            
            if (response.success == true) {
                if (response.objeto == true) {
                    Scripts.Elements.Message.Success("Usuario Cadastrado com sucesso!");
                } else {
                    Scripts.Elements.Message.Error(response.erroMsg);
                }
            } else {
                Scripts.Elements.Message.Error(`Ocorreu um erro durante o processo: ${response.erroMsg}`);
            }
        }

        option.data = Usuario;
        option.method = 'POST';
        option.url = `${urlAPI}/api/Security/Cadastro`;
        Scripts.API.POST(option);
    }
}