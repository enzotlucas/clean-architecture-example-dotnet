namespace Example.CleanArchitecture.UnitTests.Fixtures.API
{
    [CollectionDefinition(nameof(ApiFixtureCollection))]
    public class ApiFixtureCollection : ICollectionFixture<ApiFixture> { }

    public class ApiFixture : IDisposable
    {
        public ProductViewModelFixture ProductViewModel { get; private set; }
        public CreateProductFixture CreateProduct { get; private set; }

        public ApiFixture()
        {
            ProductViewModel = new ProductViewModelFixture();
            CreateProduct = new CreateProductFixture();
        }

        public void Dispose()
        {

        }
    }
}
