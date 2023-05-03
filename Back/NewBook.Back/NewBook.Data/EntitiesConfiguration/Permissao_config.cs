using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBook.Domain.Entities;

namespace NewBook.Data.EntitiesConfiguration
{
    public class Permissao_config : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.PermissaoMicrofone).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.PermissaoFone).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.UsuarioId).IsRequired(true).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.Usuario).WithMany(x => x.Permissao).HasForeignKey(x => x.UsuarioId);
            builder.HasIndex(x => x.UsuarioId).IsUnique(false);
        }
    }
}