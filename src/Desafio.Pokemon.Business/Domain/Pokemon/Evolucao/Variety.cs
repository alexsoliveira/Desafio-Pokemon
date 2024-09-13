using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao
{
    public class Variety
    {
        [JsonPropertyName("is_default")]
        public bool? Is_default { get; set; }

        [JsonPropertyName("pokemon")]
        public Pokemon? Pokemon { get; set; }
    }
}
