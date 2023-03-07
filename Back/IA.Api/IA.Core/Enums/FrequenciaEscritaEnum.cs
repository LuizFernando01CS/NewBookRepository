using System.Text.Json.Serialization;

namespace IA.Core.Enums
{
    public enum FrequenciaEscritaEnum
    {
        [JsonPropertyName("Nunca escrevi um livro.")]
        NuncaEscreveu = 1,

        [JsonPropertyName("Faz um tempo que não escrevo.")]
        EscreveuATempo = 2,

        [JsonPropertyName("Eu escrevo com frequência, mas nunca finalizo")]
        EscreveFrequenciaNaoFinaliza = 3,

        [JsonPropertyName("Eu escrevo com frequência, E ja finalizei alguns livros.")]
        EscrevoFrquenciaTemLivros = 4,

        [JsonPropertyName("Já sou Escritor.")]
        EscritorProfissional = 5,
    }
}