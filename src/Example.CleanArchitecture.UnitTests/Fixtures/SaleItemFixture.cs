namespace Example.CleanArchitecture.UnitTests.Fixtures
{
    public sealed class SaleItemFixture
    {
        public static IEnumerable<SaleItem> GenerateValidSaleItems(int quantity)
        {
            var product = ProductFixture.GenerateValid();

            return new Faker<SaleItem>().RuleFor(s => s.Id, Guid.NewGuid())
                                        .RuleFor(s => s.Quantity, new Random().Next(1, 5))
                                        .RuleFor(s => s.Product, product)
                                        .RuleFor(s => s.ProductId, product.Id)
                                        .Generate(quantity);
        }

        public static SaleItem GenerateValidSaleItem() => GenerateValidSaleItems(1).FirstOrDefault();
    }
}
