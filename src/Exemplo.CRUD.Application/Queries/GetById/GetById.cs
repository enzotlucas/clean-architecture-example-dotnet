namespace Exemplo.CRUD.Application.Queries.GetById
{
    public record GetById(Guid Id) : IRequest<ProductViewModel>;
}
