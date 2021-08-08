using Apply.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Core.Context
{
    public class Context : DbContext
    {
        DbSet<Wallet> Wallet { get; set; }
        DbSet<Cards> Card { get; set; }
        DbSet<FlowClosed> FlowClosed { get; set; }

        DbSet<Payment> Payment { get; set; }        
    }
}
