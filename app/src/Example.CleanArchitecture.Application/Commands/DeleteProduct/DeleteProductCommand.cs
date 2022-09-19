namespace Example.CleanArchitecture.Application.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest    
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id) => Id = id;
    }
}
