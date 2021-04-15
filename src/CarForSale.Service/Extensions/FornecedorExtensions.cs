using CarForSale.DataAccess.Entities;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System.Linq;

namespace CarForSale.Service.Extensions
{
    public static class FornecedorExtensions
    {
        public static FornecedorResponse ToResponse(this Fornecedor fornecedor)
        {          

            if (fornecedor == null)
                return null;

            return new FornecedorResponse
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Codigo = fornecedor.Codigo,
                // Veiculos = fornecedor.Veiculos.Select(x => x.ToDto()).ToList()
            };
        }
           
        public static Fornecedor ToEntity(this FornecedorRequest fornecedor)
        {
            if (fornecedor == null)
                return null;

            return new Fornecedor
            {
                Nome = fornecedor.Nome,
                Codigo = fornecedor.Codigo,
                // Veiculos = (System.Collections.Generic.ICollection<Veiculo>)fornecedor.Veiculos
            };
        }

        public static Fornecedor ToEntity(this AlterarFornecedorRequest fornecedor)
        {
            if (fornecedor == null)
                return null;

            return new Fornecedor
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                Codigo = fornecedor.Codigo,
                // Veiculos = (System.Collections.Generic.ICollection<Veiculo>)fornecedor.Veiculos
            };
        }
    }
}
