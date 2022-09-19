namespace Example.CleanArchitecture.UnitTests.Application.Commands
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class DeleteProductTests
    {
        private readonly ApplicationFixture _fixture;

        public DeleteProductTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Initialize the command.")]
        public void Constuctor_AnyInformations_ShouldCreateCommand()
        {
            //Arrange
            var id = Guid.NewGuid();

            //Act
            var query = new DeleteProductCommand(id);

            //Assert
            query.Should().NotBe(null);
        }

        [Trait("DeleteProduct", "Application")]
        [Fact(DisplayName = "Try delete a existing product, should delete.")]
        public async Task Handle_ExistingProduct_ShouldDelete()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = new DeleteProductCommand(product.Id);

            var uow = Substitute.For<IUnitOfWork>();
            var mapper = Substitute.For<IMapper>();

            var sut = new DeleteProductCommandHandler(uow, mapper);

            //Act

            //Assert
        }
    }
}
