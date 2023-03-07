using IA.Data.EntitiesConfiguration;
using IA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IA.Data.Context
{
    public partial class ContextDb : DbContext
    {

        public IConfiguration Configuration { get; set; }

        public DbSet<ChatIA> ChatIA { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<InformacoesAdicionais> InformacoesAdicionais { get; set; }
        public DbSet<InformacoesPessoais> InformacoesPessoais { get; set; }
        public DbSet<LivrosExistentes> LivrosExistentes { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
        public DbSet<MensagensNaoEntendidas> MensagensNaoEntendidas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public ContextDb(DbContextOptions<ContextDb> option) : base(option = new DbContextOptions<ContextDb>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;database=newbook_homologacao;user=root;password=newbook123;persist security info=false; Connect Timeout=300", new MySqlServerVersion(new Version(8, 0, 21)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ChatIA_config());
            modelBuilder.ApplyConfiguration(new Endereco_config());
            modelBuilder.ApplyConfiguration(new InformacoesAdicionais_config());
            modelBuilder.ApplyConfiguration(new InformacoesPessoais_config());
            modelBuilder.ApplyConfiguration(new LivrosExistentes_config());
            modelBuilder.ApplyConfiguration(new Mensagens_config());
            modelBuilder.ApplyConfiguration(new MensagensNaoEntendidas_config());
            modelBuilder.ApplyConfiguration(new Usuario_config());
            modelBuilder.ApplyConfiguration(new Livro_config());
        }
    }
}