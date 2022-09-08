namespace Exemplo.CRUD.UnitTests.Fixtures.Models
{
    public static class ProductFixtures
    {
        public static IEnumerable<Product> GenerateList(int quantity) =>
           new Faker<Product>().RuleFor(p => p.Id, Guid.NewGuid())
                               .RuleFor(p => p.Name, $"Product name {new Random().Next(quantity)}")
                               .RuleFor(p => p.Price, decimal.Parse(new Random().Next(quantity).ToString()))
                               .RuleFor(p => p.CreatedAt, f => f.Date.Recent(100))
                               .RuleFor(p => p.Category, new Category($"Category name {new Random().Next(quantity)}"))
                               .Generate(quantity);
    }
}
