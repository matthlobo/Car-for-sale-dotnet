using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Moto : Veiculo
    {
        [Required(ErrorMessage = "O número de cilindradas é obrigatório!")]
        public string Cilindradas { get; set; }

    }
}
