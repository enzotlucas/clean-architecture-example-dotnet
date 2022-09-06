namespace Exemplo.CRUD.Application.Commands.CreateProduct
{
    public class CreateProduct : IRequest<ProductViewModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product ToEntity() => new Product(Name, Price, Category); 
    }
}
