using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces.Repositories;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        private const string ProdutoNaoEncontrado = "O produto informado não foi encontrado.";
        private const string NaoHaProdutosCadastrados = "Não há produtos cadastrados no sistema.";
        private const string CategoriaNaoEncontrada = "A categoria informada não foi encontrada.";
        private const string PrecoInvalido = "O preço não pode ser menor ou igual a zero.";

        public void Create(Produto produto)
        {
            if (_categoriaRepository.GetById(produto.IdCategoria) == null)
            {
                throw new ArgumentException(CategoriaNaoEncontrada);
            }

            if (produto.Preco <= 0)
            {
                throw new ArgumentException(PrecoInvalido);
            }

            produto.IdProduto = Guid.NewGuid();
            produto.DataHoraCadastro = DateTime.Now;

            _produtoRepository.Create(produto);
        }

        public void Update(Produto produto)
        {
            if (_produtoRepository.GetById(produto.IdProduto) == null)
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }

            if (_categoriaRepository.GetById(produto.IdCategoria) == null)
            {
                throw new ArgumentException(CategoriaNaoEncontrada);
            }

            if (produto.Preco <= 0)
            {
                throw new ArgumentException(PrecoInvalido);
            }

            _produtoRepository.Update(produto);
        }

        public void Delete(Guid idProduto)
        {
            var produto = _produtoRepository.GetById(idProduto);

            if (produto != null)
            {
                _produtoRepository.Delete(produto);
            }
            else
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }
        }

        public List<Produto> GetAll()
        {
            var produtos = _produtoRepository.GetAll();

            if (produtos.Count() > 0)
            {
                return produtos;
            }
            else
            {
                throw new ArgumentException(NaoHaProdutosCadastrados);
            }
        }

        public Produto GetById(Guid idProduto)
        {
            var produto = _produtoRepository.GetById(idProduto);

            if (produto != null)
            {
                return produto;
            }
            else
            {
                throw new ArgumentException(ProdutoNaoEncontrado);
            }
        }
    }
}