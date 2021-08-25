using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class UsuarioWallet
    {
        [Key]
        public long UWCod { get; set; }
        public Usuario CodUsuario { get; set; }
        public Wallet CodWallet { get; set; }
    }
}
