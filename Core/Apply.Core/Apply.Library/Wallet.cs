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

        public int CodUsuario { get; set; }        

        public int CodPayment { get; set; }
        public ICollection<Payment> PaymentNavigation { get; set; }

        public int CodCards { get; set; }
        public ICollection<Cards> CardsNavigation { get; set; }

        public int CodFlowClosed { get; set; }
        public ICollection<FlowClosed> FlowClosedNavigation { get; set; }
        public long CodBank { get; set; }
        public Bank BankNavigation { get; set; }

    }
}
