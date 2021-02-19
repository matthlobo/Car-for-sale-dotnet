using CarForSale.DataAccess;
using CarForSale.DataAccess.Entities;
using CarForSale.Service.Dtos;
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
        private readonly IDataAccessDbContext context;

        public FornecedorService(IDataAccessDbContext context)
        {
            this.context = context;
        }

        public FornecedorResponse ObterPor(Guid id)
        {
            var fornecedor = this.context.Fornecedores.Find(id);
            return fornecedor.ToResponse();
        }

        public IEnumerable<FornecedorResponse> ObterPor(string nome)
        {
            var fornecedores = this.context.Fornecedores.Where(x => x.Nome.Contains(nome));
            return fornecedores.Select(fornecedor => fornecedor.ToResponse()).ToList();
        }

        public IEnumerable<FornecedorResponse> ObterTodos()
        {
            return this.context.Fornecedores.Select(fornecedor => fornecedor.ToResponse()).ToList();
        }

        public FornecedorResponse Alterar(FornecedorRequest request)
        {
            var fornecedor = this.context.Fornecedores.Find(request.Id);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {request.Id} não foi encontrado.");

            
            AlterarVeiculos(request.Veiculos, fornecedor);
            AdicionarVeiculos(request.Veiculos, fornecedor);
            RemoverVeiculos(request.Veiculos, fornecedor);

            this.context.SaveChanges();

            return fornecedor.ToResponse();
        }

        private void AlterarVeiculos(ICollection<VeiculoDto> veiculos, Fornecedor fornecedor)
        {
            var veiculoIds = fornecedor.Veiculos.Select(x => x.Id).ToList();
            var veiculosParaAlterar = veiculos.Where(x => veiculoIds.Contains(x.Id));

            foreach (var item in veiculosParaAlterar)
            {
                var veiculo = fornecedor.Veiculos.First(x => x.Id.Equals(item.Id));
                veiculo.Cor = item.Cor;
                veiculo.Modelo = item.Modelo;
                veiculo.Motor = item.Motor;
                veiculo.Tipo = item.Tipo;

                //TODO: Adicionar as propriedades de carro/moto
            }
        }

        private void AdicionarVeiculos(ICollection<VeiculoDto> veiculos, Fornecedor fornecedor)
        {
            var veiculoIds = fornecedor.Veiculos.Select(x => x.Id).ToList();
            var veiculosParaAdicionar = veiculos.Where(x => !veiculoIds.Contains(x.Id));

            foreach (var item in veiculosParaAdicionar)
            {
                fornecedor.Veiculos.Add(item.ToEntity());
            }
        }

        private void RemoverVeiculos(ICollection<VeiculoDto> veiculos, Fornecedor fornecedor)
        {
            var requestVeiculosIds = veiculos.Select(x => x.Id).ToList();
            var veiculosParaRemover = fornecedor.Veiculos.Where(x => !requestVeiculosIds.Contains(x.Id));

            foreach (var item in veiculosParaRemover)
            {
                fornecedor.Veiculos.Remove(item);
            }            
        }

        public void Remover(Guid id)
        {
            var fornecedor = this.context.Fornecedores.Find(id);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {id} não foi encontrado.");

            this.context.Fornecedores.Remove(fornecedor);
            this.context.SaveChanges();
        }
    }
}
