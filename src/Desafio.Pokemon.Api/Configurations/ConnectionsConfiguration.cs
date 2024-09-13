using Desafio.Pokemon.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Pokemon.Api.Configurations
{
    public static class ConnectionsConfiguration
    {
        public static IServiceCollection AddAppConnections(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbConnection(configuration);
            return services;
        }

        private static IServiceCollection AddDbConnection(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("DesafioPokemonDb");
            services.AddDbContext<DesafioPokemonDbContext>(                
                options => options.UseSqlite(
                    connectionString                    
                )
            );
            return services;
        }
    }
}