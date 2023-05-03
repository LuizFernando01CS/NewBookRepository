using IA.Data.Context;
using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Response;
using Microsoft.EntityFrameworkCore;

namespace IA.Data.Repositories
{
    public class ChatIARepository : RepositoryBase<ChatIA>, IChatIARepository
    {
        ContextDb db = new ContextDb(null);
        public async Task<BuscarChatIAResponse> ObterChatPeloIdUsuario(int IdUsuario)
        {
            var chatIA = await db.ChatIA
                .Include(x => x.Mensagens)
                .Include(x => x.Usuario)
                    .ThenInclude(x => x.InformacoesPessoais)
                .Include(x => x.Usuario)
                    .ThenInclude(x => x.InteligenciaArtificial).FirstOrDefaultAsync();


            var teste = new BuscarChatIAResponse(chatIA);

            return teste;
        }
    }
}