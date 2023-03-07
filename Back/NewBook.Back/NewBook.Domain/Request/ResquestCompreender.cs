using NewBook.Domain.Enums;
using System.Text.Json.Serialization;

namespace NewBook.Domain.Request
{
    public class ResquestCompreender
    {
        [JsonPropertyName("idUsuario")]
        public int UsuarioId { get; set; }

        [JsonPropertyName("pergunta")]
        public string Pergunta { get; set; }

        [JsonPropertyName("tipoMensagem")]
        public TipoMensagemEnum TipoMensagem { get; set; }
    }
}