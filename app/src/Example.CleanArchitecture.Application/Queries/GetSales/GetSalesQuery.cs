namespace Example.CleanArchitecture.Application.Queries.GetSales
{
    public class GetSalesQuery : IRequest<IEnumerable<SaleViewModel>>
    {
        public int? Page { get; set; }
        public int? Rows { get; set; }

        public GetSalesQuery(int? page, int? rows)
        {
            Page = page;
            Rows = rows;
        }
    }
}
