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

    }
}