using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class ChaveValor_config : IEntityTypeConfiguration<ChaveValor>
    {
        public void Configure(EntityTypeBuilder<ChaveValor> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Chave).IsRequired(true).HasColumnType("varchar(100)");
            builder.Property(p => p.Valor).IsRequired(true).HasColumnType("varchar(500)");

            //relationship
        }
    }
}