using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class ProductNotFoundExceptionTests
    {
        [Trait("ProductNotFoundException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new ProductNotFoundException(); };

            //Assert
            act.Should().Throw<ProductNotFoundException>()
                        .WithMessage("Product not found");
        }

        [Trait("ProductNotFoundException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Product not found custom";

            //Act
            var act = () => { throw new ProductNotFoundException(message); };

            //Assert
            act.Should().Throw<ProductNotFoundException>()
                        .WithMessage(message);
        }
    }
}
