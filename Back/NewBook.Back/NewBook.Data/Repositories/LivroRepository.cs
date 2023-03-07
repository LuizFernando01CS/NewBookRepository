using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;

namespace NewBook.Data.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
    }
}