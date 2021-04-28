using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System;
using System.Collections.Generic;

namespace CarForSale.Service
{
    public interface IFornecedorService
    {
        FornecedorResponse Obter(Guid id);
        IEnumerable<FornecedorResponse> Obter(ObterFornecedorRequest fornecedor);
        IEnumerable<FornecedorResponse> ObterTodos();
        FornecedorResponse Adicionar(FornecedorRequest request);
        FornecedorResponse Alterar(AlterarFornecedorRequest request);
        void Remover(Guid id);
        IEnumerable<VeiculoResponse> ObterVeiculos(Guid fornecedorId);
        VeiculoResponse ObterVeiculo(Guid fornecedorId, Guid veiculoId);
        VeiculoResponse AdicionarVeiculo(Guid fornecedorId, VeiculoRequest request);
        VeiculoResponse AlterarVeiculo(Guid fornecedorId, Guid veiculoId, VeiculoRequest request);
        void RemoverVeiculo(Guid fornecedorId, Guid veiculoId);
    }
}
