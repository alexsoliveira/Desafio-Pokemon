namespace Desafio.Pokemon.IntegrationTestsApi.Pokemon
{
    [CollectionDefinition(nameof(PokemonServiceTestFixture))]
    public class PokemonServiceTestFixtureCollection
        : ICollectionFixture<PokemonServiceTestFixture>
    { }

    public class PokemonServiceTestFixture
    {
        public PokemonServiceTestFixture()
        { }

        public int ObterIdPrimeiraGeracaoPokemonValido()
        {
            var id = 0;

            id = new Random().Next(1, 151);

            return id;
        }

        public int ObterIdPrimeiraGeracaoPokemonInvalido()
        {
            var id = 0;
            
            id = new Random().Next(152, 1000);

            return id;
        }
    }
}
