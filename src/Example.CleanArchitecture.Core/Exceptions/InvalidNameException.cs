namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidNameException : BusinessException
    {
        public InvalidNameException(string message = "Invalid name")
            : base(message)
        {
        }
    }
}
