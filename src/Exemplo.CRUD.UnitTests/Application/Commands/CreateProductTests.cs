namespace Exemplo.CRUD.Tests.Application.Commands
{
    public class CreateProductTests
    {
        [Trait("Application_CreateProduct", "UnitTests")]
        [Fact(DisplayName = "Valid product, should return created (with a ProductViewModel).")]
        public void Handle_ValidProduct_ShouldReturnCreated()
        {
            //Arrange
            var product = new Product("Valid Product", 2.5m, "Tests");
            var productViewModel = new ProductViewModel();
            var request = new CreateProduct { Name = "Valid Product", Price = 2.5m, Category = "Tests" };

            var sut = CreateProductFixtures.GenerateValidHandler(product, productViewModel);

            //Act
            var response = sut.Handle(request, CancellationToken.None);

            //Assert
            response.Result.Should().NotBeNull();
            response.Result.Should().Be(productViewModel);
        }

        [Trait("Application_CreateProduct", "UnitTests")]
        [Fact(DisplayName = "Invalid product name, should throw a business exception.")]
        public async Task Handle_InvalidProductName_ShouldThrowBusinessException()
        {
            //Arrange
            var request = new CreateProduct { Name = "", Price = 2.5m, Category = "Tests" };
            var sut = CreateProductFixtures.GenerateInvalidHandler();

            //Act
            Func<Task> act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            await act.Should().ThrowAsync<BusinessException>()
                              .WithMessage("Invalid Product");
        }
    }
}
