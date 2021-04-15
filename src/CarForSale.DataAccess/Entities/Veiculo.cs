using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.DataAccess.Entities
{
    public abstract class Veiculo
    {
        [Key]
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Motor { get; set; }
    }
}
