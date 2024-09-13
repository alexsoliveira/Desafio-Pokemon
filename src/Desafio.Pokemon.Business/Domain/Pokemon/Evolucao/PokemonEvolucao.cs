using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao
{
    public class PokemonEvolucao
    {
        [JsonPropertyName("evolution_chain")]
        public EvolutionChain? Evolution_Chain { get; set; }

        [JsonPropertyName("evolves_from_species")]
        public EvolvesFromSpecies? Evolves_From_Species { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("varieties")]
        public List<Variety>? Varieties { get; set; }
    }
}
