namespace Example.CleanArchitecture.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public bool Enabled { get; set; }
    }
}
