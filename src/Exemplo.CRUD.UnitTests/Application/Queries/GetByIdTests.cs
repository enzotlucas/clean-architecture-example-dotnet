namespace Exemplo.CRUD.Tests.Application.Queries
{
    public class GetByIdTests
    {
        [Trait("Application_GetById", "UnitTests")]
        [Fact(DisplayName = "Existent id, should return valid product.")]
        public async Task Handle_ExistentId_ShouldReturnValidProduct()
        {
            //Arrange
            var product = new Product("Product Test", 2.5m, "Category");
            var productViewModel = ProductViewModelFixtures.GenerateFromEntity(product);
            var request = new GetById(product.Id);

            var sut = GetByIdFixtures.GenerateValidHandler(product, productViewModel, request);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(productViewModel);
            response.Should().BeAssignableTo<ProductViewModel>();
            response.Should().NotBeAssignableTo<Product>();
            response.Should().NotBeNull();
        }

        [Trait("Application_GetById", "UnitTests")]
        [Fact(DisplayName = "Unexistent id, should throw product not found exception.")]
        public async Task Handle_UnexistentId_ShouldThrowBusinessException()
        {
            //Arrange
            var product = new Product();
            var request = new GetById(Guid.NewGuid());

            var sut = GetByIdFixtures.GenerateInvalidHandler(request, product);

            //Act
            Func<Task> act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            await act.Should().ThrowAsync<ProductNotFoundException>()
                     .WithMessage($"Product {request.Id} not found");
        }
    }
}
