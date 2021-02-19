using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Requests
{
    public class AlterarClienteRequest
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Senha { get; set; }
    }
}
