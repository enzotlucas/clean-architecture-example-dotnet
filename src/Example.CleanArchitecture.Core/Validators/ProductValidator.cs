namespace Example.CleanArchitecture.Core.Validators
{
    public sealed class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Price)
               .GreaterThanOrEqualTo(0)
               .GreaterThanOrEqualTo(p => p.Price);

            RuleFor(p => p.Cost)
               .GreaterThanOrEqualTo(0)
               .LessThanOrEqualTo(p => p.Price);
        }
    }
}
