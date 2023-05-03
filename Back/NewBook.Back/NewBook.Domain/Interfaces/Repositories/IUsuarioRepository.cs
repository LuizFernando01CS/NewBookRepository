using NewBook.Domain.Entities;

namespace NewBook.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> ObterPeloEmail(string email);
        Task<Usuario> ObterPeloEmailESenha(string email, string senha);
    }
}