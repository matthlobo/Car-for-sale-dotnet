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
        public static IEnumerable<VeiculoDto> ToDtos(this IEnumerable<Veiculo> veiculos)
        {
            if (veiculos == null)
                return new List<VeiculoDto>();
            return veiculos.Select(ToDto).ToList();
        }

        public static VeiculoDto ToDto(this Veiculo veiculo)
        {
            if (veiculo.GetType() == typeof(Carro))
                return ((Carro)veiculo).ToDto();

            return ((Moto)veiculo).ToDto();
        }


        public static Veiculo ToEntity(this VeiculoDto dto)
        {
            if (dto.GetType() == typeof(CarroDto))
                return ((CarroDto)dto).ToEntity();

            return ((MotoDto)dto).ToEntity();
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
            } else
            {
                response.Cilindradas = ((Moto)veiculo).Cilindradas;
                response.TipoVeiculo = TipoVeiculo.Moto;
            }
                return response;
        }

        public static CarroDto ToDto(this Carro carro)
        {
            var result = new CarroDto { LitrosPortaMalas = carro.LitrosPortaMalas };
            result.PreencherDadosBasicos(carro);
            return result;
        }

        public static Carro ToEntity(this CarroDto dto)
        {
            var result = new Carro { LitrosPortaMalas = dto.LitrosPortaMalas };
            result.PreencherDadosBasicos(dto);
            return result;
        }

        public static MotoDto ToDto(this Moto moto)
        {
            var result = new MotoDto { Cilindradas = moto.Cilindradas };
            result.PreencherDadosBasicos(moto);
            return result;
        }

        public static Moto ToEntity(this MotoDto dto)
        {
            var result = new Moto { Cilindradas = dto.Cilindradas };
            result.PreencherDadosBasicos(dto);
            return result;
        }

        private static void PreencherDadosBasicos(this VeiculoDto dto, Veiculo veiculo)
        {
            dto.Id = veiculo.Id;
            dto.Modelo = veiculo.Modelo;
            dto.Cor = veiculo.Cor;
            dto.Tipo = veiculo.Tipo;
            dto.Motor = veiculo.Motor;
            dto.Discriminator = veiculo.Discriminator;
        }

        private static void PreencherDadosBasicos(this Veiculo veiculo, VeiculoDto dto)
        {
            veiculo.Id = dto.Id;
            veiculo.Modelo = dto.Modelo;
            veiculo.Cor = dto.Cor;
            veiculo.Tipo = dto.Tipo;
            veiculo.Motor = dto.Motor;
            dto.Discriminator = veiculo.Discriminator;
        }
    }
}
