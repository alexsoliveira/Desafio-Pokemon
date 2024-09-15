using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Business.Interfaces;
using Desafio.Pokemon.Business.Notificacoes;
using Desafio.Pokemon.Business.Services;
using Desafio.Pokemon.Data.EF;
using Desafio.Pokemon.Data.EF.Repositories;

namespace Desafio.Pokemon.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMestrePokemonService, MestrePokemonService>();
            services.AddScoped<IMestrePokemonRepository<MestrePokemon>, MestrePokemonRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPokemonService, PokemonService>();
            services.AddHttpClient<PokemonService>();

            return services;
        }
    }
}
