using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class Endereco_config : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Rua).IsRequired(false).HasColumnType("varchar(150)");
            builder.Property(p => p.Bairro).IsRequired(false).HasColumnType("varchar(150)");
            builder.Property(p => p.Cidade).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.Estado).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.Pais).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.NumeroCasa).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.Complemento).IsRequired(false).HasColumnType("varchar(150)");

            //relationship
        }
    }
}