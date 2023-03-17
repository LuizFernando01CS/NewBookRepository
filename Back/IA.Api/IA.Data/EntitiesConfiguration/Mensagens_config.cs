using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class Mensagens_config : IEntityTypeConfiguration<Mensagens>
    {
        public void Configure(EntityTypeBuilder<Mensagens> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Mensagem).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.TipoMensagem).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.Ordem).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.ChatIAId).IsRequired(false).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.ChatIA).WithMany(x => x.Mensagens).HasForeignKey(x => x.ChatIAId);
            builder.HasIndex(x => x.ChatIAId).IsUnique(false);
        }
    }
}