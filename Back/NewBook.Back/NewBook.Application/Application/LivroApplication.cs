using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Application.Application
{
    public class LivroApplication : ApplicationBase<Livro>, ILivroApplication
    {
        private readonly ILivroService _livroservice;

        public LivroApplication(ILivroService livroservice) : base(livroservice)
        {
            _livroservice = livroservice;
        }
    }
}