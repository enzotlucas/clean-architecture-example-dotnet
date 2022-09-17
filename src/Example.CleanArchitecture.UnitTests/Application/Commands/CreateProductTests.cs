namespace Example.CleanArchitecture.UnitTests.Application.Commands
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class CreateProductTests
    {
        private readonly ApplicationFixture _fixture;

        public CreateProductTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName ="Initialize valid create product command.")]
        public async Task Constructor_ValidProductInformation_ShouldCreateCommandCorrectly()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var request = _fixture.CreateProduct.GenerateCommandFromEntity(product);

            var sut = _fixture.CreateProduct.GenerateValidHandler(request, product);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try initialize invalid create product command, should throw.")]
        public void Constructor_InvalidProductInformation_ShouldThrow()
        {

        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with valid information, should return created.")]
        public void Handle_ValidInformation_ShouldReturnCreated()
        {

        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with invalid information, should throw.")]
        public void Handle_InvalidInformation_ShouldThrow()
        {

        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a existing product, should throw.")]
        public void Handle_ExistingProduct_ShouldThrow()
        {

        }

        [Trait("CreateProduct", "Application")]
        [Fact(DisplayName = "Try create a product with valid information, but unavailable environment, should throw.")]
        public void Handle_ValidInformationServiceUnavailable_ShouldThrow()
        {

        }
    }
}
