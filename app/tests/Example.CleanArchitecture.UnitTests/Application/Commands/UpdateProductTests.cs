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
            var name = "Product Name Custom";
            var price = 10.0m;
            var cost = 1.0m;
            var quantity = 10;
            var category = Category.DRINK;

            //Act
            var query = new UpdateProductCommand
            {
                Name = name,
                Price = price,
                Cost = cost,
                Quantity = quantity,
                Category = category
            };

            //Assert
            query.Should().NotBe(null);
        }

        [Trait("UpdateProduct", "Application")]
        [Fact(DisplayName = "Try update a existing product with valid information, should update.")]
        public async Task Handle_ExistingProduct_ShouldUpdate()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = _fixture.UpdateProduct.GenerateValidCommand();

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
            var invalidNameRequest = new UpdateProductCommand { Name = string.Empty };
            var invalidQuantityRequest = new UpdateProductCommand { Quantity = -1 };
            var firstInvalidPriceRequest = new UpdateProductCommand { Price = -1 };
            var secondInvalidPriceRequest = new UpdateProductCommand { Price = product.Cost - 1 };
            var firstInvalidCostRequest = new UpdateProductCommand { Cost = -1 };
            var secondInvalidCostRequest = new UpdateProductCommand { Cost = product.Price + 1 };

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
            var request = _fixture.UpdateProduct.GenerateValidCommand();

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
            var request = _fixture.UpdateProduct.GenerateValidCommand();

            var sut = _fixture.UpdateProduct.GenerateInvalidHandler(product);

            //Act
            var act = async () => await sut.Handle(request, CancellationToken.None);

            //Assert
            await act.Should().ThrowExactlyAsync<InfrastructureException>();
        }
    }
}
