using System.Text.Json.Serialization;

namespace NewBook.Domain.Enums
{
    public enum StatusEntendimentoEnum
    {
        [JsonPropertyName("Em Avaliação")]
        EmAvaliacao = 1,

        [JsonPropertyName("Em Andamento")]
        EmAndamento = 2,

        [JsonPropertyName("Pré Cadastro")]
        PreCadastro = 3,

        [JsonPropertyName("Cadastrada")]
        Cadastrada = 4,
    }
}