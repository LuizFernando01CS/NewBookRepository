using Microsoft.EntityFrameworkCore;
using NewBook.Data.Context;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;

namespace NewBook.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        ContextDb db = new ContextDb(null);

        public async Task<Usuario> ObterPeloEmail(string email)
        {
            return await db.Usuario.Include(x => x.InformacoesPessoais).Where(x => x.Email.Equals(email))
                .Include(x =>x.InformacoesPessoais).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPeloEmailESenha(string email, string senha)
        {
            return await db.Usuario.Where(x => x.Email.Equals(email) && x.Senha.Equals(senha))
                .Include(x => x.InformacoesPessoais).FirstOrDefaultAsync();
        }
    }
}