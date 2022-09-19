namespace Example.CleanArchitecture.Infrastructure.Persistence.Mappings
{
    public sealed class SaleItemMapping : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.HasKey(si => si.Id);

            builder.HasOne(si => si.Product)
                   .WithMany(p => p.SaleItems)
                   .HasForeignKey(si => si.ProductId);

            builder.HasOne(si => si.Sale)
                  .WithMany(s => s.Items)
                  .HasForeignKey(si => si.SaleId);
        }
    }
}
