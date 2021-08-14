using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class Usuario
    {
        [Key]
        public long CodUsuario { get; set; }        
        public DateTime DtCadastro { get; set; }
        public string Nome { get; set; }
        public long CodWallet { get; set; }
        public Wallet WalletNavigation { get; set; }
    }
}
