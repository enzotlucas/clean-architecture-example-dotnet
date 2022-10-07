namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.Queries
{
    public class GetSalesFixture
    {
        public GetSalesQueryHandler GenerateValidHandler(IEnumerable<Sale> sales,
                                                            IEnumerable<SaleViewModel> saleViewModels)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Sales.GetAllAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(sales);

            var mapper = Substitute.For<IMapper>();
            mapper.Map<IEnumerable<SaleViewModel>>(Arg.Any<IEnumerable<Sale>>()).Returns(saleViewModels);

            var logger = Substitute.For<ILogger<GetSalesQueryHandler>>();

            return new GetSalesQueryHandler(uow, mapper, logger);
        }
    }
}
