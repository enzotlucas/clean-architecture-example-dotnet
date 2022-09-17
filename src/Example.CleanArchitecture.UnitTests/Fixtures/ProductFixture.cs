namespace Example.CleanArchitecture.UnitTests.Fixtures
{
    public sealed class ProductFixture
    {
        private static readonly Random _numberGenerator = new();
        private static readonly ProductValidator _validator = new();

        public static Product GenerateValid() => GenerateValidCollection(1).First();

        public static IEnumerable<Product> GenerateValidCollection(int quantity) =>
            new Faker<Product>().CustomInstantiator(p =>
                            new Product(name: $"Product Name {_numberGenerator.Next(1, 10000)}",
                                        price: _numberGenerator.Next(50, 100),
                                        cost: _numberGenerator.Next(10, 50),
                                        quantity: _numberGenerator.Next(10, 100),
                                        category: (Category)_numberGenerator.Next(0, 2),
                                        validator: _validator))
                                .Generate(quantity);

        public static Product GenerateInvalid() => GenerateInvalidCollection(1).First();

        public static IEnumerable<Product> GenerateInvalidCollection(int quantity) =>
           new Faker<Product>().Generate(quantity);

    }
}
