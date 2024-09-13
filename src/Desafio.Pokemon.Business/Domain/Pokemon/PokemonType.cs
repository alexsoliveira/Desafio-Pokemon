﻿using System.Text.Json.Serialization;

namespace Desafio.Pokemon.Business.Domain.Pokemon
{
    public class PokemonType
    {
        [JsonPropertyName("slot")]
        public int? Slot { get; set; }

        [JsonPropertyName("type")]
        public Type? Type { get; set; }
    }
}
