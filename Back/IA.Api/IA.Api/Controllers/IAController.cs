using AutoMapper;
using IA.Api.Models;
using IA.Domain.Entities;
using IA.Domain.Interfaces.Services;
using IA.Domain.Request;
using IA.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IA.Api.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IAController : Controller
    {
        private readonly IChatIAService _chatIAService;
        private readonly IInteligenciaArtificialService _inteligenciaArtificialService;
        private readonly IMapper _mapper;

        public IAController(
            IChatIAService chatIAService, 
            IInteligenciaArtificialService inteligenciaArtificialService,
            IMapper mapper)
        {   
            _chatIAService = chatIAService;
            _inteligenciaArtificialService = inteligenciaArtificialService;
            _mapper = mapper;
        }

        [HttpPost("EnviandoMensagem")]
        public async Task<IActionResult> EnviandoMensagem([FromBody] EnviandoMensagemRequest request)
        {
            try
            {
                return Ok(await _chatIAService.EnviandoMensagemRequest(request));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na aplicação, Mensagem técnica: {ex.Message}");
            }
        }

        [HttpGet("ObterConversaIA/{usuarioId}")]
        public async Task<IActionResult> ObterConversaIA(int usuarioId)
        {
            try
            {
                return Ok(await _chatIAService.ObterChatPeloIdUsuario(usuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na aplicação, Mensagem técnica: {ex.Message}");
            }
        }

        [HttpPost("CriarIA/{usuarioId}")]
        public async Task<IActionResult> CriarIA(int usuarioId)
        {
            try
            {
                await _inteligenciaArtificialService.CriarIA(usuarioId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("SalvarEdicaoChatIA")]
        public async Task<IActionResult> SalvarEdicaoChatIA([FromBody] EditarChatIARequest request)
        {
            try
            {
                return Ok(await _inteligenciaArtificialService.SalvarEdicaoChatIA(request));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na aplicação, Mensagem técnica: {ex.Message}");
            }
        }


        [HttpGet("ObterIA/{usuarioId}")]
        public async Task<IActionResult> ObterIA(int usuarioId)
        {
            try
            {
                return Ok(_mapper.Map<InteligenciaArtificial, InteligenciaArtificialModel>(await _inteligenciaArtificialService.ObterPeloUsuarioId(usuarioId)));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na aplicação, Mensagem técnica: {ex.Message}");
            }
        }
    }
}