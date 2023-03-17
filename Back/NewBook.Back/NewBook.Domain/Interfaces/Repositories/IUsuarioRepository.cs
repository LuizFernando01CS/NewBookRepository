using NewBook.Domain.Entities;

namespace NewBook.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> ObterPeloIdFireBase(string idFirebase);
        Task<Usuario> ObterPeloEmail(string email);
        Task<Usuario> ObterPeloEmailESenha(string email, string senha);
    }
}