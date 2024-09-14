using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.EndToEndTests.Api.MestrePokemon.Common;

namespace Desafio.Pokemon.EndToEndTests.Api.MestrePokemon.CriarMestrePokemon
{
    [CollectionDefinition(nameof(CriarMestrePokemonApiTestFixture))]
    public class CriarMestrePokemonApiTestFixtureCollection
        : ICollectionFixture<CriarMestrePokemonApiTestFixture>
    { }

    public class CriarMestrePokemonApiTestFixture
         : MestrePokemonBaseFixture
    {

        public CriarMestrePokemonApiTestFixture()
            : base() { }

        public MestrePokemonViewModel ObterExemploMestrePokemon()
            => new(
                ObterNomeMestrePokemonValido(),
                ObterIdadeMestrePokemonValido(),
                ObterCPFMestrePokemonValido()
            );
    }
}
