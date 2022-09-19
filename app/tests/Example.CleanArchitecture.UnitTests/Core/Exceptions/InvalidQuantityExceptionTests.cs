namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidQuantityExceptionTests
    {
        [Trait("InvalidQuantityException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new InvalidQuantityException(); };

            //Assert
            act.Should().Throw<InvalidQuantityException>()
                        .WithMessage("Invalid quantity");
        }

        [Trait("InvalidQuantityException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid quantity custom";

            //Act
            var act = () => { throw new InvalidQuantityException(message); };

            //Assert
            act.Should().Throw<InvalidQuantityException>()
                        .WithMessage(message);
        }
    }
}
