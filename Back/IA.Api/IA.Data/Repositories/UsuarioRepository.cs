using IA.Data.Context;
using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;

namespace IA.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        ContextDb db = new ContextDb(null);
    }
}