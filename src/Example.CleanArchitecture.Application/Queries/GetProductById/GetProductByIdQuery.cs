namespace Example.CleanArchitecture.Application.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public Guid Id { get; set; }
    }
}
