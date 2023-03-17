using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Application.Application
{
    public class UsuarioApplication : ApplicationBase<Usuario>, IUsuarioApplication
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioApplication(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<Usuario> ObterPeloIdFireBase(string idFirebase)
        {
            return await _usuarioService.ObterPeloIdFireBase(idFirebase);
        }

        public async Task<Usuario> ObterPeloEmail(string email)
        {
            return await _usuarioService.ObterPeloEmail(email);
        }

        public async Task<Usuario> ObterPeloEmailESenha(string email, string senha)
        {
            return await _usuarioService.ObterPeloEmailESenha(email, senha);
        }
    }
}