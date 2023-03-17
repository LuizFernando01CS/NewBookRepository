using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Data.EntitiesConfiguration
{
    public class Livro_config : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            //base
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired(true).HasColumnType("int");
            builder.Property(p => p.DataAtualizacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.DataCriacao).IsRequired(true).HasColumnType("datetime");
            builder.Property(p => p.PeloSite).IsRequired(true).HasColumnType("bit");

            //table
            builder.Property(p => p.Resumo).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.Sumario).IsRequired(false).HasColumnType("varchar(1000)");
            builder.Property(p => p.LivroCompleto).HasColumnType("varchar(2000)");
            builder.Property(p => p.UsuarioId).IsRequired(false).HasColumnType("int");
            builder.Property(p => p.TipoLivroId).IsRequired(false).HasColumnType("int");

            //relationship
        }
    }
}