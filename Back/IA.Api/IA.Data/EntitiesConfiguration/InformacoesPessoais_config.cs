using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
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
            builder.Property(p => p.InformacoesAdicionaisId).IsRequired(false).HasColumnType("int");
            builder.Property(p => p.EnderecoId).IsRequired(false).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.InformacoesAdicionais).WithMany(x => x.InformacoesPessoais).HasForeignKey(x => x.InformacoesAdicionaisId).OnDelete((DeleteBehavior)3);
            builder.HasOne(x => x.Endereco).WithMany(x => x.InformacoesPessoais).HasForeignKey(x => x.EnderecoId).OnDelete((DeleteBehavior)3);
            builder.HasIndex(x => x.InformacoesAdicionaisId).IsUnique(false);
            builder.HasIndex(x => x.EnderecoId).IsUnique(false);
        }
    }
}