using Bogus;
using Desafio.Pokemon.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Pokemon.IntegrationTests.Base
{
    public class BaseFixture
    {
        protected Faker Faker { get; set; }

        public BaseFixture()
            => Faker = new Faker("pt_BR");

        public DesafioPokemonDbContext CriarDbContext(bool preserveData = false)
        {
            var context = new DesafioPokemonDbContext(
                new DbContextOptionsBuilder<DesafioPokemonDbContext>()
                .UseInMemoryDatabase("integration-tests-db")
                .Options
            );

            if (!preserveData)
                context.Database.EnsureDeleted();
            return context;
        }
    }
}
