using AutoMapper;
using Exemplo.CRUD.Application.Queries.GetById;
using Exemplo.CRUD.Application.ViewModels;
using Exemplo.CRUD.Core.Entities;
using Exemplo.CRUD.Core.Exceptions;
using Exemplo.CRUD.Core.Repositories;
using Exemplo.CRUD.Tests.Mocks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Exemplo.CRUD.Tests.Application.Queries
{
    public class GetByIdTests
    {
        private GetByIdHandler _sut;

        [Trait("GetById", "Application")]
        [Fact(DisplayName = "Existent id, should return valid product.")]
        public async Task Handle_ExistentId_ShouldReturnValidProduct()
        {
            //Arrange
            var product = new Product("Product Test", 2.5m, "Category");
            var productViewModel = GetByIdMock.GenerateViewModelFromEntity(product);
            var request = new GetById(product.Id);

            _sut = GetByIdMock.GenerateValidHandler(product, productViewModel, request);

            //Act
            var response = await _sut.Handle(request, CancellationToken.None);

            //Assert
            response.Should().Be(productViewModel);
            response.Should().BeAssignableTo<ProductViewModel>();
            response.Should().NotBeAssignableTo<Product>();
            response.Should().NotBeNull();
        }

        [Trait("GetById", "Application")]
        [Fact]
        public async Task Handle_UnexistentId_ShouldThrowBusinessException()
        {
            //Arrange
            var product = new Product();
            var request = new GetById(Guid.NewGuid());

            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));
            var mapper = Substitute.For<IMapper>();
            var logger = Substitute.For<ILogger<GetByIdHandler>>();

            _sut = new GetByIdHandler(repository, mapper, logger);

            //Act
            Func<Task> act = async () => { await _sut.Handle(request, CancellationToken.None); };

            //Assert
            await act.Should().ThrowAsync<ProductNotFoundException>()
                     .WithMessage($"Product {request.Id} not found");
        }
    }
}
