using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkInfra = Desafio.Pokemon.Data.EF;

namespace Desafio.Pokemon.IntegrationTests.UnitOfWork
{
    [Collection(nameof(UnitOfWorkTestFixture))]
    public class UnitOfWorkTest
    {
        private readonly UnitOfWorkTestFixture _fixture;

        public UnitOfWorkTest(UnitOfWorkTestFixture fixture)
         => _fixture = fixture;

        [Fact(DisplayName = nameof(Commit))]
        [Trait("Integration/Infra.Data", "UnitOfWork - Persistence")]
        public async Task Commit()
        {
            var dbContext = _fixture.CriarDbContext();
            var exampleMestrePokemonList = _fixture.ObterMestrePokemonLista();
            await dbContext.AddRangeAsync(exampleMestrePokemonList);
            var unitOfWork = new UnitOfWorkInfra.UnitOfWork(dbContext);

            await unitOfWork.Commit();

            var assertDbContext = _fixture.CriarDbContext(true);
            var savedMestrePokemon = assertDbContext.mestresPokemon
                .AsNoTracking().ToList();
            savedMestrePokemon.Should()
                .HaveCount(exampleMestrePokemonList.Count);            
        }

        [Fact(DisplayName = nameof(Rollback))]
        [Trait("Integration/Infra.Data", "UnitOfWork - Persistence")]
        public async Task Rollback()
        {
            var dbContext = _fixture.CriarDbContext();
            var unitOfWork = new UnitOfWorkInfra.UnitOfWork(dbContext);

            var task = async ()
                => await unitOfWork.Rollback();

            await task.Should().NotThrowAsync();
        }
    }
}
