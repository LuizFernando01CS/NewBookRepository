namespace NewBook.Api.Model
{
    public class EntityBaseModel
    {
        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataAtualizacao { get; set; }
        public bool PeloSite { get; private set; }
    }
}
