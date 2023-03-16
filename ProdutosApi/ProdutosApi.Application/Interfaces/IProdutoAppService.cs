using ProdutosApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Interfaces
{
    public interface IProdutoAppService
    {
        void Create(ProdutoPostModel model);

        void Update(ProdutoPutModel model);

        void Delete(Guid id);

        List<ProdutoGetModel> GetAll();

        ProdutoGetModel GetById(Guid id);
    }
}