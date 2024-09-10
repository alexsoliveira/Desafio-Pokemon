using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Pokemon.Data.EF.Repositories
{
    public class MestrePokemonRepository : IMestrePokemonRepository<MestrePokemon>
    {
        private readonly DesafioPokemonDbContext _context;        

        private DbSet<MestrePokemon> _mestresPokemon
            => _context.Set<MestrePokemon>();

        public MestrePokemonRepository(DesafioPokemonDbContext context)
            => _context = context;

        public async Task Insert(MestrePokemon aggregate)
            => await _mestresPokemon.AddAsync(aggregate);        
    }
}
