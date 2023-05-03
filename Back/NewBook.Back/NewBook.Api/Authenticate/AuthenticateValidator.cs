using AutoMapper;
using Google.Apis.Auth;
using IA.Api.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using NewBook.Api.Authenticate.Interface;
using NewBook.Api.Model;
using NewBook.Application.Interface.Application;
using NewBook.CrossCutting;
using NewBook.Domain.Entities;
using NewBook.Domain.Request;
using NewBook.Domain.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewBook.Api.Authenticate
{
    public class AuthenticateValidator : IAuthenticateValidator
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IIAService _IAService;
        private readonly ServicesGeral _servicesGeral;
        private readonly IInformacoesPessoaisApplication _informacoesPessoaisApplication;
        private readonly IInformacoesAdicionaisApplication _informacoesAdicionaisApplication;
        private readonly IEnderecoApplication _enderecoApplication;

        public AuthenticateValidator(
            IUsuarioApplication usuarioApplication,
            IConfiguration configuration,
            IMapper mapper,
             IIAService IAService,
             ServicesGeral servicesGeral,
             IInformacoesPessoaisApplication informacoesPessoaisApplication,
             IInformacoesAdicionaisApplication informacoesAdicionaisApplication,
             IEnderecoApplication enderecoApplication)
        {
            _usuarioApplication = usuarioApplication;
            _configuration = configuration;
            _mapper = mapper;
            _IAService = IAService;
            _servicesGeral = servicesGeral;
            _informacoesPessoaisApplication = informacoesPessoaisApplication;
            _informacoesAdicionaisApplication = informacoesAdicionaisApplication;
            _enderecoApplication = enderecoApplication;
        }

        public async Task<ResponseAuthInterno> AuthInterno(RequestAuthInterno login)
        {
            var SenhaHash = _servicesGeral.GerarHash(login.password);

            var usuario = await _usuarioApplication.ObterPeloEmailESenha(login.email, SenhaHash);

            if (usuario is null)
                throw new Exception("Email ou senha Inválido");

            return new ResponseAuthInterno(GerarToken(usuario, null), usuario);
        }

        private string GerarToken(Usuario usuario, GoogleJsonWebSignature.Payload? payload)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("KeyApiAuth").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                            new Claim(ClaimTypes.Name, usuario.InformacoesPessoais.NomeCompleto),
                            new Claim(JwtRegisteredClaimNames.FamilyName,  payload is not null ? payload.FamilyName : usuario.InformacoesPessoais.NomeAbreviado),
                            new Claim(JwtRegisteredClaimNames.GivenName, payload is not null ? payload.GivenName : usuario.InformacoesPessoais.NomeAbreviado),
                            new Claim(JwtRegisteredClaimNames.Email, payload is not null ? payload.Email : usuario.Email),
                            new Claim(JwtRegisteredClaimNames.Sub, payload is not null ? payload.Subject : ""),
                            new Claim(JwtRegisteredClaimNames.Iss,payload is not null ? payload.Issuer : "")
                }),

                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public async Task<ResponseGoogleValidateToken> GoogleValidateToken(string securityToken)
        {
            var payload = GoogleJsonWebSignature.ValidateAsync(securityToken, new GoogleJsonWebSignature.ValidationSettings()).Result;

            var usuario = await _usuarioApplication.ObterPeloEmail(payload.Email);

            bool novoUsuario = false;
            if (usuario is null)
            {
                novoUsuario = true;
                usuario = await CriarUsuarioGoogle(payload);
            }

            if (usuario.InformacoesPessoais is not null && !usuario.InformacoesPessoais.NomeCompleto.Contains(payload.Name))
                throw new Exception("Informações incopatíveis!");

            var token = GerarToken(usuario, payload);

            if (novoUsuario)
                await _IAService.CriarIA(usuario.Id, token);

            return new ResponseGoogleValidateToken(token, usuario);
        }

        private async Task<Usuario> CriarUsuarioGoogle(GoogleJsonWebSignature.Payload? payload)
        {
            var novoUsuario = _mapper.Map<UsuarioModel, Usuario>(new UsuarioModel(payload, _servicesGeral.GerarHash($"AuthGoogle{payload.Email}")));

            novoUsuario.InformacoesPessoaisID = await _informacoesPessoaisApplication.AddAsync(novoUsuario.InformacoesPessoais);
            novoUsuario.InformacoesAdicionaisId = await _informacoesAdicionaisApplication.AddAsync(novoUsuario.InformacoesAdicionais);
            novoUsuario.EnderecoId = await _enderecoApplication.AddAsync(novoUsuario.Endereco);

            novoUsuario.InformacoesPessoais = null;
            novoUsuario.InformacoesAdicionais = null;
            novoUsuario.Endereco = null;

            await _usuarioApplication.AddAsync(novoUsuario);

            novoUsuario.InformacoesPessoais = await _informacoesPessoaisApplication.GetByIdAsync(novoUsuario.InformacoesPessoaisID);

            return novoUsuario;
        }
    }
}