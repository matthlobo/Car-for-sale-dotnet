using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Carro 
    {
       [Key]
       public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Motor { get; set; }

        public string CodigoFornecedor { get; set; }

    }
}
