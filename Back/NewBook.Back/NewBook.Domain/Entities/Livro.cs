namespace NewBook.Domain.Entities
{
    public class Livro : EntityBase
    {
        public string Resumo { get; private set; }
        public string Sumario { get; private set; }
        public string LivroCompleto { get; private set; }
        public int UsuarioId { get; private set; }
        public int TipoLivroId { get; private set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}