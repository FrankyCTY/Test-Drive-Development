using FluentAssertions;
using Xunit;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCartTest
    {
        [Fact]
        public void When_Create_Cart_Then_Cart_Is_Empty()
        {
            var cart = new ShoppingCart();

            cart.Items.Should().BeEmpty();
        }

        [Fact]
        public void When_Create_Cart_Then_Total_Amount_Is_Zero()
        {
            var cart = new ShoppingCart();

            cart.TotalAmount.Should().Be(0);
        }

        [Fact]
        public void Given_No_Product_When_Call_Add_Then_Throw_MissingProduct_Exception()
        {
            var cart = new ShoppingCart();
            Action add = () => cart.Add(null, 5);

            add.Should().ThrowExactly<MissingProduct>().WithMessage("Must have a product.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3)]
        [InlineData(-20)]
        public void Given_Quantity_Is_Invalid_When_Call_Add_Then_Throw_NegativeQuantity_Exception(int quantity)
        {
            var cart = new ShoppingCart();
            var product = new Product("Apple", 0.35m);
            Action add = () => cart.Add(product, quantity);

            add.Should().ThrowExactly<InvalidQuantity>().WithMessage($"{quantity} is an invalid quantity.");
        }

        [Theory]
        [InlineData("Apple", 0.35, 3)]
        [InlineData("Banana", 0.75, 5)]
        [InlineData("Cantaloupe", 2.5, 11)]
        public void Given_Have_Quantity_Of_A_Product_When_Call_Add_Then_Have_Product_In_Cart(string productName, decimal unitPrice, int quantity)
        {
            var cart = new ShoppingCart();
            var product = new Product(productName, unitPrice);

            cart.Add(product, quantity);

            VerifyCart(cart, 1, unitPrice * quantity);
            VerifyCartItem(cart.Items.First(), productName, unitPrice,  quantity);
        }

        [Fact]
        public void Given_5_Bananas_When_Call_Add_Then_Have_5_Bananas_In_Cart()
        {
            var cart = new ShoppingCart();

            cart.Add(Banana, 5);

            VerifyCart(cart, 1, 3.75m);
            VerifyCartItem(cart.Items.First(), "Banana", 0.75m, 5);
        }

        [Fact]
        public void Given_Have_Two_Prroducts_When_Call_Add_Then_Have_Two_Products_In_Cart()
        {
            var cart = new ShoppingCart();

            cart.Add(Banana, 2);
            cart.Add(Apple, 3);

            VerifyCart(cart, 2, 2 * Banana.UnitPrice + 3 * Apple.UnitPrice);
            VerifyCartItem(cart.Items.First(), Banana, 2);
            VerifyCartItem(cart.Items[1], Apple, 3);
        }

        [Fact]
        public void Given_Have_Three_Prroducts_When_Call_Add_Then_Have_Three_Products_In_Cart()
        {
            var cart = new ShoppingCart();

            cart.Add(Apple, 3);
            cart.Add(Banana, 2);
            cart.Add(Cantaloupe, 5);

            VerifyCart(cart, 3, 3 * Apple.UnitPrice + 2 * Banana.UnitPrice + 5 * Cantaloupe.UnitPrice);
            VerifyCartItem(cart.Items.First(), Apple, 3);
            VerifyCartItem(cart.Items[1], Banana, 2);
            VerifyCartItem(cart.Items[2], Cantaloupe, 5);
        }

        private readonly static Product Apple = new Product("Apple", 0.35m);
        private readonly static Product Banana = new Product("Banana", 0.75m);
        private readonly static Product Cantaloupe = new Product("Cantaloupe", 2.5m);

        private static void VerifyCart(ShoppingCart cart, int itemCount, decimal totalAmount)
        {
            cart.ItemsCount.Should().Be(itemCount);
            cart.TotalAmount.Should().Be(totalAmount);
        }

        private void VerifyCartItem(ShoppingCartItem item, string productName, decimal unitPrice, int quantity)
        {
            item.ProductName.Should().Be(productName);
            item.UnitPrice.Should().Be(unitPrice);
            item.Quantity.Should().Be(quantity);
        }

        private void VerifyCartItem(ShoppingCartItem item, Product product, int quantity)
        {
            item.Product.Should().BeEquivalentTo(product);
            item.Quantity.Should().Be(quantity);
        }
    }
}