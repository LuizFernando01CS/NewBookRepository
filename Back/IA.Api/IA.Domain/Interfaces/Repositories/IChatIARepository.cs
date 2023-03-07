using IA.Domain.Entities;
using IA.Domain.Response;

namespace IA.Domain.Interfaces.Repositories
{
    public interface IChatIARepository : IRepositoryBase<ChatIA>
    {
        Task<List<BuscarChatIAResponse>> ObterChatPeloIdUsuario(int IdUsuario);
    }
}