using Desafio.Pokemon.Business.Domain.Pokemon;

namespace Desafio.Pokemon.Business.Interfaces
{
    public interface IPokemonService
    {
        Task<(HttpResponseMessage?, List<PokemonDetalhes>?)> ObterPokemons();
        Task<(HttpResponseMessage?, PokemonDetalhes?)> ObterPorId(int id);        
    }
}
