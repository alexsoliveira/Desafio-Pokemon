using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Pokemon.EndToEndTests.Api.Common
{
    public class MestrePokemonPersistence
    {
        private readonly DesafioPokemonDbContext _context;

        public MestrePokemonPersistence(DesafioPokemonDbContext context)
            => _context = context;

        public async Task<MestrePokemon?> GetById(Guid id)
            => await _context.mestresPokemon.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task InsertList(List<MestrePokemon> mestrePokemon)
        {
            await _context.mestresPokemon.AddRangeAsync(mestrePokemon);
            await _context.SaveChangesAsync();
        }
    }
}
