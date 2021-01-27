using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Carro : AutomovelBase
    {
       [Required(ErrorMessage = "Você precisa informar a quantidade de litros do porta malas.")]
       public string LitrosPortaMalas { get; set; }

    }
}
