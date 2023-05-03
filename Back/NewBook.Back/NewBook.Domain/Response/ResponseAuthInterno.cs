using NewBook.Domain.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NewBook.Domain.Response
{
    public class ResponseAuthInterno
    {
        public ResponseAuthInterno(){}

        public ResponseAuthInterno(string token, Usuario usuario)
        {
            UsuarioId = usuario.Id;
            Nome = usuario.InformacoesPessoais.NomeAbreviado;
            Token = token;
        }

        [JsonProperty("userId")]
        [JsonPropertyName("userId")]
        public int UsuarioId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonProperty("token")]
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}