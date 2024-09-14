using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao
{
    public class Species
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
