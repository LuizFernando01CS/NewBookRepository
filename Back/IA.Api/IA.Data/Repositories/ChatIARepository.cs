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
        public async Task<List<BuscarChatIAResponse>> ObterChatPeloIdUsuario(int IdUsuario)
        {          
            return await (from chat in db.ChatIA
                          join msg in db.Mensagens on chat.Id equals msg.ChatIAId
                          join usu in db.Usuario on chat.UsuarioId equals usu.Id
                          where usu.Id == IdUsuario
                          select new BuscarChatIAResponse()
                          {
                              Mensagens = new List<MensagensChatIAResponse>() 
                              {   
                                   new MensagensChatIAResponse()
                                   {
                                       Mensagem = msg.Mensagem,
                                       Ordem = msg.Ordem,
                                       TipoMensagem = msg.TipoMensagem,
                                       DataCriacao = msg.DataCriacao
                                   } 
                              }
                          }).ToListAsync();             
        }
    }
}