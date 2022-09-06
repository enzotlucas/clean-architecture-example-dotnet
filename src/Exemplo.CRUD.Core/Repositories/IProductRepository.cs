namespace Exemplo.CRUD.Core.Repositories
{
    public interface IProductRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task<Product> Create(Product product);
        Task Delete(Product product);

        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
    }
}
