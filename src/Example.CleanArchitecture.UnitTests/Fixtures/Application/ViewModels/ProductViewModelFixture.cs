namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.ViewModels
{
    public class ProductViewModelFixture
    {
        public ProductViewModel GenerateValidFromEntity(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Cost = product.Cost,
            Quantity = product.Quantity,
            Category = product.Category,
            Enabled = product.Enabled
        };
    }
}