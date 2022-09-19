namespace Example.CleanArchitecture.Infrastructure.Persistence.Mappings
{
    public sealed class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
