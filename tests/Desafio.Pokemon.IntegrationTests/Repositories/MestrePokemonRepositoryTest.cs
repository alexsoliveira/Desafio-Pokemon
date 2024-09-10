using Desafio.Pokemon.Data.EF;
using Desafio.Pokemon.Data.EF.Repositories;
using FluentAssertions;

namespace Desafio.Pokemon.IntegrationTests.Repositories
{
    [Collection(nameof(MestrePokemonRepositoryTestFixture))]
    public class MestrePokemonRepositoryTest
    {
        private readonly MestrePokemonRepositoryTestFixture _fixture;

        public MestrePokemonRepositoryTest(MestrePokemonRepositoryTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(Insert))]
        [Trait("Integration/Infra.Data", "MestrePokemonRepository - Repositories")]
        public async Task Insert()
        {
            DesafioPokemonDbContext dbContext = _fixture.CriarDbContext();
            var exampleMestrePokemon = _fixture.ObterMestrePokemonValido();
            var mestrePokemonRepository = new MestrePokemonRepository(dbContext);

            await mestrePokemonRepository.Insert(exampleMestrePokemon);
            await dbContext.SaveChangesAsync();

            var dbMestrePokemon = await (_fixture.CriarDbContext(true))
                .mestresPokemon.FindAsync(exampleMestrePokemon.Id);

            dbMestrePokemon.Should().NotBeNull();
            dbMestrePokemon!.Nome.Should().Be(exampleMestrePokemon.Nome);
            dbMestrePokemon.Idade.Should().Be(exampleMestrePokemon.Idade);
            dbMestrePokemon.Cpf.Numero.Should().Be(exampleMestrePokemon.Cpf.Numero);
        }
    }
}
