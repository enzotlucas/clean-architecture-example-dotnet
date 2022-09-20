namespace Example.CleanArchitecture.UnitTests.API.Controllers
{
    [Collection(nameof(ApiFixtureCollection))]
    public class ProductsControllerTests
    {
        private readonly ApiFixture _fixture;

        public ProductsControllerTests(ApiFixture fixture) => _fixture = fixture;

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try get a existing product, should return product view model")]
        public async Task GetById_ExistingProduct_ShouldReturnProductViewModel()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<GetProductByIdQuery>()).Returns(Task.FromResult(productViewModel));

            var sut = new ProductsController(mediator);

            //Act
            var response = await sut.GetById(productViewModel.Id) as ObjectResult;

            //Assert
            response.Should().NotBe(null);
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Should().BeAssignableTo<OkObjectResult>();
            response.Value.Should().BeAssignableTo<ProductViewModel>();
            response.Value.Should().Be(productViewModel);
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try get a unexisting product, should throw")]
        public void GetById_UnexistingProduct_ShouldThrow()
        {
            //Arrange
            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<GetProductByIdQuery>()).ThrowsAsync(new ProductNotFoundException());

            var sut = new ProductsController(mediator);

            //Act
            var act = async () => { await sut.GetById(Guid.NewGuid()); };

            //Assert
            act.Should().ThrowAsync<ProductNotFoundException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try get a existing product list, should return product view model list")]
        public async Task Get_ExistingProduct_ShouldReturnProductViewModelColection()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValidCollection(5);

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<GetProductsQuery>()).Returns(Task.FromResult(productViewModel));

            var sut = new ProductsController(mediator);

            //Act
            var response = await sut.Get(page: 1, pageCount: 10) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Should().BeAssignableTo<OkObjectResult>();
            response.Value.Should().BeAssignableTo<IEnumerable<ProductViewModel>>();
            response.Value.Should().Be(productViewModel);
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try get a unexisting product, should return empty list")]
        public async Task Get_UnexistingProduct_ShouldReturnEmptyCollection()
        {
            //Arrange
            var productViewModel = new List<ProductViewModel>();

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<GetProductsQuery>()).Returns(productViewModel);

            var sut = new ProductsController(mediator);

            //Act
            var response = await sut.Get(page: 1, pageCount: 10) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Should().BeAssignableTo<OkObjectResult>();
            response.Value.Should().BeAssignableTo<IEnumerable<ProductViewModel>>();
            response.Value.Should().Be(productViewModel);
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a product with valid informations, should return created")]
        public async Task Post_ValidInformations_ShouldReturnCreated()
        {
            //Arrange
            var command = _fixture.CreateProduct.GenerateValidCommand();
            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<CreateProductCommand>()).Returns(Task.FromResult(productViewModel));

            var sut = new ProductsController(mediator);

            //Act
            var response = await sut.Post(command) as ObjectResult;

            //Assert
            response.Should().NotBe(null);
            response.StatusCode.Should().Be(StatusCodes.Status201Created);
            response.Value.Should().BeAssignableTo<ProductViewModel>();
            response.Value.Should().Be(productViewModel);
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a product with invalid informations, should throw")]
        public void Post_InvalidInformations_ShouldThrow()
        {
            //Arrange
            var command = _fixture.CreateProduct.GenerateInvalidCommand();

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<CreateProductCommand>()).ThrowsAsync(new InvalidProductException());

            var sut = new ProductsController(mediator);

            //Act
            var act = async () => { await sut.Post(command); };

            //Assert
            act.Should().ThrowAsync<InvalidProductException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a existing product, should throw")]
        public void Post_ExistingProduct_ShouldThrow()
        {
            //Arrange
            var command = _fixture.CreateProduct.GenerateValidCommand();

            var mediator = Substitute.For<IMediator>();
            mediator.Send(Arg.Any<CreateProductCommand>()).ThrowsAsync(new ProductExistsException());

            var sut = new ProductsController(mediator);

            //Act
            var act = async () => { await sut.Post(command); };

            //Assert
            act.Should().ThrowAsync<ProductExistsException>();
        }
    }
}
