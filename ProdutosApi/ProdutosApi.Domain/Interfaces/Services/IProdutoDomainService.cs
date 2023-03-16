using ProdutosApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Domain.Interfaces.Services
{
    public interface IProdutoDomainService
    {
        void Create(Produto produto);

        void Update(Produto produto);

        void Delete(Guid idProduto);

        List<Produto> GetAll();

        Produto GetById(Guid idProduto);
    }
}