using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IA.Domain.Request
{
    public class EditarChatIARequest
    {
        [JsonProperty("userId")]
        [JsonPropertyName("userId")]
        public int UsuarioId { get; set; }

        [JsonProperty("nameIA")]
        [JsonPropertyName("nameIA")]
        public string NomeIA { get; set; }

        [JsonProperty("userColorMessage")]
        [JsonPropertyName("userColorMessage")]
        public string CorMensagemUsuario { get; set; }

        [JsonProperty("iAColorMessage")]
        [JsonPropertyName("iAColorMessage")]
        public string CorMensagemIA { get; set; }

        [JsonProperty("iAChatColor")]
        [JsonPropertyName("iAChatColor")]
        public string CorChatIA { get; set; }
    }
}