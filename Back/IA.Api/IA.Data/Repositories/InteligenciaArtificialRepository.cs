using IA.Data.Context;
using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IA.Data.Repositories
{
    public class InteligenciaArtificialRepository : RepositoryBase<InteligenciaArtificial>, IInteligenciaArtificialRepository
    {
        ContextDb db = new ContextDb(null);

        public async Task<InteligenciaArtificial> ObterPeloUsuarioId(int usuarioId) => await db.InteligenciaArtificial.Where(x => x.UsuarioId.Equals(usuarioId)).FirstOrDefaultAsync();
    }
}