using NewBook.Domain.Entities;

namespace NewBook.Application.Interface.Application
{
    public interface IUsuarioApplication : IApplicationBase<Usuario>
    {
        Task<Usuario> ObterPeloIdFireBase(string idFirebase);
        Task<Usuario> ObterPeloEmail(string email);
        Task<Usuario> ObterPeloEmailESenha(string email, string senha);
    }
}