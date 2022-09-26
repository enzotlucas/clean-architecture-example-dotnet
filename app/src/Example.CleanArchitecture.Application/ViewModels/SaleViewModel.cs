namespace Example.CleanArchitecture.Application.ViewModels
{
    public class SaleViewModel
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<SaleItemViewModel> Items { get; set; }
    }
}
