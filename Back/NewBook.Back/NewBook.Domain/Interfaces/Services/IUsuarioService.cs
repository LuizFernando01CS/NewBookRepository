using NewBook.Domain.Entities;

namespace NewBook.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Task<Usuario> ObterPeloIdFireBase(string idFirebase);
        Task<Usuario> ObterPeloEmail(string email);
        Task<Usuario> ObterPeloEmailESenha(string email, string senha);
    }
}