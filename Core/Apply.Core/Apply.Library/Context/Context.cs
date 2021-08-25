using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Library
{
    public class Context : DbContext
    {        
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Cards> Card { get; set; }
        public DbSet<FlowClosed> FlowClosed { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<UsuarioWallet> UsuarioWallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password={Programador};Persist Security Info=True;User ID=Wesley;Initial Catalog=Apply;Data Source=DESKTOP-C3Q3K9Q");
        }
    }
}
