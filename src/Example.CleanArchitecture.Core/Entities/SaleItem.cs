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

        public Guid SaleId { get; private set; }
        public Product Sale { get; private set; }

        protected SaleItem() { }

        public SaleItem(int quantity, decimal totalPrice, Guid productId, Guid saleId)
        {
            Quantity = quantity;
            TotalPrice = totalPrice;
            ProductId = productId;
            SaleId = saleId;
        }
    }
}
