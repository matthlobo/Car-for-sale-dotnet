using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForSale.Model
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Senha { get; set; }


    }
}
