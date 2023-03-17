using NewBook.Domain.Models;
using NewBook.Domain.Request;

namespace NewBook.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario()
        {
        }

        public Usuario(UsuarioInternoModel usuarioInternoModel)
        {
            Login = usuarioInternoModel.NomeUsuario;
            Email = usuarioInternoModel.Email;
            Password = usuarioInternoModel.Senha;
            SetandoBasePeloSite();
        }

        public Usuario(RequestAuthGoogle requestAuth, int informacoesPessoaisID)
        {
            Login = requestAuth.email;
            Email = requestAuth.email;
            Password = "";
            InformacoesPessoaisID = informacoesPessoaisID;
            FirebaseId = requestAuth.idFirebase;
            CreateAuthGoogle = true;
            Imagem = requestAuth.image;
            UltimoAcesso = DateTime.Now;
            ProvedorId = requestAuth.providerId;
            MetodoAcesso = requestAuth.SignInMethod;
            SetandoBasePeloSite();
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? InformacoesPessoaisID { get; set; }
        public string FirebaseId { get; set; }
        public bool CreateAuthGoogle { get; set; }
        public string Imagem { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public string ProvedorId { get; set; }
        public string MetodoAcesso { get; set; }

        public List<ChatIA> ChatIA { get; set; }
        public InformacoesPessoais InformacoesPessoais { get; set; }

        public void SetarBasePeloSite() => this.SetandoBasePeloSite();

        public void SetarBasePeloApp() => this.SetandoBasePeloApp();
    }
}