namespace Example.CleanArchitecture.UnitTests.Fixtures.Application
{
    [CollectionDefinition(nameof(CoreFixtureCollection))]
    public class CoreFixtureCollection : ICollectionFixture<CoreFixture> { }

    public class CoreFixture : IDisposable
    {
        public ProductFixture Product { get; private set; }
        public SaleItemFixture SaleItem { get; private set; }

        public CoreFixture()
        {
            Product = new ProductFixture();
            SaleItem = new SaleItemFixture();
        }

        public IEnumerable<SaleItem> GenerateValidSaleItemCollection(int quantity)
        {
            var response = new List<SaleItem>();

            for (int i = 0; i < quantity; i++)
                response.Add(SaleItem.GenerateValid(Product.GenerateValid()));
            
            return response;
        }

        public void Dispose()
        {

        }
    }

}
