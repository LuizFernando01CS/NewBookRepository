using NewBook.Domain.Models;
using NewBook.Domain.Request;

namespace NewBook.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario()
        {
            SetandoBasePeloSite();
        }

        public Usuario(UsuarioInternoModel usuarioInternoModel)
        {
            Login = usuarioInternoModel.NomeUsuario;
            Email = usuarioInternoModel.Email;
            Senha = usuarioInternoModel.Senha;
            SetandoBasePeloSite();
        }

        public Usuario(RequestAuthGoogle requestAuth)
        {
            Login = requestAuth.email;
            Email = requestAuth.email;
            Senha = "";
            CreateAuthGoogle = true;
            Imagem = requestAuth.image;
            UltimoAcesso = DateTime.Now;
            ProvedorId = requestAuth.providerId;
            MetodoAcesso = requestAuth.SignInMethod;
            SetandoBasePeloSite();
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int InformacoesPessoaisID { get; set; } = 0;
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
        public List<Permissao> Permissao { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}