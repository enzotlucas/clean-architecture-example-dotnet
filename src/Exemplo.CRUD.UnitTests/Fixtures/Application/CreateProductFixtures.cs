namespace Exemplo.CRUD.UnitTests.Fixtures.Application
{
    public static class CreateProductFixtures
    {
        public static CreateProductHandler GenerateValidHandler(Product product, ProductViewModel productViewModel)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.Create(Arg.Any<Product>()).Returns(Task.FromResult(product));
            repository.UnitOfWork.Commit().Returns(Task.FromResult(true));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            var logger = Substitute.For<ILogger<CreateProductHandler>>();

            return new CreateProductHandler(repository, mapper, logger);
        }

        public static CreateProductHandler GenerateInvalidHandler()
        {
            var repository = Substitute.For<IProductRepository>();
            var mapper = Substitute.For<IMapper>();
            var logger = Substitute.For<ILogger<CreateProductHandler>>();
            return new CreateProductHandler(repository, mapper, logger);
        }
    }
}
