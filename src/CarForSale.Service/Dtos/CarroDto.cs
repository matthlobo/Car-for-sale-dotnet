using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Dtos
{
    public class CarroDto : VeiculoDto
    {
        [Required(ErrorMessage = "Você precisa informar a quantidade de litros do porta malas.")]
        public string LitrosPortaMalas { get; set; }
    }
}
