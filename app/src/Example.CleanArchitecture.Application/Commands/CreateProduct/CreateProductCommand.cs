namespace Example.CleanArchitecture.Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductViewModel>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }

        public CreateProductCommand(ProductViewModel productViewModel)
        {
            Name = productViewModel.Name;
            Price = productViewModel.Price;
            Cost = productViewModel.Cost;
            Category = productViewModel.Category;
        }
    }
}
