using System.Text.Json.Serialization;

namespace NewBook.Domain.Response
{
    public class ResponseCompreender
    {
        [JsonPropertyName("resposta")]
        public string Resposta { get; set; }
    }
}