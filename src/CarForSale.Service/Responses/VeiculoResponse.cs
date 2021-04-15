using CarForSale.Service.Dtos;
using System;
using System.Collections.Generic;

namespace CarForSale.Service.Responses
{
    public class VeiculoResponse
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Motor { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public string FornecedorId { get; set; }
        public string LitrosPortaMalas { get; set; }
        public string Cilindradas { get; set; }

                
    }
}
