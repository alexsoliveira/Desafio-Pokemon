using Bogus;
using Desafio.Pokemon.Api;
using Desafio.Pokemon.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Desafio.Pokemon.EndToEndTests.Base
{
    public class BaseFixture
    {
        protected Faker Faker { get; set; }

        public CustomWebApplicationFactory<Program> WebAppFactory { get; set; }
        public HttpClient HttpClient { get; set; }
        public ApiClient ApiClient { get; set; }
        private readonly string _dbConnectionString;

        public BaseFixture()
        {
            Faker = new Faker("pt_BR");
            WebAppFactory = new CustomWebApplicationFactory<Program>();
            HttpClient = WebAppFactory.CreateClient();
            ApiClient = new ApiClient(HttpClient);
            var configuration = WebAppFactory.Services
                .GetService(typeof(IConfiguration));
            ArgumentNullException.ThrowIfNull(configuration);
            _dbConnectionString = ((IConfiguration)configuration)
                .GetConnectionString("DesafioPokemonDb");
        }

        public DesafioPokemonDbContext CriarDbContext()
        {
            var context = new DesafioPokemonDbContext(
                new DbContextOptionsBuilder<DesafioPokemonDbContext>()
                .UseSqlite(
                    _dbConnectionString                    
                )                
                .Options
            );
            return context;
        }

        public void LimparPersistence()
        {
            var context = CriarDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
