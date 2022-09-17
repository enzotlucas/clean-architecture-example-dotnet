namespace Example.CleanArchitecture.UnitTests.Fixtures.Application
{
    [CollectionDefinition(nameof(ApplicationFixtureCollection))]
    public class ApplicationFixtureCollection : ICollectionFixture<ApplicationFixture> { }

    public class ApplicationFixture : IDisposable
    {
        public CreateProductFixture CreateProduct { get; private set; }
        public ProductFixture Product { get; private set; }

        public ApplicationFixture()
        {
            CreateProduct = new CreateProductFixture();
            Product = new ProductFixture();
        }

        public void Dispose()
        {

        }
    }

}
