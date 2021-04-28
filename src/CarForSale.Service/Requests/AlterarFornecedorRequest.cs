using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Requests
{
    public class AlterarFornecedorRequest
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Codigo { get; set; }
    }
}
