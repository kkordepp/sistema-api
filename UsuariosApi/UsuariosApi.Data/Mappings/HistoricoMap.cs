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
    public class HistoricoMap : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.ToTable("HISTORICO");

            builder.HasKey(h => h.IdHistorico);

            builder.Property(h => h.IdHistorico)
                .HasColumnName("IDHISTORICO");

            builder.Property(h => h.DataHoraOperacao)
                .HasColumnName("DATAHORAOPERACAO")
                .IsRequired();

            builder.Property(h => h.TipoOperacao)
                .HasColumnName("TIPOOPERACAO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(h => h.IdUsuario)
                .HasColumnName("IDUSUARIO")
                .IsRequired();

            builder.HasOne(h => h.Usuario)
                .WithMany(u => u.Historicos)
                .HasForeignKey(h => h.IdUsuario);
        }
    }
}