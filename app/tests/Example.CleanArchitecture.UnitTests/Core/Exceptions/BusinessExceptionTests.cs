namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class BusinessExceptionTests
    {
        [Trait("BusinessException", "Core")]
        [Fact(DisplayName = "Throw exception with message and validation errors")]
        public void Constructor_ExceptionWithMessageAndValidationErrors_ShouldThrow()
        {
            //Arrange
            var validationErrorValue = new[] { "'Name' must be informed" };
            var validationErrors = new Dictionary<string, string[]>()
            {
                {"Name",  validationErrorValue}
            };
            var message = "Invalid entity";

            //Act
            var act = () =>
            {
                try
                {
                    throw new BusinessException(validationErrors, message);
                }
                catch (BusinessException ex)
                {
                    ex.ValidationErrors["Name"].Equals(validationErrorValue)
                                               .Should()
                                               .Be(true);
                    throw;
                }
            };

            //Assert
            act.Should().ThrowExactly<BusinessException>()
                        .WithMessage(message);
        }

        [Trait("BusinessException", "Core")]
        [Fact(DisplayName = "Throw exception with message")]
        public void Constructor_ExceptionWithMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid entity";

            //Act
            var act = () => { throw new BusinessException(message); };

            //Assert
            act.Should().ThrowExactly<BusinessException>()
                        .WithMessage(message);
        }
    }
}
