namespace Example.CleanArchitecture.UnitTests.Fixtures.Entities
{
    public sealed class SaleItemFixture
    {
        private readonly ProductFixture _product = new();

        public SaleItem GenerateValid(Product product) =>
            GenerateValidCollection(1, product).FirstOrDefault();

        public IEnumerable<SaleItem> GenerateValidCollection(int quantity, Product product = null) =>
            new Faker<SaleItem>().CustomInstantiator(s =>
                     new SaleItem(quantity: new Random().Next(1, 5),
                                  product: product ?? _product.GenerateValid()))
                                 .Generate(quantity);

        public SaleItem GenerateInvalid() =>
            GenerateInvalidCollection(1).FirstOrDefault();
        public IEnumerable<SaleItem> GenerateInvalidCollection(int quantity) =>
            new Faker<SaleItem>().Generate(quantity);
    }
}
