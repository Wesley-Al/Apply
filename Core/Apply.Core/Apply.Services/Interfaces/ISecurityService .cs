using Apply.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apply.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<bool> CadastraUsuario(Usuario usuario);
        Task<bool> AtenticaUsuario(Usuario usuario);
    }
}
