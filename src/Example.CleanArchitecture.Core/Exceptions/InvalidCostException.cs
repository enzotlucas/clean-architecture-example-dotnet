namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidCostException : BusinessException
    {
        public InvalidCostException(string message = "Invalid cost") 
            : base(message)
        {
        }
    }
}
