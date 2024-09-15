using Desafio.Pokemon.Api.ViewModels.Pokemon.CadeiaEvolucao;

namespace Desafio.Pokemon.Api.ViewModels.Pokemon
{
    public class PokemonDetalhesViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public PokemonSpritesViewModel? Sprites { get; set; }
        public List<PokemonTypeViewModel>? Types { get; set; }
        public CadeiaEvolucaoViewModel? Evolucao { get; set; }
    }
}
