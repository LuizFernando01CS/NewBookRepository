using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class ChatIA_config : IEntityTypeConfiguration<ChatIA>
    {
        public void Configure(EntityTypeBuilder<ChatIA> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.UsuarioId).IsRequired(false).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.Usuario).WithMany(x => x.ChatIA).HasForeignKey(x => x.UsuarioId);
            builder.HasIndex(x => x.UsuarioId).IsUnique(false);
        }
    }
}