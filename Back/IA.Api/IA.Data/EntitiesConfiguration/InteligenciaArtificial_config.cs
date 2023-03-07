using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IA.Data.EntitiesConfiguration
{
    public class InteligenciaArtificial_config : IEntityTypeConfiguration<InteligenciaArtificial>
    {
        public void Configure(EntityTypeBuilder<InteligenciaArtificial> builder)
        {
        }
    }
}