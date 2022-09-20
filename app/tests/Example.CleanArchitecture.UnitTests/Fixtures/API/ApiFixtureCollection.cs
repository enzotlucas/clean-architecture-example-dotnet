namespace Example.CleanArchitecture.UnitTests.Fixtures.API
{
    [CollectionDefinition(nameof(ApiFixtureCollection))]
    public class ApiFixtureCollection : ICollectionFixture<ApiFixture> { }

    public class ApiFixture : IDisposable
    {
        public ProductsControllerFixture ProductsController { get; private set; }

        public ProductViewModelFixture ProductViewModel { get; private set; }
        public CreateProductFixture CreateProduct { get; private set; }
        public UpdateProductFixture UpdateProduct { get; private set; }

        public ApiFixture()
        {
            ProductsController = new ProductsControllerFixture();

            ProductViewModel = new ProductViewModelFixture();
            CreateProduct = new CreateProductFixture();
            UpdateProduct = new UpdateProductFixture();
        }

        public void Dispose()
        {

        }
    }
}
