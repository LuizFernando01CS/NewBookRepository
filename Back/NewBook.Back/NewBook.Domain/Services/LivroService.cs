using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Domain.Services
{
    public class LivroService : ServiceBase<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository) : base(livroRepository)
        {
            _livroRepository = livroRepository;
        }
    }
}