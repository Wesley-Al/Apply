using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class Cards
    {
        [Key]
        public long CodCard { get; set; }
        public bool NotPayment { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public long CodWallet { get; set; }
    }
}
