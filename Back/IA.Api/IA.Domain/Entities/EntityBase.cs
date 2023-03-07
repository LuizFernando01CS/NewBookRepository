namespace IA.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; set; }
        public bool PeloSite { get; private set; }
    }
}