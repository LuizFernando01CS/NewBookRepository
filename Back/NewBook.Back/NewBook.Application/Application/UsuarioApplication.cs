using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;
using NewBook.Domain.Request;
using NewBook.Domain.Response;
using System.Text;
using System.Text.Json;

namespace NewBook.Application.Application
{
    public class UsuarioApplication : ApplicationBase<Usuario>, IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApplication(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public ResponseLogin Logar(RequestLogin login)
        {

            var KeyApiAuth = System.Configuration.ConfigurationManager.AppSettings["KeyApiAuth"];

            var url = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCAZLfSEP2m8BDMTxtzNSLaMsmkLbToxAg";

            var data = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = client.PostAsync(url, data).Result;

            string resultJson = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ResponseLogin>(resultJson ?? "");
        }

        public void CriarConta(RequestCriarConta requestCriarConta)
        {

        }
    }
}