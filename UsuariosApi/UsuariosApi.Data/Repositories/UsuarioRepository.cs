using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Contexts;
using UsuariosApi.Data.Entities;
using UsuariosApi.Data.Helpers;

namespace UsuariosApi.Data.Repositories
{
    public class UsuarioRepository
    {
        public void Create(Usuario usuario)
        {
            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Usuario.Add(usuario);
                sqlServerContext.SaveChanges();
            }
        }

        public void Update(Usuario usuario)
        {
            usuario.Senha = MD5Helper.Encrypt(usuario.Senha);

            using (var sqlServerContext = new SqlServerContext())
            {
                sqlServerContext.Entry(usuario).State = EntityState.Modified;
                sqlServerContext.SaveChanges();
            }
        }

        public Usuario? GetByEmail(string email)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public Usuario? GetByEmailAndSenha(string email, string senha)
        {
            using (var sqlServerContext = new SqlServerContext())
            {
                return sqlServerContext.Usuario
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(MD5Helper.Encrypt(senha)));
            }
        }
    }
}