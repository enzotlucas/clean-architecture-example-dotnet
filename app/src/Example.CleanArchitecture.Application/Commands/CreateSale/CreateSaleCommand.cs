namespace Example.CleanArchitecture.Application.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<SaleViewModel>
    {
        public IEnumerable<SaleItemViewModel> Items { get; set; }

        public CreateSaleCommand(SaleViewModel sale) => Items = sale.Items;
    }
}
