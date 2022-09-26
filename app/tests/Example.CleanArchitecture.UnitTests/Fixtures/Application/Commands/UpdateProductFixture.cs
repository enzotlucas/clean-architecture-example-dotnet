using Example.CleanArchitecture.Application.Commands.UpdateProduct;
namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.Commands
{
    public class UpdateProductFixture
    {
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

        public UpdateProductCommand GenerateCommandFromViewModel(ProductViewModel productViewModel) => new(productViewModel.Id, productViewModel);
    }
}
