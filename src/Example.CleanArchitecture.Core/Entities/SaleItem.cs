namespace Example.CleanArchitecture.Core.Entities
{
    public class SaleItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        //EF
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public Sale Sale { get; set; }
        public Guid SaleId { get; set; }

        public SaleItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
            ProductId = product.Id;

            Validate();

            TotalPrice = quantity * Product.Price;
        }
        public SaleItem() => Id = Guid.Empty;

        private void Validate()
        {
            if (!Product.IsValid)
                throw new InvalidProductException();

            if (Quantity > Product.Quantity || Quantity < 1)
                throw new InvalidQuantityException("The quantity is higher than stock");
        }
    }
}
