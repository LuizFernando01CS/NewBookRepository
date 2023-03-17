using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Application.Application
{
    public class InformacoesPessoaisApplication : ApplicationBase<InformacoesPessoais>, IInformacoesPessoaisApplication
    {
        private readonly IInformacoesPessoaisService _informacoesPessoaisService;

        public InformacoesPessoaisApplication(IInformacoesPessoaisService informacoesPessoaisService) : base(informacoesPessoaisService)
        {
            _informacoesPessoaisService = informacoesPessoaisService;
        }
    }
}