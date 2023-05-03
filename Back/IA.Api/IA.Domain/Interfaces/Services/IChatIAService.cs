using IA.Domain.Entities;
using IA.Domain.Request;
using IA.Domain.Response;

namespace IA.Domain.Interfaces.Services
{
    public interface IChatIAService : IServiceBase<ChatIA>
    {
        Task<BuscarChatIAResponse> ObterChatPeloIdUsuario(int IdUsuario);
        Task<EnviarMensagemResponse> EnviandoMensagemRequest(EnviandoMensagemRequest request);
    }
}