using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System;
using System.Collections.Generic;

namespace CarForSale.Service
{
    public interface IClienteService
    {
        ClienteResponse Obter(Guid id);
        IEnumerable<ClienteResponse> Obter(ObterClienteRequest cliente);
        ClienteResponse Adicionar(ClienteRequest request);
        ClienteResponse Alterar(AlterarClienteRequest request);
        void Remover(Guid id);
    }
}
