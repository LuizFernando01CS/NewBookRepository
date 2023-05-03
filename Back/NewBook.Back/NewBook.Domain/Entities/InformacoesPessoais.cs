using NewBook.Domain.Request;

namespace NewBook.Domain.Entities
{
    public class InformacoesPessoais : EntityBase
    {
        public InformacoesPessoais()
        {
            SetandoBasePeloSite();
        }

        public InformacoesPessoais(RequestAuthGoogle requestAuth)
        {
            NomeAbreviado = requestAuth.given_name;
            NomeCompleto = requestAuth.name;
            NumeroTelefone1 = Convert.ToInt32(requestAuth.phoneNumber);
            SetandoBasePeloSite();
        }

        public string NomeAbreviado { get; set; }
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public int NumeroTelefone1 { get; set; }
        public int NumeroTelefone2 { get; set; }
        public DateTime Idade { get; set; }
        public List<Usuario> Usuario { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}