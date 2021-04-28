using CarForSale.DataAccess.Entities;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;

namespace CarForSale.Service.Extensions
{
    public static class ClienteExtensions
    {
        public static ClienteResponse ToResponse(this Cliente cliente)
        {
            if (cliente == null)
                return null;

            return new ClienteResponse
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.NomeCompleto.Split(' ')[0],
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Senha = cliente.Senha
            };
        }

        public static Cliente ToEntity(this ClienteRequest cliente)
        {
            if (cliente == null)
                return null;

            return new Cliente
            {
                Cpf = cliente.Cpf,
                NomeCompleto = cliente.NomeCompleto,
                Email = cliente.Email,
                Senha = cliente.Senha
            };
        }
    }
}
