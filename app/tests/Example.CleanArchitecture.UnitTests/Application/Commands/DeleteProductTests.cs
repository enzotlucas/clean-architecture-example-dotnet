namespace Example.CleanArchitecture.UnitTests.Application.Commands
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class DeleteProductTests
    {
        private readonly ApplicationFixture _fixture;

        public DeleteProductTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Initialize the command.")]
        public void Constuctor_AnyInformations_ShouldCreateCommand()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var query = new DeleteProductCommand(id);

            //Assert
            query.Should().NotBe(null);
        }

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Try delete a existing product, should delete.")]
        public async Task Handle_ExistingProduct_ShouldDelete()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = new DeleteProductCommand(product.Id);

            var sut = _fixture.DeleteProduct.GenerateValidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().NotThrowAsync();
        }

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Try delete a unexisting product, should throw.")]
        public async Task Handle_UnexistingProduct_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateInvalid();
            var request = new DeleteProductCommand(Guid.NewGuid());

            var sut = _fixture.DeleteProduct.GenerateValidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Try delete a existing product but service unavailable, should throw.")]
        public async Task Handle_ExistingProductButServiceUnavailable_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = new DeleteProductCommand(product.Id);

            var sut = _fixture.DeleteProduct.GenerateInvalidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().ThrowExactlyAsync<InfrastructureException>();
        }
    }
}
