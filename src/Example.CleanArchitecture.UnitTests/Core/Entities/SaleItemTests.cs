
namespace Example.CleanArchitecture.UnitTests.Core.Entities
{
    [Collection(nameof(CoreFixtureCollection))]
    public class SaleItemTests
    {
        private readonly CoreFixture _fixture;

        public SaleItemTests(CoreFixture fixture) => _fixture = fixture;

        [Trait("SaleItem", "Core")]
        [Fact(DisplayName = "Initialize a valid sale item.")]
        public void Constructor_ValidInformations_ShouldReturnSaleItem()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var quantity = product.Quantity - 1;

            var expectedTotalPrice = quantity * product.Price;

            //Act
            var saleItem = new SaleItem(quantity, product);

            //Assert
            saleItem.Should().NotBeNull();
            saleItem.Product.Should().Be(product);
            saleItem.ProductId.Should().Be(product.Id);
            saleItem.Quantity.Should().Be(quantity);
            saleItem.TotalPrice.Should().Be(expectedTotalPrice);
            saleItem.Id.Should().NotBe(Guid.Empty);
        }

        [Trait("SaleItem", "Core")]
        [Fact(DisplayName = "Try initialize a sale item with invalid informations.")]
        public void Constructor_InvalidInformations_ShouldThrow()
        {
            //Arrange
            var validProduct = _fixture.Product.GenerateValid();
            var invalidProduct = _fixture.Product.GenerateInvalid();

            var firstInvalidQuantity = validProduct.Quantity + 1;
            var secondInvalidQuantity = 0;
            var validQuantity = validProduct.Quantity - 1;


            //Act
            var firstAct = () => { _ = new SaleItem(firstInvalidQuantity, validProduct); };
            var secondAct = () => { _ = new SaleItem(secondInvalidQuantity, validProduct); };
            var thirdAct = () => { _ = new SaleItem(validQuantity, invalidProduct); };

            //Assert
            firstAct.Should().Throw<InvalidQuantityException>()
                             .WithMessage("The quantity is higher than stock");
            secondAct.Should().Throw<InvalidQuantityException>()
                              .WithMessage("The quantity is higher than stock");
            thirdAct.Should().Throw<InvalidProductException>();
        }
    }
}
