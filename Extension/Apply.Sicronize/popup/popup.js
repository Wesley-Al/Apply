document.addEventListener('DOMContentLoaded', () => {
    document.querySelector(".login").addEventListener("click", () => {
        Autenticar()
    });

    document.getElementById("logout").addEventListener("click", () => {
        logOutPop();
    });

    document.getElementById("sincronize").addEventListener("click", () => {
        sendMessage();
    });
    
    validaCookie();
});

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
                    document.cookie = `usercod=${response.objeto.usuCod}; path=/;`;
                    document.cookie = `username=${response.objeto.usuNome}; path=/;`;

                    setTimeout(() => { validaCookie(); }, 3000)

                } else {
                    Scripts.Elements.Message.Error(response.erroMsg);
                }
            } else {
                Scripts.Elements.Message.Error(`Ocorreu um erro durante o processo: ${response.erroMsg}`);
            }
        }

        option.data = Usuario;
        option.method = 'POST';
        option.url = `http://apply.client/api/Security/Autentication`;
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
        option.url = `${urlAPI}Security/Cadastro`;
        Scripts.API.POST(option);
    }
}

var logOutPop = function () {
    
    document.cookie = `username=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;
    document.cookie = `usercod=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`;

    setTimeout(() => { validaCookie() }, 2000);
}

function Autenticar() {
    Usuario.AutenticaUsuario(document.getElementById('usuLogin').value, document.getElementById('senhaLogin').value);
}

function validaCookie() {
    
    var cookie = document.cookie.split(';')
    cod = cookie[0].replaceAll('usercod=', '');

    if (cod != null && cod != "") {
        document.getElementById("sincronizar").style.display = '';
        document.getElementById("sincronizar").style.opacity = 1;
        document.getElementById("login").style.display = 'none';
        document.getElementById("login").style.opacity = 0;
    } else {
        document.getElementById("sincronizar").style.display = 'none';
        document.getElementById("sincronizar").style.opacity = 0;
        document.getElementById("login").style.display = '';
        document.getElementById("login").style.opacity = 1;
    }
}

function sendMessage(message = true) {
    /*
        parametro""tabs" - possui todas as tabs         
        tabs[].id - id da tab atual
        message - A mensagem a ser enviada
        function - resposta da requisição
    */
    chrome.tabs.query({ active: true, currentWindow: true }, (tabs) => {
        try {
            chrome.tabs.sendMessage(tabs[0].id, JSON.stringify(message), (response) => {

                if (response != undefined) {
                    Http.PostWallet(JSON.parse(response));
                } else {
                    console.log("error");
                }
            });
        } catch (error) {
            console.log(error);
        }
    });
}

var recuperaUserNameCookie = function () {
    try {
        var cookie = document.cookie.split(';')
        return cookie[1].replaceAll('username=', '');

    } catch (error) {
        return null;
    }
};

var recuperaUserCodCookie = function () {
    
    try {
        var cookie = document.cookie.split(';')
        return cookie[0].replaceAll('usercod=', '');
    } catch (error) {
        return null;
    }
};

var Http = {
    PostWallet: (Wallet) => {
        

        Wallet.CodUsuario = recuperaUserCodCookie();

        var option = AjaxOptions;

        option.onload = (xhr, response, obj) => {
            var response = xhr.target.response;
            if (response == true) {
                Scripts.Elements.Message.Success("Sincronizado com sucesso!");
            } else {
                Scripts.Elements.Message.Error(`Ocorreu um erro durante o processo.`);
            }
        }

        option.data = Wallet;
        option.method = 'POST';
        option.url = 'http://apply.client/api/Syncronize/Post';
        //        option.url = 'https://localhost:44382/Syncronize/Post';        
        Scripts.API.POST(option);
    }
}

