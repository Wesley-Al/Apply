const Usuario = {
    AutenticaUsuario: (pUsuario, pSenha) => {
        var Usuario = {
            Usuario: pUsuario,
            Senha: pSenha
        }

        var option = AjaxOptions;

        option.data = Usuario;
        option.method = 'GET';
        option.url = `${urlAPI}/Security/Login/Autentication`;
        Scripts.API.GET(option);
    },
    CadastraUsuario: (pUsuario, pSenha, nomeUsuario) => {
        var Usuario = {
            Usuario: pUsuario,
            Senha: pSenha,
            NomeUsuario: nomeUsuario
        }

        var option = AjaxOptions;

        option.data = Usuario;
        option.method = 'POST';
        option.url = `${urlAPI}/Security/Login/Cadastro`;
        Scripts.API.POST(option);
    }
}