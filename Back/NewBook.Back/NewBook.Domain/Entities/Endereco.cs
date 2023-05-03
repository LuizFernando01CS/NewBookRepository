namespace NewBook.Domain.Entities
{
    public class Endereco : EntityBase
    {
        public Endereco()
        {
            SetandoBasePeloSite();
        }

        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public int NumeroCasa { get; set; } = 0;
        public string Complemento { get; set; }

        public List<Usuario> Usuario { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}