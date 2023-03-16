using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Contexts;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Data.Repositories
{
    public class PerfilRepository
    {
        public Perfil? GetByNome(string nome)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Perfil
                    .FirstOrDefault(p => p.Nome.Equals(nome));
            }
        }
    }
}