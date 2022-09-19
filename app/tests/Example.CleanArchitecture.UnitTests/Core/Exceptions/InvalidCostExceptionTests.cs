namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InvalidCostExceptionTests
    {
        [Trait("InvalidCostException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new InvalidCostException(); };

            //Assert
            act.Should().Throw<InvalidCostException>()
                        .WithMessage("Invalid cost");
        }

        [Trait("InvalidCostException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Invalid cost custom";

            //Act
            var act = () => { throw new InvalidCostException(message); };

            //Assert
            act.Should().Throw<InvalidCostException>()
                        .WithMessage(message);
        }
    }
}
