using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using OpenAI_API.Completions;
using OpenAI_API;
using IA.Domain.Request;

namespace IA.Domain.Services
{
    public class InteligenciaArtificialService : ServiceBase<InteligenciaArtificial>, IInteligenciaArtificialService
    {
        private readonly IInteligenciaArtificialRepository _inteligenciaArtificialRepository;
        private readonly IConfiguration _configuration;

        public InteligenciaArtificialService(
            IInteligenciaArtificialRepository inteligenciaArtificialRepository,
             IConfiguration configuration) : base(inteligenciaArtificialRepository)
        {
            _inteligenciaArtificialRepository = inteligenciaArtificialRepository;
            _configuration = configuration;
        }



        public async Task<string> CompreenderMensagemRequest(BuscarMensagemRequest request)
        {
            string result = "";
            var keyOpenai = _configuration.GetSection("keyOpenai");
            var openai = new OpenAIAPI(keyOpenai.Value);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = request.Mensagem;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;

            var teste2 = request.Mensagem;

            for (var x = 0; x < 50; x++)
            {

                completionRequest.Prompt = teste2;
                var completions = await openai.Completions.CreateCompletionAsync(completionRequest);
                teste2 += completions.ToString().Replace("...", "");
                //result += completion(completions);
            }


            var ver = teste2.Split("\n\n");

            return "";

            //string mensagemRequest = request.Mensagem;
            //var result = "";

            //bool pergunta = mensagemRequest.Contains("?");

            //string tag = ObterTag(mensagemRequest.ToLower());

            //if (tag == "ComandoEscrita" && !pergunta)
            //{
            //    result = ObterMensagemPorAutor();

            //    if (mensagemRequest.ToLower().Contains("autor") || mensagemRequest.ToLower().Contains("autor"))
            //    {
            //        var possiveisAutores = mensagemRequest.Split(" ");
            //        var todosAutores = _inteligenciaArtificialRepository.GetAll(); //todos autores

            //        Autor autorEncontrado = new Autor();

            //        foreach (var palavras in possiveisAutores)
            //        {
            //            autorEncontrado = todosAutores.Where(x => x.Nome.Trim().ToLower().Contains(palavras)).First();

            //            if (autorEncontrado is null)
            //                autorEncontrado = todosAutores.Where(x => x.NomeAbreviado.Trim().ToLower().Contains(palavras)).First();
            //        }

            //        var genero = "";

            //        if (autorEncontrado is null && (mensagemRequest.ToLower().Contains("genero") || mensagemRequest.ToLower().Contains("gênero")))
            //        {

            //            Genero generoEncontrado = new Genero();

            //            var todosGeneros = _inteligenciaArtificialRepository.GetAll(); //todos os generos

            //            foreach (var palavras in possiveisAutores)
            //            {
            //                generoEncontrado = todosGeneros.Where(x => x.Nome.Trim().ToLower().Contains(palavras)).First();
            //            }

            //            if (generoEncontrado is null)
            //            {
            //                var todosTextoLivros = _inteligenciaArtificialRepository.GetAll(); //todos textos de livros

            //                Random rnd = new Random();

            //                int posicao = rnd.Next(todosTextoLivros.Count());

            //                var textoAleatorio = todosTextoLivros.ToList()[posicao];


            //            }
            //        }
            //    }
            //    else if (autorEncontrado is null && (mensagemRequest.ToLower().Contains("genero") || mensagemRequest.ToLower().Contains("gênero")))
            //    {
            //        Genero generoEncontrado = new Genero();

            //        var todosGeneros = _inteligenciaArtificialRepository.GetAll(); //todos os generos

            //        foreach (var palavras in possiveisAutores)
            //        {
            //            generoEncontrado = todosGeneros.Where(x => x.Nome.Trim().ToLower().Contains(palavras)).First();
            //        }

            //        if (generoEncontrado is null)
            //        {
            //            var todosTextoLivros = _inteligenciaArtificialRepository.GetAll(); //todos textos de livros

            //            Random rnd = new Random();

            //            int posicao = rnd.Next(todosTextoLivros.Count());

            //            var textoAleatorio = todosTextoLivros.ToList()[posicao];


            //        }
            //    }
            //    else
            //    {
            //        var todosTextoLivros = _inteligenciaArtificialRepository.GetAll(); //todos textos de livros

            //        Random rnd = new Random();

            //        int posicao = rnd.Next(todosTextoLivros.Count());

            //        var textoAleatorio = todosTextoLivros.ToList()[posicao];
            //    }
            //}
            //else
            //{
            //    var perguntaEncontrada = _inteligenciaArtificialRepository.ObterPorPergunta(mensagemRequest); //obter pela tabela pergunta

            //    if (perguntaEncontrada is null)
            //        return "tal";

            //    var respostaInterna = _inteligenciaArtificialRepository.ObterRespostaPelaPergunta(perguntaEncontrada);

            //    if (respostaInterna.Count() == 0)
            //        return "tal";

            //    Random rnd = new Random();

            //    int posicao = rnd.Next(respostaInterna.Count());

            //    var respostaAleatoria = respostaInterna.ToList()[posicao];


            //}
        }

        //private string ObterTag(string mensagemRequest)
        //{
        //    var palavrasTextuaisVerbosOrdem = _inteligenciaArtificialRepository.ObterVerbosOrdem();

        //    var tag = "PerguntaEscrita";

        //    foreach (var palavra in palavrasTextuaisVerbosOrdem)
        //    {
        //        if (mensagemRequest.Contains(palavra))
        //            tag = "ComandoEscrita";
        //    }

        //    return tag;
        //}


    }
}