using NewBook.Domain.Entities;
using NewBook.Domain.Request;
using NewBook.Domain.Response;

namespace NewBook.Application.Interface.Application
{
    public interface IUsuarioApplication : IApplicationBase<Usuario>
    {
        ResponseLogin Logar(RequestLogin login);
    }
}