﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class Payment
    {
        [Key]
        public long CodPayment { get; set; }        
        public string Amount { get; set; }
        public DateTime Time { get; set; }
        public string TimeString { get; set; }
        public string Title { get; set; }
        public long CodWallet { get; set; }
    }
}
