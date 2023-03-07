using IA.Domain.Response;
using System.Text.Json.Serialization;

namespace IA.Domain.Request
{
    public class BuscarChatIARequest
    {
        [JsonPropertyName("idUsuario")]
        public int IdUsuario { get; set; }
    }
}