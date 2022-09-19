namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidPriceException : BusinessException
    {
        public InvalidPriceException(string message = "Invalid price") 
            : base(message)
        {
        }
    }
}
