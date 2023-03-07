using IA.Core.Enums;
using IA.Domain.Response;
using System.Text.Json.Serialization;

namespace IA.Domain.Request
{
    public class BuscarMensagemRequest
    {
        [JsonPropertyName("idUsuario")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("pergunta")]
        public string Mensagem { get; set; }

        [JsonPropertyName("tipoMensagem")]
        public TipoMensagemEnum TipoMensagem { get; set; }
    }
}