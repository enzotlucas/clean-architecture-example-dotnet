namespace Exemplo.CRUD.Application.Commands.DeleteProduct
{
    public class DeleteProduct : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteProduct(Guid id) => Id = id;
    }
}
