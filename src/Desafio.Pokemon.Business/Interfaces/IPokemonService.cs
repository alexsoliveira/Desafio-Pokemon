using Desafio.Pokemon.Business.Domain.Pokemon;
using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao;
using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao;

namespace Desafio.Pokemon.Business.Interfaces
{
    public interface IPokemonService
    {
        Task<(HttpResponseMessage?, List<PokemonDetalhes>?)> ObterPokemons();
        Task<(HttpResponseMessage?, PokemonDetalhes?)> ObterPokemonPorId(int id);

        Task<(HttpResponseMessage?, PokemonDetalhes?)> ObterDetalhesPokemonPorId(int id);
        Task<(HttpResponseMessage?, PokemonEvolucao?)> ObterEvolucaoPokemonPorId(int id);
        Task<(HttpResponseMessage?, CadeiaEvolucao?)> ObterCadeiaEvolucaoPokemonPorId(int id);
    }
}
