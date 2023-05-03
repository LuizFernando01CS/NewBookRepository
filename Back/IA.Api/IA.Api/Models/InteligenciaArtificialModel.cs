using IA.Core.Enums;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IA.Api.Models
{
    public class InteligenciaArtificialModel : EntityBaseModel
    {

        [JsonProperty("nameIA")]
        [JsonPropertyName("nameIA")]
        public string NomeIA { get; set; }

        [JsonProperty("voicetype")]
        [JsonPropertyName("voicetype")]
        public TipoVozIAEnum TipoVoz { get; set; }

        [JsonProperty("stylized")]
        [JsonPropertyName("stylized")]
        public bool Estilizado { get; set; }

        [JsonProperty("typestylized")]
        [JsonPropertyName("typestylized")]
        public TipoEstilizadoEnum TipoEstilizado { get; set; }

        [JsonProperty("userColorMessage")]
        [JsonPropertyName("userColorMessage")]
        public string CorMensagemUsuario { get; set; }

        [JsonProperty("iAColorMessage")]
        [JsonPropertyName("iAColorMessage")]
        public string CorMensagemIA { get; set; }

        [JsonProperty("iAChatColor")]
        [JsonPropertyName("iAChatColor")]
        public string CorChatIA { get; set; }

        [JsonProperty("userId")]
        [JsonPropertyName("userId")]
        public int? UsuarioId { get; set; }
    }
}