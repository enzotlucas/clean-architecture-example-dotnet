namespace Example.CleanArchitecture.Core.Exceptions
{
    public class InvalidCostException : BusinessException
    {
        public InvalidCostException(string message = "Invalid cost") 
            : base(message)
        {
        }
    }
}
