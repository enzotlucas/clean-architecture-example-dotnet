namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidProductException : BusinessException
    {
        public InvalidProductException(IDictionary<string, string[]> validationErrors, 
                                       string message = "Invalid product") 
            : base(validationErrors, message)
        {
                ValidationErrors = validationErrors;
        }

        public InvalidProductException(string message = "Invalid product")
            : base(message)
        {
        }
    }
}
