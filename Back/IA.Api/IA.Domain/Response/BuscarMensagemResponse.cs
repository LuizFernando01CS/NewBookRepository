using System.Text.Json.Serialization;

namespace IA.Domain.Response
{
    public class BuscarMensagemResponse
    {
        [JsonPropertyName("resposta")]
        public string Resposta { get; set; }
    }
}