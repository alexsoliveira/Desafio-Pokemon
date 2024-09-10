namespace Desafio.Pokemon.Business.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        Task Rollback();
    }
}
