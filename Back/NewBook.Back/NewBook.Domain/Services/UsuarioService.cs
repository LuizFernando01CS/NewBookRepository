using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ObterPeloIdFireBase(string idFirebase)
        {
            return await _usuarioRepository.ObterPeloIdFireBase(idFirebase);
        }

        public async Task<Usuario> ObterPeloEmail(string email)
        {
            return await _usuarioRepository.ObterPeloEmail(email);
        }

        public async Task<Usuario> ObterPeloEmailESenha(string email, string senha)
        {
            return await _usuarioRepository.ObterPeloEmailESenha(email, senha);
        }
    }
}