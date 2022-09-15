namespace Example.CleanArchitecture.Core.Validators
{
    public class SaleValidator : AbstractValidator<Sale>
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
