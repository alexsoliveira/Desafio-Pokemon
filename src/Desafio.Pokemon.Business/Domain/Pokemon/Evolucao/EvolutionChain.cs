using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao
{
    public class EvolutionChain
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
