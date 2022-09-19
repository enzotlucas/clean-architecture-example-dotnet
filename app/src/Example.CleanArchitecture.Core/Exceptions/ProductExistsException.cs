namespace Example.CleanArchitecture.Core.Exceptions
{
    public class ProductExistsException : BusinessException
    {
        public ProductExistsException(string message = "Product already exists") 
            : base(message)
        {
        }
    }
}
