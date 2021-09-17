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
    public class SecurityController : ControllerBase
    {
        private IWalletService iWalletSVC;
        private ISecurityService iSecuritySVC;

        public SecurityController(IWalletService WalletSVC,
                                  ISecurityService SecuritySVC)
        {
            this.iSecuritySVC = SecuritySVC;
            this.iWalletSVC = WalletSVC;
        }        

        [HttpPost("Cadastro")]
        public IActionResult Cadastro([FromBody] Usuario usuario)
        {
            Retorno<bool> retorno = new Retorno<bool>
            {
                Objeto = false,
                Success = true
            };

            try
            {
                if (!iSecuritySVC.VerificaUsuario(usuario.UsuarioLogin))
                {
                    if (iSecuritySVC.CadastraUsuario(usuario))
                    {
                        retorno.Objeto = true;
                    }
                    else
                    {
                        retorno.Objeto = false;
                        retorno.ErroMsg = "Ocorreu um erro durante a execução.";
                    }
                }
                else
                {
                    retorno.Objeto = false;
                    retorno.ErroMsg = "O Usuário informado ja existe";
                }               

                return Ok(retorno);
            }
            catch (Exception error)
            {
                return Ok(error);
            }
        }

        [HttpPost("Autentication")]
        public IActionResult Autentication([FromBody] Usuario usuario)
        {
            Retorno<UsuarioParameters> retorno = new Retorno<UsuarioParameters>
            {
                Objeto = new UsuarioParameters(),
                Success = true
            };

            try
            {
                if (iSecuritySVC.AtenticaUsuario(usuario))
                {
                    Usuario user = iSecuritySVC.GetByUsuLogin(usuario.UsuarioLogin);
                    retorno.Objeto.UsuNome = user.NomeUsuario;
                    retorno.Objeto.UsuCod= user.CodUsuario;
                }
                else
                {
                    retorno.Objeto = null;
                    retorno.ErroMsg = "Sua senha ou seu usuário podem estar incorretos.";
                }

                return Ok(retorno);
            }
            catch (Exception error)
            {
                return Ok(error);
            }
        }
    }
}
