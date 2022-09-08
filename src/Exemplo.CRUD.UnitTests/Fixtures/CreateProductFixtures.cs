namespace Exemplo.CRUD.Tests.Fixtures
{
    public static class CreateProductFixtures
    {
        public static CreateProductHandler GenerateValidCreateProductHandler(Product product, ProductViewModel productViewModel)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.Create(Arg.Any<Product>()).Returns(Task.FromResult(product));
            repository.UnitOfWork.Commit().Returns(Task.FromResult(true));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            var logger = Substitute.For<ILogger<CreateProductHandler>>();

            return new CreateProductHandler(repository, mapper, logger);
        }

        public static CreateProductHandler GenerateInvalidCreateProductHandler()
        {
            var repository = Substitute.For<IProductRepository>();
            var mapper = Substitute.For<IMapper>();
            var logger = Substitute.For<ILogger<CreateProductHandler>>();
            return new CreateProductHandler(repository, mapper, logger);
        }
    }
}
