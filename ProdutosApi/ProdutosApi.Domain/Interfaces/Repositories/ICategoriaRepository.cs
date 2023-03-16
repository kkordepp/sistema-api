using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();

        Categoria GetById(Guid idCategoria);
    }
}