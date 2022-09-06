namespace Exemplo.CRUD.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
