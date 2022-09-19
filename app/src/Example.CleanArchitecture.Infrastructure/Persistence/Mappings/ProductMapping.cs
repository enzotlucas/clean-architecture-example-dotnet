namespace Example.CleanArchitecture.Infrastructure.Persistence.Mappings
{
    public sealed class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                 .IsRequired()
                 .HasMaxLength(200);

            builder.Property(p => p.Category)
                   .HasConversion<string>()
                    .HasMaxLength(50);
        }
    }
}
