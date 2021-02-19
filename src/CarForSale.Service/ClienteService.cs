using CarForSale.DataAccess;
using CarForSale.Service.Extensions;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarForSale.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IDataAccessDbContext context;

        public ClienteService(IDataAccessDbContext context)
        {
            this.context = context;
        }

        public ClienteResponse Obter(Guid id)
        {
            var cliente = this.context.Clientes.Find(id);
            return cliente.ToResponse();
        }

        public IEnumerable<ClienteResponse> Obter(ObterClienteRequest cliente)
        {
            var clientes = cliente == null || string.IsNullOrWhiteSpace(cliente.Nome)
                ? this.context.Clientes.ToList()
                : this.context.Clientes.Where(x => x.NomeCompleto.Contains(cliente.Nome)).ToList();

            return clientes.Select(x => x.ToResponse()).ToList();
        }

        public ClienteResponse Adicionar(ClienteRequest request)
        {
            var cliente = request.ToEntity();
            this.context.Clientes.Add(cliente);
            this.context.SaveChanges();
            return cliente.ToResponse();
        }

        public ClienteResponse Alterar(AlterarClienteRequest request)
        {
            var cliente = this.context.Clientes.Find(request.Id);

            if (cliente == null)
                throw new ArgumentException($"O cliente com id {request.Id} não foi encontrado.");

            cliente.Email = request.Email;
            cliente.Senha = request.Senha;
            this.context.SaveChanges();

            return cliente.ToResponse();
        }

        public void Remover(Guid id)
        {
            var cliente = this.context.Clientes.Find(id);

            if (cliente == null)
                throw new ArgumentException($"O cliente com id {id} não foi encontrado.");

            this.context.Clientes.Remove(cliente);
            this.context.SaveChanges();
        }
    }
}
