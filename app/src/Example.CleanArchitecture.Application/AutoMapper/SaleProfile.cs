namespace Example.CleanArchitecture.Application.AutoMapper
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleViewModel>();
        }
    }
}
