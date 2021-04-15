using CarForSale.Service.Dtos;
using System;
using System.Collections.Generic;

namespace CarForSale.Service.Responses
{
    public class FornecedorResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        // public ICollection<VeiculoDto> Veiculos { get; set; }
    }
}
