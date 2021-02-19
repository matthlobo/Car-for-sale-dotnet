using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Dtos
{
    public class VeiculoDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Cor { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Motor { get; set; }
    }
}
