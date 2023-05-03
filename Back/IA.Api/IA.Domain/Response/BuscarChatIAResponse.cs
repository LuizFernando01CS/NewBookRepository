using IA.Core.Enums;
using IA.Domain.Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace IA.Domain.Response
{
    public class BuscarChatIAResponse
    {

        public BuscarChatIAResponse(ChatIA chatIA)
        {
            Mensagens = new List<MensagensChatIAResponse>();

            var IA = chatIA.Usuario.InteligenciaArtificial.FirstOrDefault();

            chatIA.Mensagens.ForEach(msg =>
            {
                Mensagens.Add(new MensagensChatIAResponse(chatIA.Usuario.InformacoesPessoais.NomeAbreviado, msg, IA.NomeIA));
            });

            NomeUsuario = chatIA.Usuario.InformacoesPessoais.NomeAbreviado;
            ChatIAId = chatIA.Id;
            CorMensagemUsuario = IA.CorMensagemUsuario;
            CorMensagemIA = IA.CorMensagemIA;
            CorChatIA = IA.CorChatIA;
        }

        [JsonProperty("catIAId")]
        [JsonPropertyName("chatIAId")]
        public int ChatIAId { get; set; }

        [JsonProperty("userName")]
        [JsonPropertyName("userName")]
        public string NomeUsuario { get; set; }

        [JsonProperty("userColorMessage")]
        [JsonPropertyName("userColorMessage")]
        public string CorMensagemUsuario { get; set; }

        [JsonProperty("iAColorMessage")]
        [JsonPropertyName("iAColorMessage")]
        public string CorMensagemIA { get; set; }

        [JsonProperty("iAChatColor")]
        [JsonPropertyName("iAChatColor")]
        public string CorChatIA { get; set; }

        [JsonProperty("messages")]
        [JsonPropertyName("messages")]
        public List<MensagensChatIAResponse> Mensagens { get; set; }

    }

    public class MensagensChatIAResponse
    {

        public MensagensChatIAResponse(string nomeAbreviado, Mensagens mensagens, string nomeIA)
        {
            Nome = mensagens.OrigemMensagem == OrigemMensagemEnum.Usuario ? nomeAbreviado : nomeIA;
            Mensagem = mensagens.Mensagem;
            Index = mensagens.Index;
            TipoMensagem = mensagens.TipoMensagem;
            DataCriacao = mensagens.DataCriacao;
        }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonProperty("message")]
        [JsonPropertyName("message")]
        public string Mensagem { get; set; }

        [JsonProperty("index")]
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonProperty("messageType")]
        [JsonPropertyName("messageType")]
        public TipoMensagemEnum TipoMensagem { get; set; }

        [JsonProperty("creationDate")]
        [JsonPropertyName("creationDate")]
        public DateTime DataCriacao { get; set; }
    }
}