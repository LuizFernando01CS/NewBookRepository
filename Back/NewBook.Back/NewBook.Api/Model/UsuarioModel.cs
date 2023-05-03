using Google.Apis.Auth;
using NewBook.Domain.Entities;

namespace NewBook.Api.Model
{
    public class UsuarioModel : EntityBaseModel
    {
        public UsuarioModel()
        {
            SetandoBasePeloSite();
        }

        public UsuarioModel(GoogleJsonWebSignature.Payload? payload, string senhaHash)
        {
            Login = payload.Email;
            Email = payload.Email;
            Senha = senhaHash;
            LocalIdAuth = payload.JwtId;
            CreateAuthGoogle = true;
            Imagem = payload.Picture;
            UltimoAcesso = DateTime.Now;
            ProvedorId = "Google";
            MetodoAcesso = "AuthGoogle";
            SetandoBasePeloSite();

            InformacoesPessoais = new InformacoesPessoais();
            InformacoesPessoais.NomeAbreviado = payload.GivenName;
            InformacoesPessoais.NomeCompleto = payload.Name;

            InformacoesAdicionais = new InformacoesAdicionais();
            Endereco = new Endereco();
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string? Senha { get; set; }
        public int InformacoesPessoaisID { get; set; } = 0;
        public string LocalIdAuth { get; set; }
        public bool CreateAuthGoogle { get; set; }
        public string Imagem { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string ProvedorId { get; set; }
        public string MetodoAcesso { get; set; }
        public int InformacoesAdicionaisId { get; set; } = 0;
        public int EnderecoId { get; set; } = 0;

        public List<ChatIA>? ChatIA { get; set; }
        public InformacoesPessoais? InformacoesPessoais { get; set; }
        public InformacoesAdicionais InformacoesAdicionais { get; set; }
        public Endereco Endereco { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}
