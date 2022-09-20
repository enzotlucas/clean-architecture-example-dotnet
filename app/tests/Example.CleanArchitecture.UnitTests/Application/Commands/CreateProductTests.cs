namespace Example.CleanArchitecture.UnitTests.Application.Commands
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class CreateProductTests
    {
        private readonly ApplicationFixture _fixture;

        public CreateProductTests(ApplicationFixture fixture) 
            => _fixture = fixture;

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Initialize the command.")]
        public void Constructor_AnyInformations_ShouldCreateCommand()
        {
            //Arrange
            var name = "Product Name";
            var price = 5.0m;
            var cost = 2.0m;
            var quantity = 4;
            var category = Category.TECH;

            //Act
            var command = new CreateProductCommand
            {
                Name = name,
                Price = price,
                Cost = cost,
                Quantity = quantity,
                Category = category
            };

            //Assert
            command.Should().NotBe(null);
        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with valid information, should return created.")]
        public async Task Handle_ValidInformation_ShouldReturnCreated()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = _fixture.CreateProduct.GenerateCommandFromEntity(product);
            var productViewModel = _fixture.ProductViewModel.GenerateValidFromEntity(product);

            var sut = _fixture.CreateProduct.GenerateValidHandler(request, product, productViewModel);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(productViewModel);
            response.Should().NotBeNull();
        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with invalid information, should throw.")]
        public void Handle_InvalidInformation_ShouldThrow()
        {
            var product = _fixture.Product.GenerateInvalid();
            var request = _fixture.CreateProduct.GenerateCommandFromEntity(product);

            var sut = _fixture.CreateProduct.GenerateInvalidHandler(request,
                                                                    exists: false,
                                                                    saveChanges: true);

            //Act
            var act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            act.Should().ThrowExactlyAsync<InvalidProductException>();
        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a existing product, should throw.")]
        public void Handle_ExistingProduct_ShouldThrow()
        {
            var product = _fixture.Product.GenerateInvalid();
            var request = _fixture.CreateProduct.GenerateCommandFromEntity(product);

            var sut = _fixture.CreateProduct.GenerateInvalidHandler(request,
                                                                    exists: true,
                                                                    saveChanges: true);

            //Act
            var act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductExistsException>();
        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with valid information, but unavailable environment, should throw.")]
        public void Handle_ValidInformationServiceUnavailable_ShouldThrow()
        {
            var product = _fixture.Product.GenerateValid();
            var request = _fixture.CreateProduct.GenerateCommandFromEntity(product);

            var sut = _fixture.CreateProduct.GenerateInvalidHandler(request,
                                                                    exists: false,
                                                                    saveChanges: false);

            //Act
            var act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            act.Should().ThrowExactlyAsync<InfrastructureException>();
        }
    }
}
