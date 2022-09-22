namespace Example.CleanArchitecture.UnitTests.Application.Services
{
    [Collection(nameof(ApplicationFixture))]
    public class ProductServiceTests
    {
        private readonly ApplicationFixture _fixture;

        public ProductServiceTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("ProductServiceT", "Application")]
        [Fact]
        public void DeleteProductAndItSales_ExistingSales_ShouldDeleteSales()
        {
            //Arrange
            //var product = _fixture.Product.GenerateValid();

            //var uow = Substitute.For<IUnitOfWork>();
            //uow.SaveChangesAsync().Returns(Task.FromResult(true));

            //var logger = Substitute.For<ILogger<ProductService>>();

            //var sut = new ProductService(uow,logger);

            ////Act
            //var response = sut.DeleteProductAndItSales(product);

            ////Assert
            //response.Should().Be(true);
        }
    }
}
