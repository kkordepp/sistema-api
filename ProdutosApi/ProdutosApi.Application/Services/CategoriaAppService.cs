using ProdutosApi.Application.Interfaces;
using ProdutosApi.Application.Models;
using ProdutosApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaDomainService _categoriaDomainService;

        public CategoriaAppService(ICategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }

        public List<CategoriaGetModel> GetAll()
        {
            var categorias = _categoriaDomainService.GetAll();

            var lista = new List<CategoriaGetModel>();

            foreach (var item in categorias)
            {
                var model = new CategoriaGetModel
                {
                    IdCategoria = item.IdCategoria,
                    Nome = item.Nome
                };

                lista.Add(model);
            }

            return lista;
        }
    }
}