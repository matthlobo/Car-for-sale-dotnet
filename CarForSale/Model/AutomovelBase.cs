using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public abstract class AutomovelBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Motor { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string CodigoFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
