using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao
{
    public class CadeiaEvolucao
    {
        [JsonPropertyName("chain")]
        public Chain? Chain { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }
    }
}
