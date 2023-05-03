using IA.Domain.Entities;
using IA.Domain.Response;

namespace IA.Domain.Interfaces.Repositories
{
    public interface IChatIARepository : IRepositoryBase<ChatIA>
    {
        Task<BuscarChatIAResponse> ObterChatPeloIdUsuario(int IdUsuario);
    }
}