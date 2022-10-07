namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.ViewModels
{
    public class ProductViewModelFixture
    {
        private readonly Random _numberGenerator;

        public ProductViewModelFixture() => _numberGenerator = new Random();

        public ProductViewModel GenerateValid() => GenerateValidCollection(1).First();

        public IEnumerable<ProductViewModel> GenerateValidCollection(int quantity) =>
            new Faker<ProductViewModel>().RuleFor(p => p.Id, Guid.NewGuid())
                                         .RuleFor(p => p.Name, $"Product Name {_numberGenerator.Next(1, 10000)}")
                                         .RuleFor(p => p.Price, _numberGenerator.Next(50, 100))
                                         .RuleFor(p => p.Cost, _numberGenerator.Next(10, 50))
                                         .RuleFor(p => p.Quantity, _numberGenerator.Next(10, 100))
                                         .RuleFor(p => p.Category, (Category)_numberGenerator.Next(0, 2))
                                         .RuleFor(p => p.Enabled, true)
                                         .Generate(quantity);

        public IEnumerable<ProductViewModel> GenerateValidCollectionFromEntity(IEnumerable<Product> products)
        {
            var response = new List<ProductViewModel>();

            foreach (var product in products)
                response.Add(GenerateValidFromEntity(product));

            return response;
        }

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

        public ProductViewModel GenerateInvalid(InvalidProductViewModelField invalidField, ProductViewModel productViewModel)
        {
            switch (invalidField)
            {
                case InvalidProductViewModelField.NAME:
                    productViewModel.Name = string.Empty;
                    break;
                case InvalidProductViewModelField.QUANTITY:
                    productViewModel.Quantity = -1;
                    break;
                case InvalidProductViewModelField.PRICE_LOWER_THAN_COST:
                    productViewModel.Price = productViewModel.Cost - 1;
                    break;
                case InvalidProductViewModelField.PRICE:
                    productViewModel.Price = -1;
                    break;
                case InvalidProductViewModelField.COST:
                    productViewModel.Cost = -1;
                    break;
                case InvalidProductViewModelField.COST_HIGHER_THAN_PRICE:
                    productViewModel.Cost = productViewModel.Price + 1;
                    break;
                default:
                    return GenerateInvalid();
            }

            return productViewModel;
        }

        public ProductViewModel GenerateInvalid() => new();
    }

    public enum InvalidProductViewModelField
    {
        NAME,
        QUANTITY,
        PRICE_LOWER_THAN_COST,
        PRICE,
        COST,
        COST_HIGHER_THAN_PRICE,
        ALL
    }
}