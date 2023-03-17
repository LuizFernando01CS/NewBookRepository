using NewBook.Domain.Entities;
using System.Text.Json.Serialization;

namespace NewBook.Domain.Response
{
    public class ResponseAuth
    {
        public ResponseAuth()
        {

        }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("logado")]
        public bool Logado { get; set; }

        [JsonPropertyName("usuario")]
        public Usuario Usuario { get; set; }
    }
}