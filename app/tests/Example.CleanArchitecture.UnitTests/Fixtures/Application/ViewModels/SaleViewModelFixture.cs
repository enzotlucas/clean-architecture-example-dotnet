namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.ViewModels
{
    public class SaleViewModelFixture
    {
        private readonly Random _numberGenerator;

        public SaleViewModelFixture() => _numberGenerator = new Random();

        public SaleViewModel GenerateValid() => GenerateValidCollection(1).First();

        public IEnumerable<SaleViewModel> GenerateValidCollection(int quantity) => 
            new Faker<SaleViewModel>().RuleFor(s => s.Id, Guid.NewGuid())
                                      .RuleFor(s => s.TotalPrice, (decimal)_numberGenerator.NextDouble())
                                      .RuleFor(s => s.Items,
                                               new Faker<SaleItemViewModel>().RuleFor(s => s.ProductId, Guid.NewGuid())
                                                                             .RuleFor(s => s.Quantity, _numberGenerator.Next(1, 10))
                                                                             .Generate(_numberGenerator.Next(1, 4)))
                                      .Generate(quantity);
    }
}
