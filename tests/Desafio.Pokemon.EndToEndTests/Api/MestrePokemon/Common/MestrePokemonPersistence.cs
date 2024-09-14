using Desafio.Pokemon.Data.EF;
using Microsoft.EntityFrameworkCore;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.EndToEndTests.Api.MestrePokemon.Common
{
    public class MestrePokemonPersistence
    {
        private readonly DesafioPokemonDbContext _context;

        public MestrePokemonPersistence(DesafioPokemonDbContext context)
            => _context = context;

        public async Task<DomainEntity.MestrePokemon?> GetById(Guid id)
            => await _context.mestresPokemon.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task InsertList(List<DomainEntity.MestrePokemon> mestrePokemon)
        {
            await _context.mestresPokemon.AddRangeAsync(mestrePokemon);
            await _context.SaveChangesAsync();
        }
    }
}
