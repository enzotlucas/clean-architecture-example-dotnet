namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class InfrastructureExceptionTests
    {
        [Trait("InfrastructureException", "Core")]
        [Fact(DisplayName = "Throw a exception with default constructor")]
        public void Constructor_DefaultConstructor_ShouldThrow()
        {
            //Arrange
            var message = "Something is wrong";
            var innerExceptionMessage = "Generic exception message";

            //Act
            var act = () =>
            {
                try
                {
                    throw new Exception(innerExceptionMessage);
                }
                catch (Exception ex)
                {
                    ex.Message.Should().Be(innerExceptionMessage);
                    throw new InfrastructureException(message, ex);
                }
            };

            //Assert
            act.Should().ThrowExactly<InfrastructureException>()
                        .WithMessage(message)
                        .WithInnerException<Exception>();
        }
    }
}
