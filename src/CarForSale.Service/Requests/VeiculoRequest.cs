using CarForSale.Service.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Requests
{
    public class VeiculoRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Motor { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string LitrosPortaMalas { get; set; }
        public string Cilindradas { get; set; }
    }
}
