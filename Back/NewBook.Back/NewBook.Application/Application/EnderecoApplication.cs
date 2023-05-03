using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;
using NewBook.Domain.Interfaces.Services;

namespace NewBook.Application.Application
{
    public class EnderecoApplication : ApplicationBase<Endereco>, IEnderecoApplication
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoApplication(IEnderecoService enderecoService) : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
    }
}