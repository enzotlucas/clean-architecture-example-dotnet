namespace Example.CleanArchitecture.Core.Exceptions
{
    public class InvalidNameException : BusinessException
    {
        public InvalidNameException(string message = "Invalid name")
            : base(message)
        {
        }
    }
}
