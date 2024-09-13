using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon
{
    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string? Front_Default { get; set; }
    }
}
