namespace Example.CleanArchitecture.UnitTests.Fixtures.Application
{
    [CollectionDefinition(nameof(ApplicationFixtureCollection))]
    public class ApplicationFixtureCollection : ICollectionFixture<ApplicationFixture> { }

    public class ApplicationFixture : IDisposable
    {
        public CreateProductFixture CreateProduct { get; private set; }
        public GetProductByIdFixture GetProductById { get; private set; }

        public ProductFixture Product { get; private set; }
        public ProductViewModelFixture ProductViewModel { get; private set; }

        public ApplicationFixture()
        {
            CreateProduct = new CreateProductFixture();
            GetProductById = new GetProductByIdFixture();
            Product = new ProductFixture();
            ProductViewModel = new ProductViewModelFixture();
        }

        public void Dispose()
        {

        }
    }

}
