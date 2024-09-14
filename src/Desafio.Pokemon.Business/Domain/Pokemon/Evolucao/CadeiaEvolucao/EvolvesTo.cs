using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao
{
    public class EvolvesTo
    {
        [JsonPropertyName("evolves_to")]
        public List<EvolvesTo>? Evolves_To { get; set; }

        [JsonPropertyName("species")]
        public Species? Species { get; set; }
    }
}
