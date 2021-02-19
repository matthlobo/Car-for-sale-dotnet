using CarForSale.Service.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Requests
{
    public class FornecedorRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public ICollection<VeiculoDto> Veiculos { get; set; }
    }
}
