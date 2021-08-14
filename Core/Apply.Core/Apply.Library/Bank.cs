using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Apply.Library
{
    public class Bank
    {
        [Key]
        public long CodBank { get; set; }
        public string NameBank { get; set; }                
    }
}
