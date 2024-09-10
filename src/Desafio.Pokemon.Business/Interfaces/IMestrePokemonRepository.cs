using Desafio.Pokemon.Business.SeedWork;

namespace Desafio.Pokemon.Business.Interfaces
{
    public interface IMestrePokemonRepository<TAggregate>
        where TAggregate : AggregateRoot
    {
        Task Insert(TAggregate aggregate);
    }
}
