using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarForSale.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace CarForSale.Model
{
    public class ApiDbContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((_, __) => true, true)
        });

        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object
                .EnableSensitiveDataLogging();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new AutomovelConfiguration());
        //    base.OnModelCreating(modelBuilder);
        //}


        public DbSet<Fornecedor> Fornecedores { get; set; }   
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        
    }
}
