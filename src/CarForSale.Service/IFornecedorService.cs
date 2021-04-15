using CarForSale.DataAccess.Entities;
using CarForSale.Service.Dtos;
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
        IEnumerable<VeiculoDto> ObterVeiculos(Guid fornecedorId);
        VeiculoResponse AdicionarVeiculo(Guid fornecedorId, VeiculoRequest veiculo);
    }
}
