using CarForSale.DataAccess;
using CarForSale.Service.Extensions;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarForSale.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        public FornecedorResponse Obter(Guid id)
        {
            var fornecedor = fornecedorRepository.Obter(id);
            return fornecedor.ToResponse();
        }

        public IEnumerable<FornecedorResponse> Obter(ObterFornecedorRequest fornecedor)
        {
            var fornecedores = fornecedor == null || string.IsNullOrWhiteSpace(fornecedor.Nome)
                ? this.fornecedorRepository.ObterTodos()
                : fornecedorRepository.Obter(fornecedor.Nome);

            return fornecedores.Select(x => x.ToResponse()).ToList();
        }

        public IEnumerable<FornecedorResponse> ObterTodos()
        {
            var fornecedores = fornecedorRepository.ObterTodos();
            return fornecedores.Select(x => x.ToResponse()).ToList();
        }

        public FornecedorResponse Adicionar(FornecedorRequest request)
        {
            var fornecedor = request.ToEntity();
            fornecedorRepository.Adicionar(fornecedor);
            return fornecedor.ToResponse();
        }

        public FornecedorResponse Alterar(AlterarFornecedorRequest request)
        {
            var fornecedor = request.ToEntity();
            fornecedorRepository.Editar(fornecedor);
            return fornecedor.ToResponse();
        }

        public void Remover(Guid id)
        {
            fornecedorRepository.Deletar(id);
        }

        public IEnumerable<VeiculoResponse> ObterVeiculos(Guid fornecedorId)
        {
            var fornecedor = fornecedorRepository.ObterComVeiculos(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"O cliente com id {fornecedorId} não foi encontrado.");

            return fornecedor.Veiculos.ToResponse();
        }

        public VeiculoResponse ObterVeiculo(Guid fornecedorId, Guid veiculoId)
        {
            var fornecedor = fornecedorRepository.ObterComVeiculos(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"O cliente com id {fornecedorId} não foi encontrado.");

            var veiculo = fornecedor.Veiculos.FirstOrDefault(x => x.Id == veiculoId);
            return veiculo.ToResponse();
        }

        public VeiculoResponse AdicionarVeiculo(Guid fornecedorId, VeiculoRequest request)
        {
            var veiculoEntity = request.ToEntity();
            fornecedorRepository.AdicionarVeiculos(fornecedorId, veiculoEntity);
            return veiculoEntity.ToResponse();
        }

        public void RemoverVeiculo(Guid fornecedorId, Guid veiculoId)
        {
            fornecedorRepository.RemoverVeiculo(fornecedorId, veiculoId);
        }

        public VeiculoResponse AlterarVeiculo(Guid fornecedorId, Guid veiculoId, VeiculoRequest request)
        {
            var veiculoEntity = request.ToEntity();
            fornecedorRepository.AlterarVeiculo(fornecedorId, veiculoId, veiculoEntity);
            return veiculoEntity.ToResponse();
        }
    }
}
