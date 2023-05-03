using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBook.Domain.Entities;

namespace NewBook.Data.EntitiesConfiguration
{
    public class InformacoesPessoais_config : IEntityTypeConfiguration<InformacoesPessoais>
    {
        public void Configure(EntityTypeBuilder<InformacoesPessoais> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.NomeAbreviado).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.NomeCompleto).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.CPF).IsRequired(false).HasColumnType("varchar(20)");
            builder.Property(p => p.CNPJ).IsRequired(false).HasColumnType("varchar(20)");
            builder.Property(p => p.NumeroTelefone1).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.NumeroTelefone2).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.Idade).IsRequired(true).HasColumnType("datetime");

            //relationship
        }
    }
}