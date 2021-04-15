using CarForSale.DataAccess;
using CarForSale.DataAccess.Entities;
using CarForSale.Service.Dtos;
using CarForSale.Service.Extensions;
using CarForSale.Service.Requests;
using CarForSale.Service.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarForSale.Service
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository fornecedorRepository;

        public CarroDto Carro { get; private set; }

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        public FornecedorResponse Obter(Guid id)
        {
            var fornecedor = fornecedorRepository.Obter(id);
            return fornecedor.ToResponse();
        }


        //public IEnumerable<FornecedorResponse> Obter(ObterFornecedorRequest fornecedor)
        //{
        //    var fornecedores = fornecedor == null || string.IsNullOrWhiteSpace(fornecedor.Nome)
        //        // Entity Framework por default, é lazy load, ou seja só traz o mínimo necessário
        //        // Se quiser que ele retorne as tabelas associadas, utilize Include e ThenInclude pra tabela dentro da tabela
        //        // Tabela fornecedores incluindo tabela veículos
        //        ? fornecedorRepository.Obter(fornecedor.Nome)
        //        ? this.context.Fornecedores.Include(x => x.Veiculos).ToList()
        //        : this.context.Fornecedores.Where(x => x.Nome.Contains(fornecedor.Nome)).ToList();

        //    return fornecedores.Select(x => x.ToResponse()).ToList();
        //}

        public IEnumerable<FornecedorResponse> Obter(ObterFornecedorRequest fornecedor)
        {
            throw new NotImplementedException();
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
            // FornecedorExtensions.ToResponse(fornecedor);
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
            var fornecedor = fornecedorRepository.Obter(id);

            if (fornecedor == null)
                throw new ArgumentException($"O cliente com id {id} não foi encontrado.");

            fornecedorRepository.Deletar(id);
        }

        public IEnumerable<VeiculoDto> ObterVeiculos(Guid fornecedorId)
        {
           var fornecedor = fornecedorRepository.ObterComVeiculos(fornecedorId);
            
            if (fornecedor == null)
                throw new ArgumentException($"O cliente com id {fornecedorId} não foi encontrado.");

            return fornecedor.Veiculos.ToDtos();
        }

        public void AlterarVeiculos(ICollection<VeiculoDto> veiculos, Fornecedor fornecedor)
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
            }
        }
        public VeiculoResponse AdicionarVeiculo(Guid fornecedorId, VeiculoRequest request)
        {
            var veiculoEntity = request.ToEntity();          
            fornecedorRepository.AdicionarVeiculos(fornecedorId, veiculoEntity);
            return veiculoEntity.ToResponse();            
        }

        public void AdicionarVeiculo(ICollection<VeiculoDto> veiculos, Fornecedor fornecedor)
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

        
    }
}
