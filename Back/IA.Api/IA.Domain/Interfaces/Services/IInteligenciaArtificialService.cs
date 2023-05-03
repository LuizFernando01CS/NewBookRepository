using IA.Domain.Entities;
using IA.Domain.Request;

namespace IA.Domain.Interfaces.Services
{
    public interface IInteligenciaArtificialService : IServiceBase<InteligenciaArtificial>
    {
        Task<InteligenciaArtificial> ObterPeloUsuarioId(int usuarioId);
        Task CriarIA(int usuarioId);
        Task<bool> SalvarEdicaoChatIA(EditarChatIARequest request);
    }
}