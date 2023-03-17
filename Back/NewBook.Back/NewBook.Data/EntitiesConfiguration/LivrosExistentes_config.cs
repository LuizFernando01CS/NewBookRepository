using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBook.Domain.Entities;

namespace NewBook.Data.EntitiesConfiguration
{
    public class LivrosExistentes_config : IEntityTypeConfiguration<LivrosExistentes>
    {
        public void Configure(EntityTypeBuilder<LivrosExistentes> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Resumo).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.Sumario).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.NomeLivroCompleto).IsRequired(false).HasColumnType("varchar(100)");
            builder.Property(p => p.Genero).IsRequired(false).HasColumnType("varchar(50)");

            //relationship
        }
    }
}