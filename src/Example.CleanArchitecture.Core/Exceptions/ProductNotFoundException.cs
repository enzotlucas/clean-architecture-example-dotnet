namespace Example.CleanArchitecture.Core.Exceptions
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(string message = "Product not found") 
            : base(message)
        {
        }
    }
}
