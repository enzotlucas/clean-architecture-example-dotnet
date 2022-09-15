namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InfrastructureException : Exception
    {
        public InfrastructureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
