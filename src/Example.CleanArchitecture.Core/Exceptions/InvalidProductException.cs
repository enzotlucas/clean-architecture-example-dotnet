namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidProductException : BusinessException
    {
        public InvalidProductException(IDictionary<string, string[]> validationErrors = null, 
                                       string message = "Invalid product.") 
            : base(validationErrors, message)
        {
            if(validationErrors is not null)
                ValidationErrors = validationErrors;
        }
    }
}
