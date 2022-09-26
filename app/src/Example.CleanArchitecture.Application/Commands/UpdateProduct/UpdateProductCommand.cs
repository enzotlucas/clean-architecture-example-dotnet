namespace Example.CleanArchitecture.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public Category? Category { get; set; }
        public bool? Enabled { get; set; }

        public UpdateProductCommand(Guid id, ProductViewModel productViewModel)
        {
            Id = id;
            Name = productViewModel.Name;
            Price = productViewModel.Price;
            Cost = productViewModel.Cost;
            Quantity = productViewModel.Quantity;
            Category = productViewModel.Category;
            Enabled = productViewModel.Enabled;
        }
    }
}
