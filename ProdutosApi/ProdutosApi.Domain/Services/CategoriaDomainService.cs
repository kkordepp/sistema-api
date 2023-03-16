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
    public class CategoriaDomainService : ICategoriaDomainService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        private const string NaoHaCategoriasCadastradas = "Não há categorias cadastradas no sistema.";

        public List<Categoria> GetAll()
        {
            var categorias = _categoriaRepository.GetAll();

            if (categorias.Count() > 0)
            {
                return categorias;
            }
            else
            {
                throw new ArgumentException(NaoHaCategoriasCadastradas);
            }
        }
    }
}