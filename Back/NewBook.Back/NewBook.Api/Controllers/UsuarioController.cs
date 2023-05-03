using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Models;

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

        [HttpGet("GetAll")]
        [Authorize]
        public List<Usuario> GetAll()
        {
            try
            {
                return _usuarioApplication.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro na aplicação, erro técnico: {ex.Message}");
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
                throw new Exception($"Erro na aplicação, erro técnico: {ex.Message}");
            }
        }
    }
}