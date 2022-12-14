namespace Example.CleanArchitecture.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public decimal Cost { get; private set; }
        public int Quantity { get; private set; }
        public Category Category { get; private set; }
        public bool Enabled { get; private set; }

        [NotMapped]
        public bool IsValid => Id != Guid.Empty;

        //EF
        public IEnumerable<SaleItem> SaleItems { get; set; }

        public Product(string name, 
                       decimal price, 
                       decimal cost, 
                       int quantity, 
                       Category category,
                       IValidator<Product> validator)
        {
            Name = name;
            Price = price;
            Cost = cost;
            Quantity = quantity;
            Category = category;
            Enabled = true;

            Validate(validator);
        }

        public Product() => Id = Guid.Empty;

        private void Validate(IValidator<Product> validator)
        {
            var validationResult = validator.Validate(this);

            if (validationResult.IsValid)
                return;

            throw new InvalidProductException(validationResult.ToDictionary());
        }

        public void Enable()
             => Enabled = true;

        public void Disable()
            => Enabled = false;

        public void WithdrawFromStock(int quantity)
        {
            if (quantity < 1 || Quantity - quantity < 0 || Quantity == 0)
                throw new InvalidQuantityException();

            Quantity -= quantity;
        }

        public void AddStock(int quantity)
        {
            if (quantity < 1)
                throw new InvalidQuantityException();

            Quantity += quantity;
        }

        public void Update(string name,
                           int? quantity,
                           decimal? price,
                           decimal? cost,
                           bool? enabled,
                           Category? category)
        {
            UpdateName(name);

            UpdateQuantity(quantity);

            UpdatePrice(price);

            UpdateCost(cost);

            UpdateEnable(enabled);

            UpdateCategory(category);

            UpdatedAt = DateTime.Now;
        }

        private void UpdateName(string name)
        {
            if (name is null || name.Equals(Name))
                return;

            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidNameException();

            Name = name;
        }

        private void UpdateQuantity(int? quantity)
        {
            if (quantity is null)
                return;

            if (quantity < 0)
                throw new InvalidQuantityException();

            Quantity = quantity.Value;
        }

        private void UpdatePrice(decimal? price)
        {
            if (price is null)
                return;

            if (price < 0 || price < Cost)
                throw new InvalidPriceException();

            Price = price.Value;
        }

        private void UpdateCost(decimal? cost)
        {
            if (cost is null)
                return;

            if (cost < 0 || cost > Price)
                throw new InvalidCostException();

            Cost = cost.Value;
        }

        private void UpdateEnable(bool? enable)
        {
            if (enable is null)
                return;

            if (enable.Value)
                Enable();
            else
                Disable();
        }

        private void UpdateCategory(Category? category)
        {
            if (category is null || category == Category)
                return;

            Category = category.Value;
        }

        public override string ToString()
        {
            return $"Id:{Id};" +
                   $"Name:{Name};" +
                   $"Quantity:{Quantity};" +
                   $"Price:{Price};" +
                   $"Cost:{Cost};" +
                   $"Category:{Category};" +
                   $"Enabled:{Enabled};" +
                   $"CreatedAt:{CreatedAt};" +
                   $"UpdatedAt:{UpdatedAt}";
        }
    }
}
