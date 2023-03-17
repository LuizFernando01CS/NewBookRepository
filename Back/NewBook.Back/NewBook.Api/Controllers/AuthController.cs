using Microsoft.AspNetCore.Mvc;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Request;

namespace NewBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthApplication _authApplication;

        public AuthController(IAuthApplication authApplication)
        {
            _authApplication = authApplication;
        }

        [HttpPost("AuthInterno")]
        public async Task<IActionResult> AuthInterno(RequestAuthInterno login)
        {
            try
            {
                var result = await _authApplication.AuthInterno(login);
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

        [HttpPost("AuthGoogle")]
        public async Task<IActionResult> AuthGoogle(RequestAuthGoogle requestAuth)
        {
            try
            {
                return Ok(await _authApplication.AuthGoogle(requestAuth));
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na aplicação, erro técnico:" + ex.Message);
            }
        }
    }
}