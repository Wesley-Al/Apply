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
        try{
            chrome.tabs.sendMessage(tabs[0].id, JSON.stringify(message), (response)=>{    
                                    
                if(response != undefined){
                    Http.PostWallet(JSON.parse(response));                 
                }else{
                    console.log("error");
                }
            });
        }catch(error){
            console.log(error);
        }        
    });
}

var Http = {
    PostWallet: (Wallet) => {
        
        var http = new XMLHttpRequest();

        http.open('POST', 'https://localhost:44395/API/Syncronize/Post');
        http.responseType = 'json';

        http.setRequestHeader('Content-Type', 'application/json');
        http.onload = (xhr, response, obj) =>{
            
        }

        http.response = (xhr, response, obj) => {
            
        }
        http.onerror = (xhr, response, obj) =>{
            
            console.log(xhr);
        }

        http.send(JSON.stringify(Wallet));
        //http.upload();
        

    }
}
 
