using CarForSale.DataAccess.Entities;
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
                Veiculos = fornecedor.Veiculos.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
