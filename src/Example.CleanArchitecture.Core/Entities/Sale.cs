namespace Example.CleanArchitecture.Core.Entities
{
    public sealed class Sale
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public IEnumerable<SaleItem> Items { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Sale(IEnumerable<SaleItem> items, IValidator<Sale> validator)
        {
            Items = items;

            TotalPrice = items.Sum(i => i.TotalPrice);

            Validate(validator);
        }

        private void Validate(IValidator<Sale> validator)
        {
            var validationResult = validator.Validate(this);

            if (validationResult.IsValid)
                return;

            throw new InvalidSaleException(validationResult.ToDictionary());
        }
    }
}
