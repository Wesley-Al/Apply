using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apply.Library
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<Cards> Card { get; set; }        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<UsuarioWallet> UsuarioWallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Password={Programador};Persist Security Info=True;User ID=Wesley;Initial Catalog=Apply;Data Source=DESKTOP-C3Q3K9Q");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost; port=3306; database=Apply; user=root; password={Programador}2; Persist Security Info=False",
                        ServerVersion.AutoDetect("server=localhost; port=3306; database=Apply; user=root; password={Programador}2; Persist Security Info=False"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
