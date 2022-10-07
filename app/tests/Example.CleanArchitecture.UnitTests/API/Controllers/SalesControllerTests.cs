namespace Example.CleanArchitecture.UnitTests.API.Controllers
{
    [Collection(nameof(ApiFixtureCollection))]
    public class SalesControllerTests
    {
        private readonly ApiFixture _fixture;

        public SalesControllerTests(ApiFixture fixture) => _fixture = fixture;

        [Trait("SalesController", "API")]
        [Fact(DisplayName = "Try get a existing sale list, should return sale view model list")]
        public async Task Get_ExistingSales_ShouldReturnSaleViewModelColection()
        {
            //Arrange
            var salesViewModel = _fixture.SaleViewModel.GenerateValidCollection(5);

            var sut = _fixture.SalesController.GenerateValid(salesViewModel);

            //Act
            var response = await sut.Get(page: 1, pageCount: 10) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Should().BeAssignableTo<OkObjectResult>();
            response.Value.Should().BeAssignableTo<IEnumerable<SaleViewModel>>();
            response.Value.Should().Be(salesViewModel);
        }

        [Trait("SalesController", "API")]
        [Fact(DisplayName = "Try get a unexisting sale, should return empty list")]
        public async Task Get_UnexistingSales_ShouldReturnEmptyCollection()
        {
            //Arrange
            var salesViewModel = new List<SaleViewModel>();

            var sut = _fixture.SalesController.GenerateValid(salesViewModel);

            //Act
            var response = await sut.Get(page: 1, pageCount: 10) as ObjectResult;

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            response.Should().BeAssignableTo<OkObjectResult>();
            response.Value.Should().BeAssignableTo<IEnumerable<SaleViewModel>>();
            response.Value.Should().Be(salesViewModel);
        }

        [Trait("SalesController", "API")]
        [Fact(DisplayName = "Try get existing sales but with invalid page or roll, should throw")]
        public async Task Get_ExistingSalesInvalidPagesAndRows_ShouldThrow()
        {
            //Arrange
            var firstRequest = new GetSalesQuery(page: null, rows: 10);
            var secondRequest = new GetSalesQuery(page: 1, rows: null);
            var thirdRequest = new GetSalesQuery(page: null, rows: null);
            var fourthRequest = new GetSalesQuery(page: 0, rows: 10);
            var fiftRequest = new GetSalesQuery(page: 1, rows: 0);

            var sut = _fixture.SalesController.GenerateInvalid(false);

            //Act
            var firstAct = () => sut.Get(firstRequest.Page, firstRequest.Rows);
            var secondAct = () => sut.Get(secondRequest.Page, secondRequest.Rows);
            var thirdAct = () => sut.Get(thirdRequest.Page, thirdRequest.Rows);
            var fourthAct = () => sut.Get(fourthRequest.Page, fourthRequest.Rows);
            var fiftAct = () => sut.Get(fiftRequest.Page, fiftRequest.Rows);

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
