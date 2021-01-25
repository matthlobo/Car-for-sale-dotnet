using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarForSale.Model;

namespace CarForSale.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<CarForSale.Model.Carro> Carro { get; set; }
    }
}
