namespace Example.CleanArchitecture.Core.Exceptions
{
    public class InvalidSaleException : BusinessException
    {
        public InvalidSaleException(IDictionary<string, string[]> validationErrors,
                                    string message = "Invalid sale.")
            : base(validationErrors, message)
        {
            ValidationErrors = validationErrors;
        }
    }
}
