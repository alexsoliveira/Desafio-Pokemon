using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao
{
    public class Chain
    {
        [JsonPropertyName("evolution_details")]
        public List<object>? Evolution_details { get; set; }

        [JsonPropertyName("evolves_to")]
        public List<EvolvesTo>? Evolves_To { get; set; }

        [JsonPropertyName("species")]
        public Species? Species { get; set; }
    }
}
