namespace Exemplo.CRUD.UnitTests.Fixtures.Application
{
    public static class DeleteProductFixtures
    {
        public static DeleteProductHandler GenerateValidHandler(DeleteProduct request, Product product)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));
            repository.UnitOfWork.Commit().Returns(Task.FromResult(true));

            var logger = Substitute.For<ILogger<DeleteProductHandler>>();

            return new DeleteProductHandler(repository, logger);
        }

        public static DeleteProductHandler GenerateInvalidHandler(DeleteProduct request, Product product)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));
            repository.UnitOfWork.Commit().Returns(Task.FromResult(false));

            var logger = Substitute.For<ILogger<DeleteProductHandler>>();

            return new DeleteProductHandler(repository, logger);
        }
    }
}
