using Microsoft.EntityFrameworkCore;
using CarForSale.DataAccess.Entities;

namespace CarForSale.DataAccess
{
    public interface IDataAccessDbContext
    {
        DbSet<Fornecedor> Fornecedores { get; set; }
        DbSet<Carro> Carros { get; set; }
        DbSet<Moto> Motos { get; set; }
        DbSet<Veiculo> Veiculos { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        int SaveChanges();
    }
}
