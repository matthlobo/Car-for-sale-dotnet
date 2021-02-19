using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.DataAccess.Entities
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
