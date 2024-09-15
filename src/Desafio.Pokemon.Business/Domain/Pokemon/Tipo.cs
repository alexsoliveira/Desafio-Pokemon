using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon
{
    public class Tipo
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
