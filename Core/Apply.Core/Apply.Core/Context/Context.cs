using Apply.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Core
{
    public class Context : DbContext
    {
        
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        DbSet<Wallet> Wallet { get; set; }
        DbSet<Cards> Card { get; set; }
        DbSet<FlowClosed> FlowClosed { get; set; }
        DbSet<Payment> Payment { get; set; }
        DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Password={Programador};Persist Security Info=True;User ID=Wesley;Initial Catalog=ApplyNubank;Data Source=DESKTOP-C3Q3K9Q");            
        }
    }
}
