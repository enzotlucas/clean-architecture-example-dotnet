namespace Example.CleanArchitecture.UnitTests.Application.Queries
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class GetProductsTests
    {
        private readonly ApplicationFixture _fixture;

        public GetProductsTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("GetProducts", "Application")]
        [Fact(DisplayName = "Create query with any informations")]
        public void Constructor_AnyInformations_ShouldReturnValidQuery()
        {
            //Arrange
            var page = 1;
            var pageCount = 10;

            //Assert
            var query = new GetProductsQuery(page, pageCount);

            //Act
            query.Should().NotBeNull();
        }

        [Trait("GetProducts", "Application")]
        [Fact(DisplayName = "Try get products with existing products, should return product list")]
        public async Task Handle_ExistingProducts_ShouldReturnProductList()
        {
            //Arrange
            var products = _fixture.Product.GenerateValidCollection(5);
            var productViewModels = _fixture.ProductViewModel.GenerateValidCollectionFromEntity(products);
            var request = new GetProductsQuery(page: 1, rows: 10);

            var sut = _fixture.GetProducts.GenerateValidHandler(products, productViewModels);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Should().NotBeEmpty();
            response.Equals(productViewModels).Should().BeTrue();
            response.Equals(products).Should().BeFalse();
        }

        [Trait("GetProducts", "Application")]
        [Fact(DisplayName = "Try get products without products, should return empty product list")]
        public async Task Handle_UnexistingProducts_ShouldReturnEmptyProductList()
        {
            //Arrange
            var products = new List<Product>();
            var productViewModels = new List<ProductViewModel>();
            var request = new GetProductsQuery(page: 1, rows: 10);

            var sut = _fixture.GetProducts.GenerateValidHandler(products, productViewModels);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEmpty();
            response.Equals(productViewModels).Should().BeTrue();
            response.Equals(products).Should().BeFalse();
        }

        [Trait("GetProducts", "Application")]
        [Fact(DisplayName = "Try get products without valid page and rows, should throw")]
        public async Task Handle_ExistingProductsInvalidPagesAndRows_ShouldThrow()
        {
            //Arrange
            var firstRequest = new GetProductsQuery(page: null, rows: 10);
            var secondRequest = new GetProductsQuery(page: 1, rows: null);
            var thirdRequest = new GetProductsQuery(page: null, rows: null);
            var fourthRequest = new GetProductsQuery(page: 0, rows: 10);
            var fiftRequest = new GetProductsQuery(page: 1, rows: 0);

            var sut = _fixture.GetProducts.GenerateValidHandler(new List<Product>(), new List<ProductViewModel>());

            //Act
            var firstAct = () => sut.Handle(firstRequest, CancellationToken.None);
            var secondAct = () => sut.Handle(secondRequest, CancellationToken.None);
            var thirdAct = () => sut.Handle(thirdRequest, CancellationToken.None);
            var fourthAct = () => sut.Handle(fourthRequest, CancellationToken.None);
            var fiftAct = () => sut.Handle(fiftRequest, CancellationToken.None);

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
    }
}
