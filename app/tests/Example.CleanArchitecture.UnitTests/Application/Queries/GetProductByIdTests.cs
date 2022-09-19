    namespace Example.CleanArchitecture.UnitTests.Application.Queries
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class GetProductByIdTests
    {
        private readonly ApplicationFixture _fixture;

        public GetProductByIdTests(ApplicationFixture fixture)
            => _fixture = fixture;

        [Trait("GetProductById", "Application")]
        [Fact(DisplayName = "Initialize the query.")]
        public void Constuctor_AnyInformations_ShouldCreateQuery()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var query = new GetProductByIdQuery(id);

            //Assert
            query.Should().NotBe(null);
        }

        [Trait("GetProductById", "Application")]
        [Fact(DisplayName = "Try get a existing product, should return product.")]
        public async Task Handle_ExistingProduct_ShouldReturnProduct()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = new GetProductByIdQuery(product.Id);
            var productViewModel = _fixture.ProductViewModel.GenerateValidFromEntity(product);

            var sut = _fixture.GetProductById.GenerateValidHandler(product, productViewModel);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(productViewModel);
            response.Should().NotBeNull();
        }

        [Trait("GetProductById", "Application")]
        [Fact(DisplayName = "Try get a non existing product, should throw.")]
        public void Handle_ValidInformation_ShouldThrow()
        {
            //Arrange
            var request = new GetProductByIdQuery(Guid.NewGuid());
            var sut = _fixture.GetProductById.GenerateInvalidHandler();

            //Act
            var act = async () => { await sut.Handle(request, CancellationToken.None); };

            //Assert
            act.Should().ThrowAsync<ProductNotFoundException>();
        }
    }
}
