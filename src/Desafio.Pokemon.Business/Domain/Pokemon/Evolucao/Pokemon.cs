using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao
{
    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
