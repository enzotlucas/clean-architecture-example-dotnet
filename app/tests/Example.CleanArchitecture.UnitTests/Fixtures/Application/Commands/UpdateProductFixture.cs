using Example.CleanArchitecture.Application.Commands.UpdateProduct;
namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.Commands
{
    public class UpdateProductFixture
    {
        private readonly Random _numberGenerator;

        public UpdateProductFixture() => _numberGenerator = new Random();

        public UpdateProductCommandHandler GenerateValidHandler(Product product)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(product));
            uow.SaveChangesAsync().Returns(Task.FromResult(true));

            var logger = Substitute.For<ILogger<UpdateProductCommandHandler>>();

            return new UpdateProductCommandHandler(uow, logger);
        }

        public UpdateProductCommandHandler GenerateInvalidHandler(Product product)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(product));
            uow.SaveChangesAsync().Returns(Task.FromResult(false));

            var logger = Substitute.For<ILogger<UpdateProductCommandHandler>>();

            return new UpdateProductCommandHandler(uow, logger);
        }

        public UpdateProductCommand GenerateValidCommand() => new()
        {
            Id = Guid.NewGuid(),
            Name = "Product name",
            Price = _numberGenerator.Next(50, 100),
            Cost = _numberGenerator.Next(10, 49),
            Quantity = _numberGenerator.Next(1, 6),
            Enabled = true,
            Category = (Category)_numberGenerator.Next(0, 2)
        };

        public UpdateProductCommand GenerateInvalidCommand() => new();
    }
}
