namespace Example.CleanArchitecture.UnitTests.Fixtures.API.Controllers
{
    public class SalesControllerFixture
    {
        public SalesController GenerateValid(IEnumerable<SaleViewModel> salesViewModel = null)
        {
            var mediator = Substitute.For<IMediator>();

            mediator.Send(Arg.Any<GetSalesQuery>()).Returns(Task.FromResult(salesViewModel));

            return new SalesController(mediator);
        }

        public SalesController GenerateInvalid(bool invalidSale)
        {
            var mediator = Substitute.For<IMediator>();

            mediator.Send(Arg.Any<GetSalesQuery>()).ThrowsAsync(new BusinessException("The number of page and row need to be at least one"));

            return new SalesController(mediator);
        }
    }
}
