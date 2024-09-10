using Desafio.Pokemon.Data.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Pokemon.EndToEndTests.Base
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("EndToEndTest");

            builder.ConfigureServices(services => {

                var dbOptions = services.FirstOrDefault(
                    x => x.ServiceType == typeof(
                        DbContextOptions<DesafioPokemonDbContext>
                    )
                );
                if (dbOptions is not null)
                    services.Remove(dbOptions);
                services.AddDbContext<DesafioPokemonDbContext>(
                    options =>
                    {
                        options.UseInMemoryDatabase("end2end-tests-db");
                    }
                );

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider
                        .GetService<DesafioPokemonDbContext>();
                    //ArgumentNullException.ThrowIfNull(context);

                    if (context is null)
                        throw new ArgumentNullException(nameof(context));

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            });

            base.ConfigureWebHost(builder);
        }
    }
}
