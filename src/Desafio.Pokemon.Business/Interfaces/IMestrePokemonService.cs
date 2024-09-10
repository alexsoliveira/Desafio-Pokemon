using Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.Business.Interfaces
{
    public interface IMestrePokemonService
    {
        Task<MestrePokemon> CriarMestrePokemon(MestrePokemon mestrePokemon);
    }
}
