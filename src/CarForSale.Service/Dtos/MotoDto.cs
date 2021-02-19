using System.ComponentModel.DataAnnotations;

namespace CarForSale.Service.Dtos
{
    public class MotoDto : VeiculoDto
    {
        [Required(ErrorMessage = "O número de cilindradas é obrigatório!")]
        public string Cilindradas { get; set; }
    }
}
