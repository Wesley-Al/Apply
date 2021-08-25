using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class Wallet
    {
        [Key]
        public long CodWallet { get; set; }

        public DateTime DtCadastro { get; set; }
        public long CodBank { get; set; }
        public Bank BankNavigation { get; set; }

    }
}
