using Desafio.Pokemon.Data.EF.Repositories;
using FluentAssertions;
using DomainService = Desafio.Pokemon.Business.Services;
using UnitOfWorkInfra = Desafio.Pokemon.Data.EF;

namespace Desafio.Pokemon.IntegrationTests.Services.MestrePokemon
{
    [Collection(nameof(MestrePokemonServiceTestFixture))]
    public class MestrePokemonServiceTest
    {
        private readonly MestrePokemonServiceTestFixture _fixture;

        public MestrePokemonServiceTest(MestrePokemonServiceTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(CriarMestrePokemon))]
        [Trait("Integration/Services", "CriarMestrePokemon - Services")]
        public async Task CriarMestrePokemon()
        {
            var dbContext = _fixture.CriarDbContext();
            var repository = new MestrePokemonRepository(dbContext);
            var unitOfWork = new UnitOfWorkInfra.UnitOfWork(dbContext);
            var service = new DomainService.MestrePokemonService(
                repository,
                unitOfWork
            );
            var input = _fixture.ObterMestrePokemonValido();
            var output = await service.CriarMestrePokemon(input);

            var dbMestrePokemon = await (_fixture.CriarDbContext(true))
                .mestresPokemon.FindAsync(output.Id);
            dbMestrePokemon.Should().NotBeNull();
            dbMestrePokemon!.Nome.Should().Be(input.Nome);
            dbMestrePokemon.Idade.Should().Be(input.Idade);
            dbMestrePokemon.Cpf.Numero.Should().Be(input.Cpf.Numero);
            output.Should().NotBeNull();
            output.Nome.Should().Be(input.Nome);
            output.Idade.Should().Be(input.Idade);
            output.Cpf.Should().Be(input.Cpf);
            output.Id.Should().NotBeEmpty();
        }            
    }
}
