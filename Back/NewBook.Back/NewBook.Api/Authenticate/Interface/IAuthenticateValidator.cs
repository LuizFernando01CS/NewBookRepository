using NewBook.Domain.Request;
using NewBook.Domain.Response;

namespace NewBook.Api.Authenticate.Interface
{
    public interface IAuthenticateValidator
    {
        Task<ResponseGoogleValidateToken> GoogleValidateToken(string securityToken);
        Task<ResponseAuthInterno> AuthInterno(RequestAuthInterno login);
    }
}