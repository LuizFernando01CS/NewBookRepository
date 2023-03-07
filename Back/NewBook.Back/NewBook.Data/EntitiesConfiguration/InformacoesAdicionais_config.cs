using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBook.Domain.Entities;

namespace NewBook.Data.EntitiesConfiguration
{
    public class InformacoesAdicionais_config : IEntityTypeConfiguration<InformacoesAdicionais>
    {
        public void Configure(EntityTypeBuilder<InformacoesAdicionais> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.LivrosCriados).IsRequired(true).HasColumnType("bit");
            builder.Property(p => p.FrequenciaEscrita).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.JaEscreveu).IsRequired(true).HasColumnType("bit");
            builder.Property(p => p.GostosLivroExistenteId).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.LidosLivrosExistenteId).IsRequired(true).HasColumnType("int");

            //relationship
        }
    }
}