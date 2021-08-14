using Apply.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apply.Services;
using System.Collections;

namespace Apply.Core.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class SyncronizeController : ControllerBase
    {
        private WalletService iWalletSVC = new WalletService();
       

        [HttpPost("Post")]        
        public async Task<IActionResult> Post([FromBody] WalletParameters wallet)
        {            
            try
            {
                if (wallet != null)
                {
                    await iWalletSVC.InsertData(wallet);
                }

                return Ok(true);
            }
            catch (Exception error)
            {
                return Ok(error);
            }
        }

        [HttpGet("Get")]
        public IActionResult Get(/*long codBank, long codWallet*/)
        {
            Retorno<WalletParameters> retorno = new Retorno<WalletParameters>();
            long codBank = 1, codWallet = 3;
            try
            {
                retorno.Success = true;
                retorno.Objeto = iWalletSVC.Get(codBank = 1, codWallet = 3);

                return Ok(retorno);
            }
            catch (Exception error)
            {
                retorno.Success = false;
                retorno.Objeto = null;
                retorno.ErroMsg = error.Message;

                return Ok(retorno);
            }
        }
    }

    public enum Bank
    {        
        Nubank
    }
}