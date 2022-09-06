using AutoMapper;
using Exemplo.CRUD.Application.Commands.CreateProduct;
using Exemplo.CRUD.Application.ViewModels;
using Exemplo.CRUD.Core.Entities;
using Exemplo.CRUD.Core.Exceptions;
using Exemplo.CRUD.Core.Repositories;
using Exemplo.CRUD.Tests.Mocks;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Exemplo.CRUD.Tests.Application.Commands
{
    public class CreateProductTests
    {
        private CreateProductHandler _sut;

        //[Fact]
        //public void MethodName_Situation_Response()
        //{
        //    //AAA
        //    //Arrange
        //    //Mocka objetos, prepara variaveis para o teste
        //    //NSubstitute

        //    //Act
        //    //Testamos o que for necessario

        //    //Assert
        //    //Fluent Assertions
        //    //A gente compara o resultado e valida se foi o esperado
        //}

        [Trait("CreateProduct", "Application")]
        [Fact]
        public void Handle_ValidProduct_ShouldReturnCreated()
        {
            //Arrange
            var product = new Product("Valid Product", 2.5m, "Tests");
            var productViewModel = new ProductViewModel();
            var request = new CreateProduct { Name = "Valid Product", Price = 2.5m, Category = "Tests" };

            _sut = CreateProductMock.GenerateValidCreateProductHandler(product, productViewModel);

            //Act
            var response = _sut.Handle(request, CancellationToken.None);

            //Assert
            Assert.Equal(response.Result, productViewModel);
        }

        [Trait("CreateProduct", "Application")]
        [Fact]
        public async Task Handle_InvalidProductName_ShouldThrowBusinessException()
        {
            //Arrange
            var request = new CreateProduct { Name = "", Price = 2.5m, Category = "Tests" };
            _sut = CreateProductMock.GenerateInvalidCreateProductHandler();

            //Act
            Task Act() => _sut.Handle(request, CancellationToken.None);

            //Assert
            await Assert.ThrowsAsync<BusinessException>(() => Act());
        }
    }
}
