namespace Example.CleanArchitecture.UnitTests.Fixtures.Core.Entities
{
    public class SaleFixture
    {
        private readonly Random _numberGenerator = new();
        private readonly SaleValidator _validator = new();
        private readonly SaleItemFixture _saleItem = new();

        public Sale GenerateValid() => GenerateValidCollection(1).First();

        public IEnumerable<Sale> GenerateValidCollection(int quantity) =>
            new Faker<Sale>().CustomInstantiator(p => new Sale(items: _saleItem.GenerateValidCollection(_numberGenerator.Next(1, 5)), _validator))
                             .Generate(quantity);

        public Sale GenerateInvalid() => GenerateInvalidCollection(1).First();

        public IEnumerable<Sale> GenerateInvalidCollection(int quantity) =>
           new Faker<Sale>().Generate(quantity);

    }
}
