namespace Example.CleanArchitecture.UnitTests.Application.Queries
{
    [Collection(nameof(ApplicationFixtureCollection))]
    public class GetSalesTests
    {
        private readonly ApplicationFixture _fixture;

        public GetSalesTests(ApplicationFixture fixture) => _fixture = fixture;

        [Trait("GetSales", "Application")]
        [Fact(DisplayName = "Create query with any informations")]
        public void Constructor_AnyInformations_ShouldReturnValidQuery()
        {
            //Arrange
            var page = 1;
            var pageCount = 10;

            //Assert
            var query = new GetSalesQuery(page, pageCount);

            //Act
            query.Should().NotBeNull();
        }

        [Trait("GetSales", "Application")]
        [Fact(DisplayName = "Try get sales with existing sales, should return sales list")]
        public async Task Handle_ExistingSales_ShouldReturnSaleList()
        {
            //Arrange
            var sales = _fixture.Sale.GenerateValidCollection(5);
            var saleViewModels = _fixture.SaleViewModel.GenerateValidCollectionFromEntity(sales);
            var request = new GetSalesQuery(page: 1, rows: 10);

            var sut = _fixture.GetSales.GenerateValidHandler(sales, saleViewModels);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Should().NotBeEmpty();
            response.Equals(saleViewModels).Should().BeTrue();
            response.Equals(sales).Should().BeFalse();
        }

        [Trait("GetSales", "Application")]
        [Fact(DisplayName = "Try get sales without sales, should return empty sales list")]
        public async Task Handle_UnexistingSales_ShouldReturnEmptySalesList()
        {
            //Arrange
            var sales = new List<Sale>();
            var saleViewModels = new List<SaleViewModel>();
            var request = new GetSalesQuery(page: 1, rows: 10);

            var sut = _fixture.GetSales.GenerateValidHandler(sales, saleViewModels);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.Should().BeEmpty();
            response.Equals(saleViewModels).Should().BeTrue();
            response.Equals(sales).Should().BeFalse();
        }

        [Trait("GetSales", "Application")]
        [Fact(DisplayName = "Try get sales without valid page and rows, should throw")]
        public async Task Handle_ExistingSalesInvalidPagesAndRows_ShouldThrow()
        {
            //Arrange
            var firstRequest = new GetSalesQuery(page: null, rows: 10);
            var secondRequest = new GetSalesQuery(page: 1, rows: null);
            var thirdRequest = new GetSalesQuery(page: null, rows: null);
            var fourthRequest = new GetSalesQuery(page: 0, rows: 10);
            var fiftRequest = new GetSalesQuery(page: 1, rows: 0);

            var sut = _fixture.GetSales.GenerateValidHandler(new List<Sale>(), new List<SaleViewModel>());

            //Act
            var firstAct = () => sut.Handle(firstRequest, CancellationToken.None);
            var secondAct = () => sut.Handle(secondRequest, CancellationToken.None);
            var thirdAct = () => sut.Handle(thirdRequest, CancellationToken.None);
            var fourthAct = () => sut.Handle(fourthRequest, CancellationToken.None);
            var fiftAct = () => sut.Handle(fiftRequest, CancellationToken.None);

            //Assert
            await firstAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await secondAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await thirdAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await fourthAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
            await fiftAct.Should().ThrowExactlyAsync<BusinessException>()
                                   .WithMessage("The number of page and row need to be at least one");
        }
    }
}
