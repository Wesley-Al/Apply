﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class FlowClosed
    {
        [Key]
        public long CodFlowClosed { get; set; }        
        public string Amount { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string TimeString { get; set; }
        public string Title { get; set; }
        public long CodWallet { get; set; }
    }
}
