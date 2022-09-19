namespace Example.CleanArchitecture.UnitTests.Fixtures.Entities
{
    public sealed class SaleItemFixture
    {
        public SaleItem GenerateValid(Product product) =>
            GenerateValidCollection(1, product).FirstOrDefault();

        public IEnumerable<SaleItem> GenerateValidCollection(int quantity, Product product) =>
            new Faker<SaleItem>().CustomInstantiator(s =>
                     new SaleItem(quantity: new Random().Next(1, 5),
                                  product: product))
                                 .Generate(quantity);

        public SaleItem GenerateInvalid() =>
            GenerateInvalidCollection(1).FirstOrDefault();
        public IEnumerable<SaleItem> GenerateInvalidCollection(int quantity) =>
            new Faker<SaleItem>().Generate(quantity);
    }
}
