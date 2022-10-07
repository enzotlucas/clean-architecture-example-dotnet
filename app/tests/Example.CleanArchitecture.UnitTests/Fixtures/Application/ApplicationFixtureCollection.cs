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
        public GetSalesFixture GetSales { get; private set; }

        public ProductFixture Product { get; private set; }
        public SaleFixture Sale { get; private set; }

        public ProductViewModelFixture ProductViewModel { get; private set; }
        public SaleViewModelFixture SaleViewModel { get; private set; }

        public ApplicationFixture()
        {
            CreateProduct = new CreateProductFixture();
            DeleteProduct = new DeleteProductFixture();
            UpdateProduct = new UpdateProductFixture();
            GetProductById = new GetProductByIdFixture();
            GetProducts = new GetProductsFixture();
            GetSales = new GetSalesFixture();

            Product = new ProductFixture();
            Sale = new SaleFixture();

            ProductViewModel = new ProductViewModelFixture();
            SaleViewModel = new SaleViewModelFixture();
        }

        public void Dispose()
        {

        }
    }

}
