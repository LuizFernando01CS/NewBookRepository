using IA.Domain.Entities;

namespace IA.Domain.Interfaces.Repositories
{
    public interface IInteligenciaArtificialRepository : IRepositoryBase<InteligenciaArtificial>
    {
        Task<InteligenciaArtificial> ObterPeloUsuarioId(int usuarioId);
    }
}