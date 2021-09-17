using Apply.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Apply.Services;
using System.Collections;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace Apply.Controllers
{
    [ApiController]    
    [Route("[controller]")]
    public class SyncronizeController : ControllerBase
    {
        private IWalletService iWalletSVC;
        public SyncronizeController(IWalletService WalletSVC)                                  
        {            
            this.iWalletSVC = WalletSVC;
        }

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

        [HttpPost("GetById")]
        public IActionResult GetById(long usuCod, string dataJoined)
        {
            Retorno<WalletParameters> retorno = new Retorno<WalletParameters>();            
            try
            {
                retorno.Success = true;
                retorno.Objeto = iWalletSVC.GetByUsuCod(usuCod, dataJoined);                
                
                return Ok(JsonConvert.SerializeObject(retorno));
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
