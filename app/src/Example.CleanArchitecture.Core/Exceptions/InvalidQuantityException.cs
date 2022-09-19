namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidQuantityException : BusinessException
    {
        public InvalidQuantityException(string message = "Invalid quantity") 
            : base(message)
        {
        }
    }
}
