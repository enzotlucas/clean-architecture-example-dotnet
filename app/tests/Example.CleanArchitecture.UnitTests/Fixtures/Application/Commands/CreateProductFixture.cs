namespace Example.CleanArchitecture.UnitTests.Fixtures.Commands
{
    public class CreateProductFixture
    {
        private readonly Random _numberGenerator;

        public CreateProductFixture() => _numberGenerator = new Random();

        public CreateProductCommandHandler GenerateValidHandler(CreateProductCommand request, 
                                                                Product product,
                                                                ProductViewModel productViewModel)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.ExistsAsync(Arg.Any<Product>()).Returns(Task.FromResult(false));
            uow.Products.CreateAsync(Arg.Any<Product>()).Returns(Task.FromResult(product));
            uow.SaveChangesAsync().Returns(Task.FromResult(true));

            var logger = Substitute.For<ILogger<CreateProductCommandHandler>>();

            var mapper = Substitute.For<IMapper>();
            mapper.Map<Product>(request).Returns(product);
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            return new CreateProductCommandHandler(uow, logger, mapper);
        }

        public CreateProductCommandHandler GenerateInvalidHandler(CreateProductCommand request, bool exists, bool saveChanges)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.ExistsAsync(Arg.Any<Product>()).Returns(Task.FromResult(exists));
            uow.SaveChangesAsync().Returns(Task.FromResult(saveChanges));

            var logger = Substitute.For<ILogger<CreateProductCommandHandler>>();

            var mapper = Substitute.For<IMapper>();

            return new CreateProductCommandHandler(uow, logger, mapper);
        }

        public CreateProductCommand GenerateCommandFromEntity(Product product) => new()
        {
            Name = product.Name,
            Price = product.Price,
            Cost = product.Cost,
            Quantity = product.Quantity,
            Category = product.Category
        };

        public CreateProductCommand GenerateValidCommand() => new()
        {
            Name = "Product name",
            Price = _numberGenerator.Next(50, 100),
            Cost = _numberGenerator.Next(10, 49),
            Quantity = _numberGenerator.Next(1, 6),
            Category = (Category)_numberGenerator.Next(0, 2)
        };

        public CreateProductCommand GenerateInvalidCommand() => new()
        {
            Name = string.Empty,
            Price = _numberGenerator.Next(0, 4),
            Cost = _numberGenerator.Next(10, 50),
            Quantity = _numberGenerator.Next(1, 6),
            Category = (Category)_numberGenerator.Next(0, 2)
        };
    }
}
