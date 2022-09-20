namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidNameExceptionTests
    {
        [Trait("InvalidNameException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new InvalidNameException(); };

            //Assert
            act.Should().ThrowExactly<InvalidNameException>()
                        .WithMessage("Invalid name");
        }

        [Trait("InvalidNameException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid name custom";

            //Act
            var act = () => { throw new InvalidNameException(message); };

            //Assert
            act.Should().ThrowExactly<InvalidNameException>()
                        .WithMessage(message);
        }
    }
}
