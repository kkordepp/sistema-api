using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Data.Entities;

namespace UsuariosApi.Data.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PERFIL");

            builder.HasKey(p => p.IdPerfil);

            builder.Property(p => p.IdPerfil)
                .HasColumnName("IDPERFIL");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(p => p.Nome)
                .IsUnique();
        }
    }
}