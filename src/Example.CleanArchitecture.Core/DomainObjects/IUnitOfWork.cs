namespace Example.CleanArchitecture.Core.DomainObjects
{
	public interface IUnitOfWork : IDisposable
	{
		IProductsRepository Products { get; }
		ISalesRepository Sales { get; }

		Task<bool> SaveChangesAsync();
		Task BeginTransactionAsync();
		Task CommitAsync();
	}
}
