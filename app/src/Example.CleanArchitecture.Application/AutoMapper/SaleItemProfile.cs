namespace Example.CleanArchitecture.Application.AutoMapper
{
    public class SaleItemProfile : Profile
    {
        public SaleItemProfile()
        {
            CreateMap<SaleItem, SaleItemViewModel>();
        }
    }
}
