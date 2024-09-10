using Bogus.Extensions.Brazil;
using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.EndToEndTests.Api.Common;
using Desafio.Pokemon.EndToEndTests.Base;

namespace Desafio.Pokemon.EndToEndTests.Api.CriarMestrePokemon
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
