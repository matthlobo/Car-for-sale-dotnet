using Microsoft.EntityFrameworkCore;
using CarForSale.DataAccess;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;
using CarForSale.DataAccess.Entities;

namespace CarForSale
{
    public class ApiDbContext : DbContext, IDataAccessDbContext
    {
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
              new ConsoleLoggerProvider((_, __) => true, true)
        });

        public ApiDbContext(DbContextOptions options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
