using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Application.Application
{
    public class InformacoesAdicionaisApplication : ApplicationBase<InformacoesAdicionais>, IInformacoesAdicionaisApplication
    {
        private readonly IInformacoesAdicionaisService _informacoesAdicionaisService;

        public InformacoesAdicionaisApplication(IInformacoesAdicionaisService informacoesAdicionaisService) : base(informacoesAdicionaisService)
        {
            _informacoesAdicionaisService = informacoesAdicionaisService;
        }
    }
}