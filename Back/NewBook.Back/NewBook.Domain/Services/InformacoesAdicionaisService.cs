using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Repositories;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Domain.Services
{
    public class InformacoesAdicionaisService : ServiceBase<InformacoesAdicionais>, IInformacoesAdicionaisService
    {
        private readonly IInformacoesAdicionaisRepository _informacoesAdicionaisRepository;

        public InformacoesAdicionaisService(IInformacoesAdicionaisRepository informacoesAdicionaisRepository) : base(informacoesAdicionaisRepository)
        {
            _informacoesAdicionaisRepository = informacoesAdicionaisRepository;
        }
    }
}