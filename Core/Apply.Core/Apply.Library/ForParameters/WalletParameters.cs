using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Apply.Library
{
    public class WalletParameters
    {        
        public long CodUsuario { get; set; }
        
        [FromQuery(Name = "Payments[]")]
        [JsonIgnore]
        public List<Payment> Payments { get; set; }

        [FromQuery(Name = "Cards[]")]
        [JsonIgnore]
        public List<Cards> Cards { get; set; }

        [FromQuery(Name = "FlowClosed[]")]
        [JsonIgnore]
        public List<FlowClosed> FlowClosed { get; set; }

        [JsonIgnore]
        public List<string> TimeString { get; set; }
        public long CodBank { get; set; }
    }
}
