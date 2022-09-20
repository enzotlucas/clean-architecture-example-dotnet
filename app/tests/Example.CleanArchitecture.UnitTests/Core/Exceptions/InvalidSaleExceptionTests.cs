namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidSaleExceptionTests
    {
        [Trait("InvalidSaleException", "Core")]
        [Fact(DisplayName = "Throw exception with validation errors")]
        public void Constructor_ExceptionWithValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Items' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Items",  validationErrorValue}
            };

            //Act
            var act = () =>
            {
                try
                {
                    throw new InvalidSaleException(validationErrors);
                }
                catch (InvalidSaleException ex)
                {
                    ex.ValidationErrors["Items"].Equals(validationErrorValue)
                                                .Should()
                                                .Be(true);
                    throw;
                }
            };

            //Assert
            act.Should().ThrowExactly<InvalidSaleException>()
                        .WithMessage("Invalid sale");
        }

        [Trait("InvalidSaleException", "Core")]
        [Fact(DisplayName = "Throw exception with message and validation errors")]
        public void Constructor_ExceptionWithMessageAndValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Items' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Items",  validationErrorValue}
            };
            var message = "Invalid sale custom";

            //Act
            var act = () =>
            {
                try
                {
                    throw new InvalidSaleException(validationErrors, message);
                }
                catch (InvalidSaleException ex)
                {
                    ex.ValidationErrors["Items"].Equals(validationErrorValue)
                                                .Should()
                                                .Be(true);
                    throw;
                }
            };

            //Assert
            act.Should().ThrowExactly<InvalidSaleException>()
                        .WithMessage(message);
        }
    }
}
