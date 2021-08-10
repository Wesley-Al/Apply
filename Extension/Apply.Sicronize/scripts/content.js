var Execute = {    
    /**
     * 
     * @returns Retorna os dados de uso do cartão
     */
    ReturnCards: () =>{
      
        var cards = new Array();        
        
        document.querySelectorAll('.card_not_present').forEach((element, index) =>{
            var CardNotPresent = {};
            
            CardNotPresent.Title = element.children[1].innerText;
            CardNotPresent.Description = element.children[2].innerText;
            CardNotPresent.Amount = element.children[3].innerText;
            CardNotPresent.TimeString = element.children[5].innerText;            
            CardNotPresent.NotPayment = true;            
            CardNotPresent.CodWallet = 10;            

            cards.push(CardNotPresent);    
        });

        document.querySelectorAll('.card_present').forEach((element, index) =>{            
            var CardPresent = {};

            CardPresent.Title = element.children[1].innerText;
            CardPresent.Description = element.children[2].innerText;
            CardPresent.Amount = element.children[3].innerText;
            CardPresent.TimeString = element.children[5].innerText;            
            CardPresent.NotPayment = false;            
            CardPresent.CodWallet = 10;            

            cards.push(CardPresent);    
        });

        return cards;
    },
     /**
     * 
     * @returns Retorna os dados de pagamento
     */
    ReturnPayments: () =>{
        /*for (i = 0; i < payment.length; i++) {
          wallet.total +=
              `${payment[i].innerHTML}` != "" && `${payment[i].innerHTML}` != null
                ? parseFloat(`${payment[i].innerHTML}`.replaceAll("R$", ""))
                : "";
        }*/

        var payments = new Array();            
        
        document.querySelectorAll(".payment").forEach((element, index) =>{
            var Payment = {};
            
            Payment.Title = element.children[1].innerText;            
            Payment.Amount = element.children[2].innerText;
            Payment.TimeString = element.children[4].innerText;            

            payments.push(Payment);    
        });

        return payments;
    },
     /**
     * 
     * @returns Retorna os dados de fechamento do cartao
     */
    ReturnFlowClosed: () =>{
        var flowCloseds = new Array();            
        
        document.querySelectorAll(".bill_flow_closed").forEach((element, index) =>{
            var FlowClosed = {};
            
            FlowClosed.Title = element.children[1].innerText; 
            FlowClosed.Description = element.children[2].innerText;           
            FlowClosed.Amount = element.children[3].innerText;
            FlowClosed.TimeString = element.children[5].innerText;            

            flowCloseds.push(FlowClosed);    
        });

        return flowCloseds;
    }

}

chrome.runtime.onMessage.addListener((request, sender, sendResponse) => {        
try{
    debugger;
    var Wallet = {};
    Wallet.Cards = Execute.ReturnCards();
    Wallet.Payments = Execute.ReturnPayments();
    Wallet.FlowClosed = Execute.ReturnFlowClosed();
  
    console.log(Wallet);
  
    sendResponse(JSON.stringify(Wallet));
}catch(error){
    alert("Ocorreu um erro ao tentar sincronizar os dados, por favor cheque o log.")
    console.log(error);
}  
});
