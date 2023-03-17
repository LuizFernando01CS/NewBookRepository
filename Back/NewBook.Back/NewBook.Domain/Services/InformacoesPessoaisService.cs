using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Domain.Services
{
    public class InformacoesPessoaisService : ServiceBase<InformacoesPessoais>, IInformacoesPessoaisService
    {
        private readonly IInformacoesPessoaisRepository _informacoesPessoaisRepository;

        public InformacoesPessoaisService(IInformacoesPessoaisRepository informacoesPessoaisRepository) : base(informacoesPessoaisRepository)
        {
            _informacoesPessoaisRepository = informacoesPessoaisRepository;
        }
    }
}