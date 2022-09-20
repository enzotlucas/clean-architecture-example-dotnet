namespace Example.CleanArchitecture.Application.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        public int Page { get; set; }
        public int Rows { get; set; }

        public GetProductsQuery(int page, int rows)
        {
            Page = page;
            Rows = rows;
        }
    }
}
