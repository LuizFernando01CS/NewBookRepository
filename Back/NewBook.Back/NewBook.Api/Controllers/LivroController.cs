using Microsoft.AspNetCore.Mvc;
using NewBook.Application.Application;
using NewBook.Application.Interface.Application;
using NewBook.Domain.Entities;

namespace NewBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : Controller
    {
        private readonly ILivroApplication _livroApplication;
        
        public LivroController(ILivroApplication livroApplication)
        {
            _livroApplication = livroApplication;
        }

        [HttpGet("GetAll")]
        public List<Livro> GetAll()
        {
           return _livroApplication.GetAll().ToList();          
        }

        [HttpGet("AddTeste")]
        public string AddTeste()
        {

            Livro livro = new Livro();

            livro.SetarBasePeloSite();

            _livroApplication.AddAsync(livro);

        var teste = _livroApplication.GetAll();
            teste = teste;
            return "";
        }
    }
}