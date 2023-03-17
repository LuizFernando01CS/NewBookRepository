using Microsoft.Extensions.Configuration;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;
using NewBook.Domain.Request;
using NewBook.Domain.Response;
using NewBook.Domain.Services;
using System.Text;
using System.Text.Json;

namespace NewBook.Application.Application
{
    public class AuthApplication : IAuthApplication
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IInformacoesPessoaisService _informacoesPessoaisService;
        private readonly IConfiguration _configuration;

        public AuthApplication(
            IUsuarioService usuarioService,
            IInformacoesPessoaisService informacoesPessoaisService,
            IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _informacoesPessoaisService = informacoesPessoaisService;
            _configuration = configuration;
        }

        public async Task<ResponseLogin> AuthInterno(RequestAuthInterno login)
        {
            var usuario = _usuarioService.ObterPeloEmailESenha(login.email, login.password);

            if (usuario is null)
                throw new Exception("Email ou senha Inválido");

            var AuthInterno = await _usuarioService.ObterChaveValor("AuthInterno");

            string KeyApiAuth = _configuration.GetSection("KeyApiAuth").Value;

            var data = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            return JsonSerializer.Deserialize<ResponseLogin>(client.PostAsync($"{AuthInterno.Valor}{KeyApiAuth}", data).Result.Content.ReadAsStringAsync().Result ?? "");
        }

        public async Task<ResponseAuth> AuthGoogle(RequestAuthGoogle requestAuth)
        {
            try
            {
                var usuario = await _usuarioService.ObterPeloIdFireBase(requestAuth.idFirebase);

                if (usuario is null)
                {
                    usuario = await _usuarioService.ObterPeloEmail(requestAuth.email);

                    if (usuario is not null) throw new Exception("Email já cadastrado!");

                    int infoId = await _informacoesPessoaisService.AddAsync(new InformacoesPessoais(requestAuth));
                    
                    await _usuarioService.AddAsync(new Domain.Entities.Usuario(requestAuth, infoId));
                }
                else
                {
                    usuario.UltimoAcesso = DateTime.Now;
                    await _usuarioService.UpdateAsync(usuario);
                }

                return new ResponseAuth() { Token = requestAuth.idToken, Logado = true ,Usuario = usuario };
            }
            catch(Exception ex)
            {
                throw new Exception("Erro na Aplicação, Mensagem técnica: " + ex.Message);
            }
        }
    }
}