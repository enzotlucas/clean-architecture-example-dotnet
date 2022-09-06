using AutoMapper;
using Exemplo.CRUD.Application.Commands.CreateProduct;
using Exemplo.CRUD.Application.ViewModels;
using Exemplo.CRUD.Core.Entities;
using Exemplo.CRUD.Core.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Exemplo.CRUD.Tests.Mocks
{
    public static class CreateProductMock
    {
        public static CreateProductHandler GenerateValidCreateProductHandler(Product product, ProductViewModel productViewModel)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.Create(Arg.Any<Product>()).Returns(Task.FromResult(product));
            repository.UnitOfWork.Commit().Returns(Task.FromResult(true));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            var logger = Substitute.For<ILogger<CreateProductHandler>>();

            return new CreateProductHandler(repository, mapper, logger);
        }

        public static CreateProductHandler GenerateInvalidCreateProductHandler()
        {
            var repository = Substitute.For<IProductRepository>();
            var mapper = Substitute.For<IMapper>();
            var logger = Substitute.For<ILogger<CreateProductHandler>>();
            return new CreateProductHandler(repository, mapper, logger);
        }
    }
}
