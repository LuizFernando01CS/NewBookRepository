using IA.Core.Enums;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;
using IA.Domain.Request;
using IA.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace IA.Api.Controllers
{
    public class IAController : Controller
    {
        private readonly IInteligenciaArtificialService _inteligenciaArtificialService;
        private readonly IChatIAService _chatIAService;
        public IAController(
            IInteligenciaArtificialService inteligenciaArtificialService,
            IChatIAService chatIAService)
        {
            _inteligenciaArtificialService = inteligenciaArtificialService;
            _chatIAService = chatIAService;
        }


        [HttpPost("GetAll")]
        public async void GetAll([FromBody]BuscarMensagemRequest command)
        {
            var ver = _inteligenciaArtificialService.CompreenderMensagemRequest(command);
            //var ver = await _mediator.Send(command);
            var teste = "";
        }

        [HttpPost("ObterConversaIA")]
        public async Task<List<BuscarChatIAResponse>> ObterConversaIA(int IdUsuario)
        {
            return await _chatIAService.ObterChatPeloIdUsuario(IdUsuario);            
        }
    }
}