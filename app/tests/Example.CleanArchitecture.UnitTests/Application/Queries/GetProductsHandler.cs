namespace Example.CleanArchitecture.UnitTests.Application.Queries
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class GetProductsHandler
    {
        private readonly ApplicationFixture _fixture;

        public GetProductsHandler(ApplicationFixture fixture) => _fixture = fixture;

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
    }
}
