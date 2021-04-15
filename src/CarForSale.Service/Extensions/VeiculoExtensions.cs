using CarForSale.DataAccess.Entities;
using CarForSale.Service.Dtos;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System.Collections.Generic;
using System.Linq;

namespace CarForSale.Service.Extensions
{
    public static class VeiculoExtensions
    {
        public static IEnumerable<VeiculoResponse> ToResponse(this IEnumerable<Veiculo> veiculos)
        {
            if (veiculos == null)
                return new List<VeiculoResponse>();

            return veiculos.Select(ToResponse).ToList();
        }

        public static VeiculoResponse ToResponse(this Veiculo veiculo)
        {
            if (veiculo == null)
                return null;

            var response = new VeiculoResponse
            {
                Id = veiculo.Id,
                Modelo = veiculo.Modelo,
                Cor = veiculo.Cor,
                Tipo = veiculo.Tipo,
                Motor = veiculo.Motor
            };

            if (veiculo.GetType() == typeof(Carro))
            {
                response.LitrosPortaMalas = ((Carro)veiculo).LitrosPortaMalas;
                response.TipoVeiculo = TipoVeiculo.Carro;
            }
            else
            {
                response.Cilindradas = ((Moto)veiculo).Cilindradas;
                response.TipoVeiculo = TipoVeiculo.Moto;
            }
            return response;
        }

        public static Veiculo ToEntity(this VeiculoRequest veiculo)
        {
            if (veiculo == null)
                return null;

            if (veiculo.TipoVeiculo == TipoVeiculo.Carro)
                return new Carro
                {
                    Id = veiculo.Id,
                    Modelo = veiculo.Modelo,
                    Cor = veiculo.Cor,
                    Tipo = veiculo.Tipo,
                    Motor = veiculo.Motor,
                    LitrosPortaMalas = veiculo.LitrosPortaMalas                    
                };
            else
            {
                return new Moto
                {
                    Id = veiculo.Id,
                    Modelo = veiculo.Modelo,
                    Cor = veiculo.Cor,
                    Tipo = veiculo.Tipo,
                    Motor = veiculo.Motor,
                    Cilindradas = veiculo.Cilindradas
                };
            }                
        }
    }
}
