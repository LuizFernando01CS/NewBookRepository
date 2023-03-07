using IA.Domain.Entities;
using IA.Domain.Response;

namespace IA.Domain.Interfaces.Services
{
    public interface IChatIAService : IServiceBase<ChatIA>
    {
        Task<List<BuscarChatIAResponse>> ObterChatPeloIdUsuario(int IdUsuario);
    }
}