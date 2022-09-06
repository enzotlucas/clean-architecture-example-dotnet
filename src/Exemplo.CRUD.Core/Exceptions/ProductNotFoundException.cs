namespace Exemplo.CRUD.Core.Exceptions
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(string message = "Product not found") : base(message) { }

        public ProductNotFoundException(Guid id) : base($"Product {id} not found") { }
    }
}
