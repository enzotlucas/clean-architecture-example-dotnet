namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidProductExceptionTests
    {
        [Trait("InvalidProductException", "Core")]
        [Fact(DisplayName = "Throw exception with validation errors")]
        public void Constructor_ExceptionWithValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Name' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Name",  validationErrorValue}
            };

            //Act
            var act = () =>
            {
                try
                {
                    throw new InvalidProductException(validationErrors);
                }
                catch (InvalidProductException ex)
                {
                    ex.ValidationErrors["Name"].Equals(validationErrorValue)
                                               .Should()
                                               .Be(true);
                    throw;
                }
            };

            //Assert
            act.Should().Throw<InvalidProductException>()
                        .WithMessage("Invalid product");
        }

        [Trait("InvalidProductException", "Core")]
        [Fact(DisplayName = "Throw exception with message and validation errors")]
        public void Constructor_ExceptionWithMessageAndValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Name' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Name",  validationErrorValue}
            };
            var message = "Invalid product custom";

            //Act
            var act = () =>
            {
                try
                {
                    throw new InvalidProductException(validationErrors, message);
                }
                catch (InvalidProductException ex)
                {
                    ex.ValidationErrors["Name"].Equals(validationErrorValue)
                                               .Should()
                                               .Be(true);
                    throw;
                }
            };

            //Assert
            act.Should().Throw<InvalidProductException>()
                        .WithMessage(message);
        }

        [Trait("InvalidProductException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new InvalidProductException(); };

            //Assert
            act.Should().Throw<InvalidProductException>()
                        .WithMessage("Invalid product");
        }

        [Trait("InvalidProductException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid product custom";

            //Act
            var act = () => { throw new InvalidProductException(message); };

            //Assert
            act.Should().Throw<InvalidProductException>()
                        .WithMessage(message);
        }
    }
}
