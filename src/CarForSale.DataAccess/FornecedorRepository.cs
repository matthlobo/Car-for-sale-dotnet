using CarForSale.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarForSale.DataAccess
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IDataAccessDbContext context;
        public FornecedorRepository(IDataAccessDbContext context)
        {
            this.context = context;
        }

        public void Adicionar(Fornecedor fornecedor)
        {
            //Contexto acessa tabela fornecedores, por isso PLURAL
            context.Fornecedores.Add(fornecedor);
            context.SaveChanges();
        }

        public void Editar(Fornecedor source)
        {
            var fornecedor = Obter(source.Id);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {fornecedor.Id} não foi encontrado.");

            fornecedor.Nome = source.Nome;
            fornecedor.Codigo = source.Codigo;

            context.SaveChanges();
        }

        public Fornecedor Obter(Guid id)
        {
            return context.Fornecedores.Find(id);
        }
        public Fornecedor ObterComVeiculos(Guid id)
        {
            return context.Fornecedores.Include(x => x.Veiculos).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fornecedor> Obter(string nome)
        {
            return context.Fornecedores.Where(x => EF.Functions.Like(x.Nome.ToLower(), nome.ToLower())).ToList();
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return context.Fornecedores.ToList();
        }

        public void Deletar(Guid id)
        {
            var fornecedor = context.Fornecedores.Find(id);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {id} não foi encontrado.");

            context.Fornecedores.Remove(fornecedor);
            context.SaveChanges();
        }

        public void AdicionarVeiculos(Guid fornecedorId, Veiculo veiculo)
        {
            if (veiculo == null)
                throw new ArgumentException($"O veiculo Não chegou aqui.");

            var fornecedor = context.Fornecedores.Find(fornecedorId);
            fornecedor.Veiculos.Add(veiculo);
            context.SaveChanges();
        }

        public void AlterarVeiculo(Guid fornecedorId, Guid veiculoId, Veiculo veiculo)
        {
            var fornecedor = this.ObterComVeiculos(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {fornecedorId} não foi encontrado.");

            var veiculoParaAlterar = fornecedor.Veiculos.FirstOrDefault(x => x.Id == veiculoId);

            if (veiculoParaAlterar == null)
                throw new ArgumentException($"O veiculo com id {veiculoId} não foi encontrado no fornecedor {fornecedorId}.");

            veiculoParaAlterar.Modelo = veiculo.Modelo;
            veiculoParaAlterar.Cor = veiculo.Cor;
            veiculoParaAlterar.Tipo = veiculo.Tipo;
            veiculoParaAlterar.Motor = veiculo.Motor;

            this.context.SaveChanges();
        }

        public void RemoverVeiculo(Guid fornecedorId, Guid veiculoId)
        {
            var fornecedor = this.ObterComVeiculos(fornecedorId);

            if (fornecedor == null)
                throw new ArgumentException($"O fornecedor com id {fornecedorId} não foi encontrado.");

            var veiculo = fornecedor.Veiculos.FirstOrDefault(x => x.Id == veiculoId);

            if (veiculo == null)
                throw new ArgumentException($"O veiculo com id {veiculoId} não foi encontrado no fornecedor {fornecedorId}.");

            fornecedor.Veiculos.Remove(veiculo);
            this.context.SaveChanges();
        }
    }
}
