namespace Exemplo.CRUD.UnitTests.Application.Queries
{
    public class GetAllProductsTests
    {
        [Trait("Application_GetAllProducts", "UnitTests")]
        [Fact(DisplayName = "Existent products, should return a list of products.")]
        public async Task Handle_ExistentProducts_ShouldReturnValidProductLists()
        {
            //Arrange
            var quantity = 15;
            var productViewModels = ProductViewModelFixtures.GenerateList(quantity);
            var request = new GetAllProducts();

            var repository = Substitute.For<IProductRepository>();
            repository.GetAll().Returns(Task.FromResult(ProductFixtures.GenerateList(quantity)));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<IEnumerable<ProductViewModel>>(Arg.Any<IEnumerable<Product>>()).Returns(productViewModels);

            var sut =  new GetAllProductsHandler(repository, mapper);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeEmpty();
            response.Should().NotBeNull();
            response.Should().BeSameAs(productViewModels);
            response.Should().BeAssignableTo<IEnumerable<ProductViewModel>>();
            response.Should().NotBeAssignableTo<IEnumerable<Product>>();
        }

        [Trait("Application_GetAllProducts", "UnitTests")]
        [Fact(DisplayName = "Unexistent products, should return an empty list of products.")]
        public async Task Handle_UnexistentProducts_ShouldReturnEmptyList()
        {
            //Arrange
            var productViewModels = new List<ProductViewModel>();
            var request = new GetAllProducts();

            var repository = Substitute.For<IProductRepository>();
            repository.GetAll().Returns(new List<Product>());

            var mapper = Substitute.For<IMapper>();
            mapper.Map<IEnumerable<ProductViewModel>>(Arg.Any<IEnumerable<Product>>()).Returns(productViewModels);

            var sut = new GetAllProductsHandler(repository, mapper);

            //Act
            var response = await sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().BeEmpty();
            response.Should().NotBeNull();
            response.Should().BeSameAs(productViewModels);
            response.Should().BeAssignableTo<IEnumerable<ProductViewModel>>();
            response.Should().NotBeAssignableTo<IEnumerable<Product>>();
        }
    }
}
