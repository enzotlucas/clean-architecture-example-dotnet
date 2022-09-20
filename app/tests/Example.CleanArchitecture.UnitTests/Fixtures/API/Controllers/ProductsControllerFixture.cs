using Example.CleanArchitecture.Application.Commands.UpdateProduct;

namespace Example.CleanArchitecture.UnitTests.Fixtures.API.Controllers
{
    public class ProductsControllerFixture
    {
        public ProductsController GenerateValid(ProductViewModel productViewModel = null)
        {
            var mediator = Substitute.For<IMediator>();

            mediator.Send(Arg.Any<GetProductByIdQuery>()).Returns(Task.FromResult(productViewModel));

            mediator.Send(Arg.Any<CreateProductCommand>()).Returns(Task.FromResult(productViewModel));

            return new ProductsController(mediator);
        }

        public ProductsController GenerateValid(IEnumerable<ProductViewModel> productViewModel)
        {
            var mediator = Substitute.For<IMediator>();

            mediator.Send(Arg.Any<GetProductsQuery>()).Returns(Task.FromResult(productViewModel));

            return new ProductsController(mediator);
        }

        public ProductsController GeneratInvalid(bool invalidProduct)
        {
            var mediator = Substitute.For<IMediator>();

            mediator.Send(Arg.Any<CreateProductCommand>()).ThrowsAsync(new ProductExistsException());

            mediator.Send(Arg.Any<DeleteProductCommand>()).ThrowsAsync(new ProductNotFoundException());

            mediator.Send(Arg.Any<GetProductByIdQuery>()).ThrowsAsync(new ProductNotFoundException());

            mediator.Send(Arg.Any<UpdateProductCommand>()).ThrowsAsync(new ProductNotFoundException());

            if (invalidProduct)
            {
                mediator.Send(Arg.Any<CreateProductCommand>()).ThrowsAsync(new InvalidProductException());
                mediator.Send(Arg.Any<UpdateProductCommand>()).ThrowsAsync(new InvalidProductException());
            }

            return new ProductsController(mediator);
        }
    }
}
