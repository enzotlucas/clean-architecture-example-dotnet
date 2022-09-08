namespace Exemplo.CRUD.UnitTests.Fixtures.Models
{
    public static class ProductViewModelFixtures
    {
        public static IEnumerable<ProductViewModel> GenerateList(int quantity) =>
            new Faker<ProductViewModel>().RuleFor(p => p.Id, Guid.NewGuid())
                                         .RuleFor(p => p.Name, $"Product name {new Random().Next(quantity)}")
                                         .RuleFor(p => p.Price, decimal.Parse(new Random().Next(quantity).ToString()))
                                         .RuleFor(p => p.CreatedAt, f => f.Date.Recent(100))
                                         .RuleFor(p => p.Category, $"Category name {new Random().Next(quantity)}")
                                         .Generate(quantity);

        public static ProductViewModel GenerateFromEntity(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category.Name,
            CreatedAt = product.CreatedAt,
            Price = product.Price
        };
    }
}
