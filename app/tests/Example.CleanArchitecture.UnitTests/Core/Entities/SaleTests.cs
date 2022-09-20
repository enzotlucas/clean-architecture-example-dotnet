namespace Example.CleanArchitecture.UnitTests.Core.Entities
{
    [Collection(nameof(CoreFixtureCollection))]
    public sealed class SaleTests
    {
        private readonly CoreFixture _fixture;

        public SaleTests(CoreFixture fixture) => _fixture = fixture;

        [Trait("Sale", "Core")]
        [Fact(DisplayName = "Initialize a valid sale")]
        public void Constructor_ValidInformations_ShouldReturnSale()
        {
            //Arrange
            var items = _fixture.GenerateValidSaleItemCollection(5);
            var validator = new SaleValidator();

            var expectedTotalPrice = items.Sum(i => i.TotalPrice);

            //Act
            var sale = new Sale(items, validator);

            //Assert
            sale.Should().NotBe(null);
            sale.TotalPrice.Should().Be(expectedTotalPrice);
            sale.Items.Should().NotBeEmpty();
        }

        [Trait("Sale", "Core")]
        [Fact(DisplayName = "Try initialize a sale with invalid informations, should throw")]
        public void Constructor_InvalidInformations_ShouldThrow()
        {
            //Arrange
            var firstItems = new List<SaleItem>();
            var secondItems = _fixture.SaleItem.GenerateInvalidCollection(4);
            var validator = new SaleValidator();

            //Act
            var firstAct = () => { _ = new Sale(firstItems, validator); };
            var secondAct = () => { _ = new Sale(secondItems, validator); };

            //Assert
            firstAct.Should().ThrowExactly<InvalidSaleException>();
            secondAct.Should().ThrowExactly<InvalidSaleException>();
        }
    }
}
