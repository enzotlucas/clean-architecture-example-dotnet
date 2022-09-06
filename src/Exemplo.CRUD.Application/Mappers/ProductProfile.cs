namespace Exemplo.CRUD.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(p => p.Category,
                    map => map.MapFrom(src => src.Category.Name));
        }
    }
}
