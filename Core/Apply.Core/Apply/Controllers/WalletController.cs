using Apply.Library;
using Apply.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {

        private IWalletService iWalletSVC;
        private ICardsService iCardsSVC;

        public WalletController(IWalletService WalletSVC,
                                ICardsService CardsSVC)                                  
        {            
            this.iWalletSVC = WalletSVC;
            this.iCardsSVC = CardsSVC;
        }

        [HttpPost("Delete")]
        public ActionResult Delete([FromBody]string joinedCod)
        {
            try
            {
                var codArray = joinedCod.Split(",");
                
                return Ok();

            }catch(Exception error)
            {
                return Ok(error.Message);
            }
        }

        [HttpPost("DeleteAllCards")]
        public ActionResult DeleteAllCards([FromBody]long usuCod)
        {
            try
            {
                var wallet = iWalletSVC.GetWalletByUsuCod(usuCod);

                return Ok(iCardsSVC.DeleteAll(wallet.CodWallet));

            }
            catch (Exception error)
            {
                return Ok(error.Message);
            }
        }
    }
}
