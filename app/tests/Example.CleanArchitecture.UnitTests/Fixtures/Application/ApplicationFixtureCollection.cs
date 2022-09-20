using Example.CleanArchitecture.UnitTests.Fixtures.Application.Queries;

namespace Example.CleanArchitecture.UnitTests.Fixtures.Application
{
    [CollectionDefinition(nameof(ApplicationFixtureCollection))]
    public class ApplicationFixtureCollection : ICollectionFixture<ApplicationFixture> { }

    public class ApplicationFixture : IDisposable
    {
        public CreateProductFixture CreateProduct { get; private set; }
        public DeleteProductFixture DeleteProduct{ get; private set; }
        public UpdateProductFixture UpdateProduct { get; private set; }
        public GetProductByIdFixture GetProductById { get; private set; }
        public GetProductsFixture GetProducts { get; private set; }

        public ProductFixture Product { get; private set; }
        public ProductViewModelFixture ProductViewModel { get; private set; }

        public ApplicationFixture()
        {
            CreateProduct = new CreateProductFixture();
            DeleteProduct = new DeleteProductFixture();
            UpdateProduct = new UpdateProductFixture();
            GetProductById = new GetProductByIdFixture();
            GetProducts = new GetProductsFixture();
            Product = new ProductFixture();
            ProductViewModel = new ProductViewModelFixture();
        }

        public void Dispose()
        {

        }
    }

}
