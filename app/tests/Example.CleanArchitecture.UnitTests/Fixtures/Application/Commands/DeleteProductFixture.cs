namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.Commands
{
    public class DeleteProductFixture
    {
        public DeleteProductCommandHandler GenerateValidHandler(Product product)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(product));
            uow.SaveChangesAsync().Returns(Task.FromResult(true));

            var logger = Substitute.For<ILogger<DeleteProductCommandHandler>>();

            return new DeleteProductCommandHandler(uow, logger);
        }

        public DeleteProductCommandHandler GenerateInvalidHandler(Product product)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(Task.FromResult(product));
            uow.SaveChangesAsync().Returns(Task.FromResult(false));

            var logger = Substitute.For<ILogger<DeleteProductCommandHandler>>();

            return new DeleteProductCommandHandler(uow, logger);
        }
    }
}
