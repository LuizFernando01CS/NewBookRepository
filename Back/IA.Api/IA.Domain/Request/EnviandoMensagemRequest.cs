using IA.Core.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IA.Domain.Request
{
    public class EnviandoMensagemRequest
    {
        [JsonProperty("userId")]
        [JsonPropertyName("userId")]
        public int UsuarioId { get; set; }

        [JsonProperty("message")]
        [JsonPropertyName("message")]
        public string MensagemCompleta { get; set; }

        [JsonProperty("messageUser")]
        [JsonPropertyName("messageUser")]
        public string MensagemUsuario { get; set; }

        [JsonProperty("lastIndex")]
        [JsonPropertyName("lastIndex")]
        public int UltimaIndex { get; set; }

        [JsonProperty("messageType")]
        [JsonPropertyName("messageType")]
        public TipoMensagemEnum TipoMensagem { get; set; }
    }
}