using System.ComponentModel.DataAnnotations;

namespace IA.Domain.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; set; }
        public bool PeloSite { get; private set; }

        protected void SetandoBasePeloSite()
        {
            if (Id == 0)
            {
                DataCriacao = DateTime.Now;
                DataAtualizacao = DateTime.Now;
                PeloSite = true;
            }
        }

        protected void SetandoBasePeloApp()
        {
            if (Id == 0)
            {
                DataCriacao = DateTime.Now;
                DataAtualizacao = DateTime.Now;
                PeloSite = false;
            }
        }
    }
}