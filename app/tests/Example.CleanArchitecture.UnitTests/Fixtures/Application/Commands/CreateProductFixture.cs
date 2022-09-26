namespace Example.CleanArchitecture.UnitTests.Fixtures.Commands
{
    public class CreateProductFixture
    {
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

        public CreateProductCommandHandler GenerateInvalidHandler(bool exists, bool saveChanges)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.ExistsAsync(Arg.Any<Product>()).Returns(Task.FromResult(exists));
            uow.SaveChangesAsync().Returns(Task.FromResult(saveChanges));

            var logger = Substitute.For<ILogger<CreateProductCommandHandler>>();

            var mapper = Substitute.For<IMapper>();

            return new CreateProductCommandHandler(uow, logger, mapper);
        }

        public CreateProductCommand GenerateFromViewModel(ProductViewModel productViewModel) => new(productViewModel);
    }
}
