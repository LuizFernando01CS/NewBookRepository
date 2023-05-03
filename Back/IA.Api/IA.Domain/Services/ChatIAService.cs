using IA.Domain.Entities;
using IA.Domain.Interfaces.Repositories;
using IA.Domain.Interfaces.Services;
using IA.Domain.Request;
using IA.Domain.Response;
using Microsoft.Extensions.Configuration;
using OpenAI_API.Completions;
using OpenAI_API;
using IA.Core.Enums;

namespace IA.Domain.Services
{
    public class ChatIAService : ServiceBase<ChatIA>, IChatIAService
    {
        private readonly IChatIARepository _chatIARepository;
        private readonly IConfiguration _configuration;
        private readonly IMensagensService _mensagensService;
        private readonly IUsuarioService _usuarioService;
        private readonly IInteligenciaArtificialService _inteligenciaArtificialService;

        public ChatIAService(
            IChatIARepository chatIARepository,
            IConfiguration configuration,
            IMensagensService mensagensService,
            IUsuarioService usuarioService,
            IInteligenciaArtificialService inteligenciaArtificialService) : base(chatIARepository)
        {
            _chatIARepository = chatIARepository;
            _configuration = configuration;
            _mensagensService = mensagensService;
            _usuarioService = usuarioService;
            _inteligenciaArtificialService = inteligenciaArtificialService;
        }

        public async Task<BuscarChatIAResponse> ObterChatPeloIdUsuario(int IdUsuario) => await _chatIARepository.ObterChatPeloIdUsuario(IdUsuario);


        private async Task<BuscarChatIAResponse> ObterChatIA(int IdUsuario)
        {
            var chatIA = await ObterChatPeloIdUsuario(IdUsuario);

            if (chatIA is null)
            {
                var usuario = await _usuarioService.GetByIdAsync(IdUsuario);
                var chat = new ChatIA(usuario, IdUsuario);
                await _chatIARepository.AddAsync(chat);
                chatIA = await ObterChatPeloIdUsuario(IdUsuario);
            }

            return chatIA;
        }

        public async Task<EnviarMensagemResponse> EnviandoMensagemRequest(EnviandoMensagemRequest request)
        {
            var chatIA = await ObterChatIA(request.UsuarioId);

            await _mensagensService.AddAsync(new Mensagens(request, chatIA.ChatIAId));

            var keyOpenai1 = _configuration.GetSection("keyOpenai");
            var openai = new OpenAIAPI(keyOpenai1.Value);
            CompletionRequest completionRequest1 = new CompletionRequest();
            completionRequest1.Prompt = request.MensagemCompleta;
            completionRequest1.Model = OpenAI_API.Models.Model.DavinciText;

            var result = ConstruirMensagem(request.MensagemCompleta, request.TipoMensagem);

            while (true)
            {
                completionRequest1.Prompt = result;
                var completions = await openai.Completions.CreateCompletionAsync(completionRequest1);

                if (completions.ToString().Equals(""))
                    break;

                result += completions.ToString();
            }

            int indexIA = request.UltimaIndex + 2;

            result = result.Replace(request.MensagemCompleta, "");

            await _mensagensService.AddAsync(new Mensagens(request.TipoMensagem, result, indexIA, chatIA.ChatIAId));

            return new EnviarMensagemResponse { TextoResposta = result, UltimaIndex = indexIA, Nome = chatIA.Mensagens.FirstOrDefault().Nome };
        }

        private string ConstruirMensagem(string mensagemCompleta, TipoMensagemEnum tipoMensagem)
        {
            if (tipoMensagem.Equals(TipoMensagemEnum.Sinonimo))
                return $"Forme uma lista de sinônimos da palavra '{mensagemCompleta}' sem que se repita";
            else if (tipoMensagem.Equals(TipoMensagemEnum.Tradutor))
                return $"Traduza '{mensagemCompleta}'";

            return mensagemCompleta;
        }
    }
}