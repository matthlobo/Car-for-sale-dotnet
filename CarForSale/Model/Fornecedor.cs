using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public string Codigo { get; set; }        
    }
}
