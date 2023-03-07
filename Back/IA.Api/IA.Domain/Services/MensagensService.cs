using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;

namespace IA.Domain.Services
{
    public class MensagensService : ServiceBase<Mensagens>, IMensagensService
    {
        private readonly IMensagensRepository _mensagensRepository;

        public MensagensService(IMensagensRepository mensagensRepository) : base(mensagensRepository)
        {
            _mensagensRepository = mensagensRepository;
        }
    }
}