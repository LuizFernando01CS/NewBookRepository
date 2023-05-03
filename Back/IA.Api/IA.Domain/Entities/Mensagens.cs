using IA.Core.Enums;
using IA.Domain.Request;

namespace IA.Domain.Entities
{
    public class Mensagens : EntityBase
    {
        public Mensagens() { }

        public Mensagens(TipoMensagemEnum tipoMensagem, string mensagemIA, int index, int chatIAId)
        {
            SetandoBasePeloSite();
            Mensagem = mensagemIA;
            TipoMensagem = tipoMensagem;
            OrigemMensagem = OrigemMensagemEnum.IA;
            Index = index;
            ChatIAId = chatIAId;
        }

        public Mensagens(EnviandoMensagemRequest request, int chatIAId)
        {
            SetandoBasePeloSite();
            Mensagem = IndentificadorMensagem(request.TipoMensagem, request.MensagemUsuario);
            TipoMensagem = request.TipoMensagem;
            OrigemMensagem = OrigemMensagemEnum.Usuario;
            Index = request.UltimaIndex + 1;
            ChatIAId = chatIAId;
        }

        public string Mensagem { get; set; }
        public TipoMensagemEnum TipoMensagem { get; set; }
        public OrigemMensagemEnum OrigemMensagem { get; set; }
        public int Index { get; set; }
        public int? ChatIAId { get; set; }
        public ChatIA ChatIA { get; set; }
        public List<MensagensNaoEntendidas> MensagensNaoEntendidas { get; set; }

        public string IndentificadorMensagem(TipoMensagemEnum tipoMensagem, string mensagem)
        {
            if (tipoMensagem.Equals(TipoMensagemEnum.Sinonimo))
                return $"Sinônimo da palavra {mensagem.Split("|")[1]}";
            else if (tipoMensagem.Equals(TipoMensagemEnum.Tradutor))
                return $"Traduza '{mensagem}'";

            return mensagem;
        }
    }
}