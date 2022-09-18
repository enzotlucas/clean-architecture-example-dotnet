namespace Example.CleanArchitecture.Application.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ConstructUsing(p => new Product(p.Name,
                                                 p.Price,
                                                 p.Cost,
                                                 p.Quantity,
                                                 p.Category,
                                                 new ProductValidator()));

            CreateMap<Product, ProductViewModel>();
        }
    }
}
