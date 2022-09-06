using AutoMapper;
using Exemplo.CRUD.Application.Queries.GetById;
using Exemplo.CRUD.Application.ViewModels;
using Exemplo.CRUD.Core.Entities;
using Exemplo.CRUD.Core.Repositories;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Exemplo.CRUD.Tests.Mocks
{
    public static class GetByIdMock
    {
        public static GetByIdHandler GenerateValidHandler(Product product, ProductViewModel productViewModel, GetById request)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            var logger = Substitute.For<ILogger<GetByIdHandler>>();

            return new GetByIdHandler(repository, mapper, logger);
        }

        public static ProductViewModel GenerateViewModelFromEntity(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category.Name,
            CreatedAt = product.CreatedAt,
            Price = product.Price
        };
    }
}
