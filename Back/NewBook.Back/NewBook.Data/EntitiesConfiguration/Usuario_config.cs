using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewBook.Domain.Entities;

namespace NewBook.Data.EntitiesConfiguration
{
    public class Usuario_config : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Login).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(p => p.Email).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(p => p.Senha).IsRequired(true).HasColumnType("varchar(500)");
            builder.Property(p => p.InformacoesPessoaisID).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.CreateAuthGoogle).IsRequired(true).HasColumnType("bit");
            builder.Property(p => p.Imagem).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.UltimoAcesso).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.ProvedorId).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.MetodoAcesso).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.InformacoesAdicionaisId).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.EnderecoId).IsRequired(true).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.InformacoesAdicionais).WithMany(x => x.Usuario).HasForeignKey(x => x.InformacoesAdicionaisId).OnDelete((DeleteBehavior)3);
            builder.HasOne(x => x.Endereco).WithMany(x => x.Usuario).HasForeignKey(x => x.EnderecoId).OnDelete((DeleteBehavior)3);
            builder.HasOne(x => x.InformacoesPessoais).WithMany(x => x.Usuario).HasForeignKey(x => x.InformacoesPessoaisID);

            builder.HasIndex(x => x.InformacoesPessoaisID).IsUnique(false);
            builder.HasIndex(x => x.InformacoesAdicionaisId).IsUnique(false);
            builder.HasIndex(x => x.EnderecoId).IsUnique(false);
        }
    }
}