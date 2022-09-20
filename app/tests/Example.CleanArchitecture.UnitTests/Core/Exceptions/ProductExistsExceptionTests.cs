using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.CleanArchitecture.UnitTests.Core.Exceptions
{
    public class ProductExistsExceptionTests
    {
        [Trait("ProductExistsException", "Core")]
        [Fact(DisplayName = "Throw exception with default message")]
        public void Constructor_DefaultMessage_ShouldThrow()
        {
            //Arrange & Act
            var act = () => { throw new ProductExistsException(); };

            //Assert
            act.Should().ThrowExactly<ProductExistsException>()
                        .WithMessage("Product already exists");
        }

        [Trait("ProductExistsException", "Core")]
        [Fact(DisplayName = "Throw exception with custom message")]
        public void Constructor_CustomMessage_ShouldThrow()
        {
            //Arrange
            var message = "Product already exists custom";

            //Act
            var act = () => { throw new ProductExistsException(message); };

            //Assert
            act.Should().ThrowExactly<ProductExistsException>()
                        .WithMessage(message);
        }
    }
}
