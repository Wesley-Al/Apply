using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apply.Services
{
    public interface ISecurityService
    {
        bool CadastraUsuario(Usuario usuario);
        bool AtenticaUsuario(Usuario usuario);
        Usuario GetByUsuLogin(string usuarioLogin);
        bool VerificaUsuario(string usuarioLogin);
    }
}
