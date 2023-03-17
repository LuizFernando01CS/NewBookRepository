using NewBook.Domain.Request;
using NewBook.Domain.Response;

namespace NewBook.Application.Interface.Application
{
    public interface IAuthApplication
    {
        Task<ResponseLogin> AuthInterno(RequestAuthInterno login);
        Task<ResponseAuth> AuthGoogle(RequestAuthGoogle requestAuth);
    }
}