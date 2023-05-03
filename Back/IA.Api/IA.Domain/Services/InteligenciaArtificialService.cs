using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;
using IA.Domain.Request;

namespace IA.Domain.Services
{
    public class InteligenciaArtificialService : ServiceBase<InteligenciaArtificial>, IInteligenciaArtificialService
    {
        private readonly IInteligenciaArtificialRepository _inteligenciaArtificialRepository;

        public InteligenciaArtificialService(
            IInteligenciaArtificialRepository inteligenciaArtificialRepository) : base(inteligenciaArtificialRepository)
        {
            _inteligenciaArtificialRepository = inteligenciaArtificialRepository;
        }

        public async Task CriarIA(int usuarioId) => await _inteligenciaArtificialRepository.AddAsync(new InteligenciaArtificial(usuarioId));

        public async Task<InteligenciaArtificial> ObterPeloUsuarioId(int usuarioId) => await _inteligenciaArtificialRepository.ObterPeloUsuarioId(usuarioId);

        public async Task<bool> SalvarEdicaoChatIA(EditarChatIARequest request)
        {
            var IA = await ObterPeloUsuarioId(request.UsuarioId);
            IA.NomeIA = request.NomeIA;
            IA.CorMensagemIA = request.CorMensagemIA;
            IA.CorMensagemUsuario = request.CorMensagemUsuario;
            IA.CorChatIA = request.CorChatIA;
            await _inteligenciaArtificialRepository.UpdateAsync(IA);
            return true;
        }
    }
}