using Desafio.Pokemon.Business.Interfaces;

namespace Desafio.Pokemon.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioPokemonDbContext _context;

        public UnitOfWork(DesafioPokemonDbContext context)
            => _context = context;

        public Task Commit()
            => _context.SaveChangesAsync();

        public Task Rollback()
            => Task.CompletedTask;
    }
}
