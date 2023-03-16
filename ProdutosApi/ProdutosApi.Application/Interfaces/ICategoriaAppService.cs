using ProdutosApi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        List<CategoriaGetModel> GetAll();
    }
}