using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Pedidos
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        [NotMapped]
        public virtual Cliente Cliente { get; set; }
        [NotMapped]
        public virtual Veiculo Veiculo { get; set; }

        //public ICollection<AutomovelBase> Automovel { get; set; }
        
    }
}
