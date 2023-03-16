using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using ProdutosApi.Domain.Entities;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutoAppService(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        public void Create(ProdutoPostModel model)
        {
            var produto = new Produto()
            {
                Nome = model.Nome,
                Preco = model.Preco.Value,
                Quantidade = model.Quantidade.Value,
                IdCategoria = model.IdCategoria.Value
            };

            _produtoDomainService.Create(produto);
        }

        public void Update(ProdutoPutModel model)
        {
            var produto = new Produto()
            {
                IdProduto = model.IdProduto.Value,
                Nome = model.Nome,
                Preco = model.Preco.Value,
                Quantidade = model.Quantidade.Value,
                IdCategoria = model.IdCategoria.Value
            };

            _produtoDomainService.Update(produto);
        }

        public void Delete(Guid id)
        {
            _produtoDomainService.Delete(id);
        }

        public List<ProdutoGetModel> GetAll()
        {
            var produtos = _produtoDomainService.GetAll();

            var lista = new List<ProdutoGetModel>();

            foreach (var item in produtos)
            {
                var model = new ProdutoGetModel()
                {
                    IdProduto = item.IdProduto,
                    Nome = item.Nome,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade,
                    Total = (item.Preco * item.Quantidade),
                    DataHoraCadastro = item.DataHoraCadastro,
                    Categoria = new CategoriaGetModel
                    {
                        IdCategoria = item.Categoria.IdCategoria,
                        Nome = item.Categoria.Nome
                    }
                };

                lista.Add(model);
            }

            return lista;
        }

        public ProdutoGetModel GetById(Guid id)
        {
            var produto = _produtoDomainService.GetById(id);

            var model = new ProdutoGetModel
            {
                IdProduto = produto.IdProduto,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = (produto.Preco * produto.Quantidade),
                DataHoraCadastro = produto.DataHoraCadastro,
                Categoria = new CategoriaGetModel
                {
                    IdCategoria = produto.Categoria.IdCategoria,
                    Nome = produto.Categoria.Nome
                }
            };

            return model;
        }
    }
}