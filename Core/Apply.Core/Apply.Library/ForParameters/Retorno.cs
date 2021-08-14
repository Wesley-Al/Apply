using System;
using System.Collections.Generic;
using System.Text;

namespace Apply.Library
{
    public class Retorno<T> : Retorno
    {
        public T Objeto { get; set; } 
    }

    public class Retorno
    {
        public string ErroMsg { get; set; }
        public bool Success { get; set; }
    }
}
