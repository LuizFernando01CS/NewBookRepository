using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IA.Api.Models
{
    public class EntityBaseModel
    {
        [Key]

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; private set; }

        [JsonProperty("creationDate")]
        [JsonPropertyName("creationDate")]
        public DateTime DataCriacao { get; private set; }

        [JsonProperty("updateDate")]
        [JsonPropertyName("updateDate")]
        public DateTime DataAtualizacao { get; set; }

        [JsonProperty("isSite")]
        [JsonPropertyName("isSite")]
        public bool PeloSite { get; private set; }

        protected void SetandoBasePeloSite()
        {
            if (Id == 0)
            {
                DataCriacao = DateTime.Now;
                DataAtualizacao = DateTime.Now;
                PeloSite = true;
            }
        }

        protected void SetandoBasePeloApp()
        {
            if (Id == 0)
            {
                DataCriacao = DateTime.Now;
                DataAtualizacao = DateTime.Now;
                PeloSite = false;
            }
        }
    }
}
