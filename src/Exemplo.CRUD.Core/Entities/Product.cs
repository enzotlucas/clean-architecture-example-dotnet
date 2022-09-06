namespace Exemplo.CRUD.Core.Entities
{
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Valid => !string.IsNullOrWhiteSpace(Name);
        public bool Exists => Id != Guid.Empty;

        public Product(string name, decimal price, string categoryName)
        {
            Name = name;
            Price = price;
            Category = new Category(categoryName);
            CreatedAt = DateTime.Now;
        }

        public Product()
        {
            Id = Guid.Empty;
        }
    }
}
