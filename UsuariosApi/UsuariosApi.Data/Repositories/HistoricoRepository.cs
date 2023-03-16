using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Contexts;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Data.Repositories
{
    public class HistoricoRepository
    {
        public void Create(Historico historico)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Historico.Add(historico);
                sqlServerContext.SaveChanges();
            }
        }

        public List<Historico> GetAllByUsuario(Guid idUsuario)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Historico
                    .Where(h => h.IdUsuario == idUsuario)
                    .OrderByDescending(h => h.DataHoraOperacao)
                    .ToList();
            }
        }
    }
}