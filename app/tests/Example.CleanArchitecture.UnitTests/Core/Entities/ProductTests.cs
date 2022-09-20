namespace Example.CleanArchitecture.UnitTests.Core.Entities
{
    [Collection(nameof(CoreFixtureCollection))]
    public sealed class ProductTests
    {
        private readonly CoreFixture _fixture;

        public ProductTests(CoreFixture fixture) => _fixture = fixture;

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Initialize a valid product")]
        public void Constructor_ValidInformations_ShouldReturnProduct()
        {
            //Arrange
            var name = "Product Name";
            var price = (decimal)new Random().Next(50, 100);
            var cost = (decimal)new Random().Next(10, 50);
            var quantity = new Random().Next(1, 100);
            var category = Category.TECH;
            var validator = new ProductValidator();

            //Act
            var product = new Product(name, price, cost, quantity, category, validator);

            //Assert
            product.Should().NotBeNull();
            product.Id.Should().NotBe(Guid.Empty);
            product.Name.Should().Be(name);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Quantity.Should().Be(quantity);
            product.Category.Should().Be(category);
            product.Enabled.Should().Be(true);
            product.IsValid.Should().Be(true);
            product.CreatedAt.Should().NotBe(DateTime.MinValue);
            product.UpdatedAt.Should().NotBe(DateTime.MinValue);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Initialize a product with invalid name, should throw exception")]
        public void Constructor_InvalidName_ShouldThrow()
        {
            //Arrange
            var firstName = string.Empty;
            string secondName = null;
            var price = (decimal)new Random().Next(50, 100);
            var cost = (decimal)new Random().Next(10, 50);
            var quantity = new Random().Next(1, 100);
            var category = Category.TECH;
            var validator = new ProductValidator();

            //Act
            var firstAct = () =>
            {
                _ = new Product(firstName, price, cost, quantity, category, validator);
            };
            var secondtAct = () =>
            {
                _ = new Product(secondName, price, cost, quantity, category, validator);
            };

            //Assert
            firstAct.Should().ThrowExactly<InvalidProductException>()
                .WithMessage("Invalid product");

            secondtAct.Should().ThrowExactly<InvalidProductException>()
                .WithMessage("Invalid product");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Initialize a product with invalid price, should throw exception")]
        public void Constructor_InvalidPrice_ShouldThrow()
        {
            //Arrange
            var name = "Product name";
            var firstPrice = (decimal)new Random().Next(1, 9);
            var secondPrice = (decimal)0.0;
            var cost = (decimal)new Random().Next(10, 50);
            var quantity = new Random().Next(1, 100);
            var category = Category.TECH;
            var validator = new ProductValidator();

            //Act
            var firstAct = () =>
            {
                _ = new Product(name, firstPrice, cost, quantity, category, validator);
            };
            var secondtAct = () =>
            {
                _ = new Product(name, secondPrice, cost, quantity, category, validator);
            };

            //Assert
            firstAct.Should().ThrowExactly<InvalidProductException>()
                .WithMessage("Invalid product");

            secondtAct.Should().ThrowExactly<InvalidProductException>()
                .WithMessage("Invalid product");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Initialize a product with invalid cost, should throw exception")]
        public void Constructor_InvalidCost_ShouldThrow()
        {
            //Arrange
            var name = "Product name";
            var price = (decimal)new Random().Next(50, 100);
            var cost = (decimal)new Random().Next(101, 150);
            var quantity = new Random().Next(1, 100);
            var category = Category.TECH;
            var validator = new ProductValidator();

            //Act
            var act = () =>
            {
                _ = new Product(name, price, cost, quantity, category, validator);
            };

            //Assert
            act.Should().ThrowExactly<InvalidProductException>()
                .WithMessage("Invalid product");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Initialize a product with invalid quantity, should throw exception")]
        public void Constructor_InvalidQuantity_ShouldThrow()
        {
            //Arrange
            var name = "Product name";
            var price = (decimal)new Random().Next(50, 100);
            var cost = (decimal)new Random().Next(10, 50);
            var quantity = -1;
            var category = Category.TECH;
            var validator = new ProductValidator();

            //Act
            var act = () =>
            {
                _ = new Product(name, price, cost, quantity, category, validator);
            };

            //Assert
            act.Should().ThrowExactly<InvalidProductException>()
                        .WithMessage("Invalid product");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid information")]
        public void Update_ValidInformation_ShouldUpdateSucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = "New Product name";
            var quantity = 14;
            var price = (decimal)new Random().Next(200, 250);
            var cost = (decimal)new Random().Next(0, 9);
            var enabled = false;
            var category = Category.DRINK;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid name")]
        public void Update_ValidName_ShouldUpdateNameSucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = "New Product name";
            var quantity = product.Quantity;
            var price = product.Price;
            var cost = product.Cost;
            var enabled = product.Enabled;
            var category = product.Category;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid quantity")]
        public void Update_ValidQuantity_ShouldUpdateQuantitySucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = product.Name;
            var quantity = 14;
            var price = product.Price;
            var cost = product.Cost;
            var enabled = product.Enabled;
            var category = product.Category;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid price")]
        public void Update_ValidPrice_ShouldUpdatePriceSucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = product.Name;
            var quantity = product.Quantity;
            var price = (decimal)new Random().Next(200, 250);
            var cost = product.Cost;
            var enabled = product.Enabled;
            var category = product.Category;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid cost")]
        public void Update_ValidCost_ShouldUpdateCostSucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = product.Name;
            var quantity = product.Quantity;
            var price = product.Price;
            var cost = (decimal)new Random().Next(0, 9);
            var enabled = product.Enabled;
            var category = product.Category;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid enabled")]
        public void Update_ValidEnabled_ShouldUpdateEnabledSucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = product.Name;
            var quantity = product.Quantity;
            var price = product.Price;
            var cost = product.Cost;
            var enabled = false;
            var category = product.Category;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with valid category")]
        public void Update_ValidCategory_ShouldUpdateCategorySucessfully()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = product.Name;
            var quantity = product.Quantity;
            var price = product.Price;
            var cost = product.Cost;
            var enabled = product.Enabled;
            var category = Category.DRINK;

            //Act
            product.Update(name: name,
                           quantity: quantity,
                           price: price,
                           cost: cost,
                           enabled: enabled,
                           category: category);

            //Assert
            product.Name.Should().Be(name);
            product.Quantity.Should().Be(quantity);
            product.Price.Should().Be(price);
            product.Cost.Should().Be(cost);
            product.Enabled.Should().Be(enabled);
            product.IsValid.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with invalid name, should throw")]
        public void Update_InvalidName_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var name = string.Empty;

            //Act
            var act = () => product.Update(name: name,
                                           quantity: null,
                                           price: null,
                                           cost: null,
                                           enabled: null,
                                           category: null);

            //Assert
            act.Should().Throw<InvalidNameException>()
                .WithMessage("Invalid name");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with invalid quantity, should throw")]
        public void Update_InvalidQuantity_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var quantity = -1;

            //Act
            var act = () => product.Update(name: null,
                                           quantity: quantity,
                                           price: null,
                                           cost: null,
                                           enabled: null,
                                           category: null);

            //Assert
            act.Should().ThrowExactly<InvalidQuantityException>()
                .WithMessage("Invalid quantity");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with invalid price, should throw")]
        public void Update_InvalidPrice_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var firstPrice = product.Cost - new Random().Next(1, 9);
            var secondPrice = -1;


            //Act
            var firstAct = () => product.Update(name: null,
                                                  quantity: null,
                                                  price: firstPrice,
                                                  cost: null,
                                                  enabled: null,
                                                  category: null);

            var secondAct = () => product.Update(name: null,
                                                  quantity: null,
                                                  price: secondPrice,
                                                  cost: null,
                                                  enabled: null, 
                                                  category: null);

            //Assert
            firstAct.Should().ThrowExactly<InvalidPriceException>()
                .WithMessage("Invalid price");

            secondAct.Should().ThrowExactly<InvalidPriceException>()
                .WithMessage("Invalid price");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Update a product with invalid cost, should throw")]
        public void Update_InvalidCost_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var firstCost = product.Price + new Random().Next(0, 9);
            var secondCost = -1;

            //Act
            var firstAct = () => product.Update(name: null,
                                                  quantity: null,
                                                  price: null,
                                                  cost: firstCost,
                                                  enabled: null,
                                                  category: null);

            var secondAct = () => product.Update(name: null,
                                                  quantity: null,
                                                  price: null,
                                                  cost: secondCost,
                                                  enabled: null, 
                                                  category: null);

            //Assert
            firstAct.Should().ThrowExactly<InvalidCostException>()
                .WithMessage("Invalid cost");

            secondAct.Should().ThrowExactly<InvalidCostException>()
                .WithMessage("Invalid cost");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Disable a product")]
        public void Disable_ValidProduct_ShouldDisableProduct()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();

            //Act
            product.Disable();

            //Assert
            product.Enabled.Should().Be(false);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Enable a product")]
        public void Enable_ValidProduct_ShouldEnableProduct()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();

            //Act
            product.Enable();

            //Assert
            product.Enabled.Should().Be(true);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Add stock with valid quantity")]
        public void AddStock_ValidQuantity_ShouldAddQuantity()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var quantity = product.Quantity;

            //Act
            product.AddStock(5);

            //Assert
            product.Quantity.Should().Be(quantity + 5);
            product.Quantity.Should().NotBe(quantity);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Add stock with invalid quantity, should throw")]
        public void AddStock_InvalidQuantity_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();

            //Act
            var act = () => product.AddStock(0);

            //Assert
            act.Should().ThrowExactly<InvalidQuantityException>()
                        .WithMessage("Invalid quantity");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Withdraw from stock with valid quantity")]
        public void WithdrawFromStock_ValidQuantity_ShouldAddQuantity()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var quantity = product.Quantity;

            //Act
            product.WithdrawFromStock(2);

            //Assert
            product.Quantity.Should().Be(quantity - 2);
            product.Quantity.Should().NotBe(quantity);
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Withdraw from stock with invalid quantity, should throw")]
        public void WithdrawFromStock_InvalidQuantity_ShouldThrow()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var quantity = product.Quantity;

            //Act
            var firstAct = () => product.WithdrawFromStock(quantity + 1);

            var secondAct = () => product.WithdrawFromStock(0);

            //Assert
            firstAct.Should().ThrowExactly<InvalidQuantityException>()
                        .WithMessage("Invalid quantity");

            secondAct.Should().ThrowExactly<InvalidQuantityException>()
                        .WithMessage("Invalid quantity");
        }

        [Trait("Product", "Core")]
        [Fact(DisplayName = "Withdraw from stock with invalid quantity, should throw")]
        public void ToString_ShouldReturnValidString()
        {
            //Arrange
            var product = _fixture.Product.GenerateValid();
            var expected = $"Id:{product.Id};" +
                           $"Name:{product.Name};" +
                           $"Quantity:{product.Quantity};" +
                           $"Price:{product.Price};" +
                           $"Cost:{product.Cost};" +
                           $"Category:{product.Category};" +
                           $"Enabled:{product.Enabled};" +
                           $"CreatedAt:{product.CreatedAt};" +
                           $"UpdatedAt:{product.UpdatedAt}";

            //Act
            var response = product.ToString();

            //Assert
            response.Should().Be(expected);
        }
    }
}
