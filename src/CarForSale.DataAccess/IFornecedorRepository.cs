using Microsoft.EntityFrameworkCore;
using CarForSale.DataAccess.Entities;
using System.Collections.Generic;
using System;

namespace CarForSale.DataAccess
{
    public interface IFornecedorRepository
    {
        void Adicionar(Fornecedor fornecedor);
        void Editar(Fornecedor fornecedor);
        Fornecedor Obter(Guid id);
        Fornecedor ObterComVeiculos(Guid id);
        IEnumerable<Fornecedor> Obter(string nome);
        IEnumerable<Fornecedor> ObterTodos();
        void Deletar(Guid id);
        void AdicionarVeiculos(Guid fornecedorId, Veiculo veiculo);
        void RemoverVeiculo(Guid fornecedorId, Guid veiculoId);
        void AlterarVeiculo(Guid fornecedorId, Guid veiculoId, Veiculo veiculoEntity);
    }
}