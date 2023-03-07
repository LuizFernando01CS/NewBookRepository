using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class MensagensNaoEntendidas_config : IEntityTypeConfiguration<MensagensNaoEntendidas>
    {
        public void Configure(EntityTypeBuilder<MensagensNaoEntendidas> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.MensagensId).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.MensagemRecebida).IsRequired(true).HasColumnType("varchar(1000)");
            builder.Property(p => p.StatusEntendimento).IsRequired(true).HasColumnType("int");

            //relationship
            builder.HasOne(x => x.Mensagens).WithMany(x => x.MensagensNaoEntendidas).HasForeignKey(x => x.MensagensId);
            builder.HasIndex(x => x.MensagensId).IsUnique(false);
        }
    }
}