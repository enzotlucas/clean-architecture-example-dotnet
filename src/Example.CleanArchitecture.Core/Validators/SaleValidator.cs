namespace Example.CleanArchitecture.Core.Validators
{
    public sealed class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(s => s.Items).NotEmpty()
                                 .NotNull();

            RuleFor(s => s.Items.Where(i => i.TotalPrice < 1)
                                .Any()
                    ).Equal(false);
        }
    }
}
