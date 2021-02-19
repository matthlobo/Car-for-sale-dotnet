using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Requests
{
    public class ClienteRequest
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Senha { get; set; }
    }
}
