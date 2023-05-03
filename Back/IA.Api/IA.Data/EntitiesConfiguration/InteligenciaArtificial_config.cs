using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class InteligenciaArtificial_config : IEntityTypeConfiguration<InteligenciaArtificial>
    {
        public void Configure(EntityTypeBuilder<InteligenciaArtificial> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.NomeIA).IsRequired(false).HasColumnType("varchar(200)");
            builder.Property(p => p.Estilizado).IsRequired(true).HasColumnType("bit");
            builder.Property(p => p.TipoVoz).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.TipoEstilizado).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.UsuarioId).IsRequired(false).HasColumnType("int");
            builder.Property(p => p.CorMensagemUsuario).IsRequired(false).HasColumnType("varchar(100)");
            builder.Property(p => p.CorMensagemIA).IsRequired(false).HasColumnType("varchar(100)");
            builder.Property(p => p.CorChatIA).IsRequired(false).HasColumnType("varchar(100)");

            //relationship
            builder.HasOne(x => x.Usuario).WithMany(x => x.InteligenciaArtificial).HasForeignKey(x => x.UsuarioId);
            builder.HasIndex(x => x.UsuarioId).IsUnique(false);
        }
    }
}