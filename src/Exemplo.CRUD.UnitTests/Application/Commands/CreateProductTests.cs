namespace Exemplo.CRUD.Tests.Application.Commands
{
    public class CreateProductTests
    {
        [Trait("CreateProduct", "Application")]
        [Fact]
        public void Handle_ValidProduct_ShouldReturnCreated()
        {
            //Arrange
            var product = new Product("Valid Product", 2.5m, "Tests");
            var productViewModel = new ProductViewModel();
            var request = new CreateProduct { Name = "Valid Product", Price = 2.5m, Category = "Tests" };

            var sut = CreateProductFixtures.GenerateValidCreateProductHandler(product, productViewModel);

            //Act
            var response = sut.Handle(request, CancellationToken.None);

            //Assert
            response.Result.Should().NotBeNull();
            response.Result.Should().Be(productViewModel);
        }

        [Trait("CreateProduct", "Application")]
        [Fact]
        public async Task Handle_InvalidProductName_ShouldThrowBusinessException()
        {
            //Arrange
            var request = new CreateProduct { Name = "", Price = 2.5m, Category = "Tests" };
            var sut = CreateProductFixtures.GenerateInvalidCreateProductHandler();

            //Act
            Func<Task> act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            await act.Should().ThrowAsync<BusinessException>()
                              .WithMessage("Invalid Product");
        }
    }
}
