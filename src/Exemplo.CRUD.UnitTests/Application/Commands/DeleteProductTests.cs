namespace Exemplo.CRUD.UnitTests.Application.Commands
{
    public class DeleteProductTests
    {
        [Trait("Application_DeleteProduct", "UnitTests")]
        [Fact(DisplayName = "Existent id, should return deleted.")]
        public async Task Handle_ExistentId_ShouldReturnDeleted()
        {
            //Arrange
            var product = new Product("Product Test", 2.5m, "Category");
            var request = new DeleteProduct(product.Id);

            var sut = DeleteProductFixtures.GenerateValidHandler(request, product);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(true);
        }

        [Trait("Application_DeleteProduct", "UnitTests")]
        [Fact(DisplayName = "Unexistent id, should throw product not found exception.")]
        public async Task Handle_UnexistentId_ShouldThrowNotFoundException()
        {
            //Arrange
            var product = new Product();
            var request = new DeleteProduct(Guid.NewGuid());

            var sut = DeleteProductFixtures.GenerateInvalidHandler(request, product);

            //Act
            Func<Task> act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            await act.Should().ThrowAsync<ProductNotFoundException>()
                     .WithMessage($"Product {request.Id} not found");
        }
    }
}
