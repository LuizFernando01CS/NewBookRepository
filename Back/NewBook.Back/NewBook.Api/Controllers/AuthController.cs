using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewBook.Api.Authenticate.Interface;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Request;
using Newtonsoft.Json.Linq;

namespace NewBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthenticateValidator _authenticateValidator;

        public AuthController(
            IAuthenticateValidator authenticateValidator)
        {
            _authenticateValidator = authenticateValidator;
        }

        [Authorize]
        [HttpGet("VerificarAutenticacao")]
        public async Task<IActionResult> VerificarAutenticacao() => Ok(true);

        [HttpGet("ValidateToken/{token}")]
        public async Task<IActionResult> ValidateToken(string token) => Ok(await _authenticateValidator.GoogleValidateToken(token));

        [HttpPost("AuthInterno")]
        public async Task<IActionResult> AuthInterno(RequestAuthInterno login) => Ok(await _authenticateValidator.AuthInterno(login));      
    }
}