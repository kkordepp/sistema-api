using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        void Create(Produto produto);

        void Update(Produto produto);

        void Delete(Produto produto);

        List<Produto> GetAll();

        Produto GetById(Guid idProduto);
    }
}