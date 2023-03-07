using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
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

        [HttpPost("Login")]
        public IActionResult Login(RequestLogin login)
        {
            try
            {
               var result = _usuarioApplication.Logar(login);
                if (result.error is null)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação, erro técnico:" + ex.Message);
            }
        }

        [HttpPost("CriarConta")]
        public IActionResult CriarConta(RequestCriarConta requestCriarConta)
        {
            try
            {
                _usuarioApplication.CriarConta(requestCriarConta);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação, erro técnico:" + ex.Message);
            }
        }
    }
}
