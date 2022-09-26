using Example.CleanArchitecture.Application.ViewModels;

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

            var sut = _fixture.ProductsController.GenerateValid(productViewModel);

            //Act
            var response = await sut.GetById(productViewModel.Id) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
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
            var sut = _fixture.ProductsController.GenerateInvalid(false);

            //Act
            var act = async () => { await sut.GetById(Guid.NewGuid()); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try get a existing product list, should return product view model list")]
        public async Task Get_ExistingProduct_ShouldReturnProductViewModelColection()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValidCollection(5);

            var sut = _fixture.ProductsController.GenerateValid(productViewModel);

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

            var sut = _fixture.ProductsController.GenerateValid(productViewModel);

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
        [Fact(DisplayName = "Try get a existing product but with invalid page or roll, should throw")]
        public async Task Handle_ExistingProductsInvalidPagesAndRows_ShouldThrow()
        {
            //Arrange
            var firstRequest = new GetProductsQuery(page: null, rows: 10);
            var secondRequest = new GetProductsQuery(page: 1, rows: null);
            var thirdRequest = new GetProductsQuery(page: null, rows: null);
            var fourthRequest = new GetProductsQuery(page: 0, rows: 10);
            var fiftRequest = new GetProductsQuery(page: 1, rows: 0);

            var sut = _fixture.ProductsController.GenerateInvalid(false);

            //Act
            var firstAct = () => sut.Get(firstRequest.Page, firstRequest.Rows);
            var secondAct = () => sut.Get(secondRequest.Page, secondRequest.Rows);
            var thirdAct = () => sut.Get(thirdRequest.Page, thirdRequest.Rows);
            var fourthAct = () => sut.Get(fourthRequest.Page, fourthRequest.Rows);
            var fiftAct = () => sut.Get(fiftRequest.Page, fiftRequest.Rows);

            //Assert
            await firstAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await secondAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await thirdAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await fourthAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await fiftAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a product with valid informations, should return created")]
        public async Task Post_ValidInformations_ShouldReturnCreated()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            var sut = _fixture.ProductsController.GenerateValid(productViewModel);

            //Act
            var response = await sut.Post(productViewModel) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status201Created);
            response.Value.Should().BeAssignableTo<ProductViewModel>();
            response.Value.Should().Be(productViewModel);
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a product with invalid informations, should throw")]
        public void Post_InvalidInformations_ShouldThrow()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateInvalid();

            var sut = _fixture.ProductsController.GenerateInvalid(true);

            //Act
            var act = async () => { await sut.Post(productViewModel); };

            //Assert
            act.Should().ThrowExactlyAsync<InvalidProductException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try create a existing product, should throw")]
        public void Post_ExistingProduct_ShouldThrow()
        {
            //Arrange
            var productViewModel = _fixture.ProductViewModel.GenerateValid();

            var sut = _fixture.ProductsController.GenerateInvalid(false);

            //Act
            var act = async () => { await sut.Post(productViewModel); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductExistsException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try delete a existing product, should return product view model")]
        public async Task Delete_ExistingProduct_ShouldReturnNoContent()
        {
            //Arrange
            var sut = _fixture.ProductsController.GenerateValid();

            //Act
            var response = await sut.Delete(Guid.NewGuid()) as NoContentResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            response.Should().BeAssignableTo<NoContentResult>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try delete a unexisting product, should throw")]
        public void Delete_UnexistingProduct_ShouldThrow()
        {
            //Arrange
            var sut = _fixture.ProductsController.GenerateInvalid(false);

            //Act
            var act = async () => { await sut.Delete(Guid.NewGuid()); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try update a existing product with valid informations, should return product view model")]
        public async Task Put_ExistingProduct_ShouldReturnNoContent()
        {
            //Arrange
            var sut = _fixture.ProductsController.GenerateValid();

            //Act
            var response = await sut.Put(Guid.NewGuid(), _fixture.ProductViewModel.GenerateValid()) as NoContentResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status204NoContent);
            response.Should().BeAssignableTo<NoContentResult>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try update a unexisting product, should throw")]
        public void Put_UnexistingProduct_ShouldThrow()
        {
            //Arrange
            var sut = _fixture.ProductsController.GenerateInvalid(false);

            //Act
            var act = async () => { await sut.Put(Guid.NewGuid(), _fixture.ProductViewModel.GenerateValid()); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }

        [Trait("ProductsController", "API")]
        [Fact(DisplayName = "Try update a existing product with invalid informations, should throw")]
        public void Put_ExistingProductInvalidInformation_ShouldThrow()
        {
            //Arrange
            var sut = _fixture.ProductsController.GenerateInvalid(true);

            //Act
            var act = async () => { await sut.Put(Guid.NewGuid(), _fixture.ProductViewModel.GenerateInvalid()); };

            //Assert
            act.Should().ThrowExactlyAsync<ProductNotFoundException>();
        }
    }
}
