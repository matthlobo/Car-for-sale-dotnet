using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System;
using System.Collections.Generic;

namespace CarForSale.Service
{
    public interface IFornecedorService
    {
        FornecedorResponse ObterPor(Guid id);
        IEnumerable<FornecedorResponse> ObterPor(string nome);
        IEnumerable<FornecedorResponse> ObterTodos();
        FornecedorResponse Alterar(FornecedorRequest request);
        void Remover(Guid id);
    }
}
