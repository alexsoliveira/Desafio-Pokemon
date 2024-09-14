using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao;
using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon
{
    public class PokemonDetalhes
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites? Sprites { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonType>? Types { get; set; }

        public CadeiaEvolucao? Evolucao { get; set; }
    }
}
