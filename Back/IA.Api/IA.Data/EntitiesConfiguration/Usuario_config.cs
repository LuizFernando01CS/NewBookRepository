using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
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
            builder.Property(p => p.Password).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(p => p.InformacoesPessoaisID).IsRequired(false).HasColumnType("int");
            builder.Property(p => p.FirebaseId).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.CreateAuthGoogle).IsRequired(true).HasColumnType("bit");
            builder.Property(p => p.Imagem).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.UltimoAcesso).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.ProvedorId).IsRequired(false).HasColumnType("varchar(50)");
            builder.Property(p => p.MetodoAcesso).IsRequired(false).HasColumnType("varchar(50)");

            //relationship
            builder.HasOne(x => x.InformacoesPessoais).WithMany(x => x.Usuario).HasForeignKey(x => x.InformacoesPessoaisID);
            builder.HasIndex(x => x.InformacoesPessoaisID).IsUnique(false);
        }
    }
}