namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidPriceExceptionTests
    {
        [Trait("InvalidPriceException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new InvalidPriceException(); };

            //Assert
            act.Should().ThrowExactly<InvalidPriceException>()
                        .WithMessage("Invalid price");
        }

        [Trait("InvalidPriceException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid price custom";

            //Act
            var act = () => { throw new InvalidPriceException(message); };

            //Assert
            act.Should().ThrowExactly<InvalidPriceException>()
                        .WithMessage(message);
        }
    }
}
