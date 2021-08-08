document.addEventListener('DOMContentLoaded', () =>{
    document.getElementById("sincronize").addEventListener("click", ()=>{        
        sendMessage();
    });
});

function sendMessage(message = true){ 
    /*
        parametro""tabs" - possui todas as tabs         
        tabs[].id - id da tab atual
        message - A mensagem a ser enviada
        function - resposta da requisição
    */
    chrome.tabs.query({active: true, currentWindow: true}, (tabs)=>{        
        chrome.tabs.sendMessage(tabs[0].id, JSON.stringify(message), (response)=>{    
            debugger        
            console.log(response);
        });
    });
}

var Http = {
    PostWallet: () => {
        var http = new XMLHttpRequest();

        http.open('POST', 'localhost:1024/api/PostWallet');
        http.onload = (xhr, response, obj) =>{
            debugger;
        }

        http.response = (xhr, response, obj) => {
            debugger;
        }

        http.send();
        http.onerror = (xhr, response, obj) =>{
            alert('Erro');
        }

    }
}
 