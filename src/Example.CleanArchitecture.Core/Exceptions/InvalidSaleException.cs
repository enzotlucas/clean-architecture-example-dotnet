namespace Example.CleanArchitecture.Core.Exceptions
{
    public sealed class InvalidSaleException : BusinessException
    {
        public InvalidSaleException(IDictionary<string, string[]> validationErrors,
                                    string message = "Invalid sale.")
            : base(validationErrors, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
