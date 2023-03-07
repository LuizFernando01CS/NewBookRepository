using IA.Core.Enums;
using System.Text.Json.Serialization;

namespace IA.Domain.Response
{
    public class BuscarChatIAResponse
    {
        [JsonPropertyName("mensagens")]
        public List<MensagensChatIAResponse> Mensagens { get; set; }

    }

    public class MensagensChatIAResponse
    {
        [JsonPropertyName("mensagem")]
        public string Mensagem { get; set; }

        [JsonPropertyName("ordem")]
        public int Ordem { get; set; }

        [JsonPropertyName("tipoMensagem")]
        public TipoMensagemEnum TipoMensagem { get; set; }

        [JsonPropertyName("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }
}