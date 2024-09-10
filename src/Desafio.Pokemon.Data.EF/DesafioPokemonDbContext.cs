using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Pokemon.Data.EF
{
    public class DesafioPokemonDbContext : DbContext
    {
        public DbSet<MestrePokemon> mestresPokemon => Set<MestrePokemon>();

        public DesafioPokemonDbContext(
            DbContextOptions<DesafioPokemonDbContext> options ) 
            : base( options ) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MestrePokemonConfiguration());            
        }
    }
}
