using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using NewBook.Api.Model;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Enums;
using NewBook.Domain.Models;
using NewBook.Domain.Request;
using NewBook.Domain.Response;

namespace NewBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;

        }


        [HttpGet("teste")]
        public void teste([FromQuery] FrequenciaEscritaEnum teste)
        {
            
        }

        public class testes
        {
            public string name { get; set; }
            public string[] array { get; set; }
        }
        public class array
        {
            public string name { get; set; }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public List<Usuario> GetAll()
        {
            try
            {
                return _usuarioApplication.GetAll().ToList();
            }
           catch(Exception ex)
            {
                throw new Exception("Erro na aplicação, erro técnico:" + ex.Message);
            }
        }

        [HttpPost("CriarUsuario")]
        public async Task<int> CriarUsuario(UsuarioInternoModel usuarioInterno)
        {
            try
            {
                return await _usuarioApplication.AddAsync(new Usuario(usuarioInterno));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação, erro técnico:" + ex.Message);
            }
        }
    }
}