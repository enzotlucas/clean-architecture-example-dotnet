namespace Example.CleanArchitecture.Core.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
