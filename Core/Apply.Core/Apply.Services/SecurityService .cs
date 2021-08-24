using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Apply.Services
{
    public class SecurityService
    {
        private Context Context { get; set; }

        public SecurityService()
        {
            this.Context = new Context();
        }

        public bool CadastraUsuario(Usuario usuario)
        {
            try
            {
                usuario.WalletNavigation = new Wallet();
                usuario.DtCadastro = DateTime.Now;
                
                Context.Usuario.Add(usuario);

                Context.SaveChanges();

                return true;
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        public Usuario GetByUsuLogin(string usuarioLogin)
        {
            return Context.Usuario.Where(x => x.UsuarioLogin == usuarioLogin).FirstOrDefault();
        }
        public bool AtenticaUsuario(Usuario usuario)
        {
            return Context.Usuario.FirstOrDefault(x => x.UsuarioLogin.Equals(usuario.UsuarioLogin) && x.Senha.Equals(usuario.Senha)) != null;
        }
        public bool VerificaUsuario(string usuarioLogin)
        {
            return Context.Usuario.FirstOrDefault(x => x.UsuarioLogin == usuarioLogin) != null;
        }
    }
}
