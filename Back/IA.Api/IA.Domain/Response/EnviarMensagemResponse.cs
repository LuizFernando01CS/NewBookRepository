using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IA.Domain.Response
{
    public class EnviarMensagemResponse
    {
        [JsonProperty("textResponse")]
        [JsonPropertyName("textResponse")]
        public string TextoResposta { get; set; }

        [JsonProperty("lastIndex")]
        [JsonPropertyName("lastIndex")]
        public int UltimaIndex { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}