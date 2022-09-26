using Example.CleanArchitecture.Application.Commands.UpdateProduct;

namespace Example.CleanArchitecture.UnitTests.Application.Commands
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class UpdateProductTests
    {
        private readonly ApplicationFixture _fixture;

        public UpdateProductTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Initialize the command.")]
        public void Constuctor_AnyInformations_ShouldCreateCommand()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            //Act
            var command = new UpdateProductCommand(productViewModel.Id, productViewModel);

            //Assert
            command.Should().NotBe(null);
        }

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Try update a existing product with valid information, should update.")]
        public async Task Handle_ExistingProduct_ShouldUpdate()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var productViewModel = _fixture.ProductViewModel.GenerateValid();
            var request = _fixture.UpdateProduct.GenerateCommandFromViewModel(productViewModel);

            var sut = _fixture.UpdateProduct.GenerateValidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().NotThrowAsync();
        }

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Try update a existing product with valid information, should update.")]
        public void Handle_ExistingProductInvalidInformation_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();

            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            var invalidNameRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.NAME, productViewModel));
            var invalidQuantityRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.QUANTITY, productViewModel));
            var firstInvalidPriceRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.PRICE, productViewModel));
            var secondInvalidPriceRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.PRICE_LOWER_THAN_COST, productViewModel));
            var firstInvalidCostRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.COST, productViewModel));
            var secondInvalidCostRequest = new UpdateProductCommand(productViewModel.Id, _fixture.ProductViewModel.GenerateInvalid(InvalidProductViewModelField.COST_HIGHER_THAN_PRICE, productViewModel));

            var sut = _fixture.UpdateProduct.GenerateValidHandler(product);

            //Act
            var firstact = async () => await sut.Handle(invalidNameRequest, CancellationToken.None);
            var secondAct = async () => await sut.Handle(invalidQuantityRequest, CancellationToken.None);
            var thirdAct = async () => await sut.Handle(firstInvalidPriceRequest, CancellationToken.None);
            var fourthAct = async () => await sut.Handle(secondInvalidPriceRequest, CancellationToken.None);
            var fiftAct = async () => await sut.Handle(firstInvalidCostRequest, CancellationToken.None);
            var sixtyAct = async () => await sut.Handle(secondInvalidCostRequest, CancellationToken.None);

            //Assert
            firstact.Should().ThrowExactlyAsync<InvalidNameException>();
            secondAct.Should().ThrowExactlyAsync<InvalidQuantityException>();
            thirdAct.Should().ThrowExactlyAsync<InvalidPriceException>();
            fourthAct.Should().ThrowExactlyAsync<InvalidPriceException>();
            fiftAct.Should().ThrowExactlyAsync<InvalidCostException>();
            sixtyAct.Should().ThrowExactlyAsync<InvalidCostException>();
        }

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Try update a unexisting product, should throw.")]
        public async Task Handle_UnexistingProduct_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateInvalid();
            var productViewModel = _fixture.ProductViewModel.GenerateValid();
            var request = _fixture.UpdateProduct.GenerateCommandFromViewModel(productViewModel);

            var sut = _fixture.UpdateProduct.GenerateValidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Try update a existing product with valid information but service unavailable, should throw.")]
        public async Task Handle_ExistingProductButServiceUnavailable_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var productViewModel = _fixture.ProductViewModel.GenerateValid();
            var request = _fixture.UpdateProduct.GenerateCommandFromViewModel(productViewModel);

            var sut = _fixture.UpdateProduct.GenerateInvalidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().ThrowExactlyAsync<InfrastructureException>();
        }
    }
}
