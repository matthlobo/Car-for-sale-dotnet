using CarForSale.DataAccess.Entities;
using CarForSale.Service.Dtos;

namespace CarForSale.Service.Extensions
{
    public static class VeiculoExtensions
    {
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
        }

        private static void PreencherDadosBasicos(this Veiculo veiculo, VeiculoDto dto)
        {
            veiculo.Id = dto.Id;
            veiculo.Modelo = dto.Modelo;
            veiculo.Cor = dto.Cor;
            veiculo.Tipo = dto.Tipo;
            veiculo.Motor = dto.Motor;
        }
    }
}
