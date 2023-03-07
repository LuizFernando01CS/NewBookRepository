using IA.Domain.Entities;
using IA.Domain.Request;

namespace IA.Domain.Interfaces.Services
{
    public interface IInteligenciaArtificialService : IServiceBase<InteligenciaArtificial>
    {
        //Task<string> ObterRespostaInterna(CompreenderMensagemRequest request);
        Task<string> CompreenderMensagemRequest(BuscarMensagemRequest request);
    }
}