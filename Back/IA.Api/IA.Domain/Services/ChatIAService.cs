using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;
using IA.Domain.Response;

namespace IA.Domain.Services
{
    public class ChatIAService : ServiceBase<ChatIA>, IChatIAService
    {
        private readonly IChatIARepository _chatIARepository;

        public ChatIAService(IChatIARepository chatIARepository) : base(chatIARepository)
        {
            _chatIARepository = chatIARepository;
        }

        public Task<List<BuscarChatIAResponse>> ObterChatPeloIdUsuario(int IdUsuario)
        {
            return _chatIARepository.ObterChatPeloIdUsuario(IdUsuario);
        }
    }
}