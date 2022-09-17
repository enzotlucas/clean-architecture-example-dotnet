namespace Example.CleanArchitecture.UnitTests.Fixtures
{
    public sealed class SaleItemFixture
    {
        public static SaleItem GenerateValid() => 
            GenerateValidCollection(1).FirstOrDefault();

        public static IEnumerable<SaleItem> GenerateValidCollection(int quantity)
        {
            var product = ProductFixture.GenerateValid();

            return new Faker<SaleItem>().CustomInstantiator(s =>
                            new SaleItem(quantity: new Random().Next(1, 5),
                                         product: product))
                                        .Generate(quantity);
        }

        public static SaleItem GenerateInvalid() =>
            GenerateInvalidCollection(1).FirstOrDefault();
        public static IEnumerable<SaleItem> GenerateInvalidCollection(int quantity) => 
            new Faker<SaleItem>().Generate(quantity);
    }
}
