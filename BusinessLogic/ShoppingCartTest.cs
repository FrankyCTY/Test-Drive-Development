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

        [Fact]
        public void Given_3_Apples_When_Call_Add_Then_Have_3_Apples_In_Cart()
        {
            var cart = new ShoppingCart();
            var productName = "Apple";
            var quantity = 3;
            var apple = new Product(productName, 0.35m);

            cart.Add(apple, quantity);

            VerifyCart(cart, 1, 1.05m);
            VerifyCartItem(cart.Items.First(), productName, quantity);
        }

        [Fact]
        public void Given_5_Bananas_When_Call_Add_Then_Have_5_Bananas_In_Cart()
        {
            var cart = new ShoppingCart();
            var productName = "Banana";
            var quantity = 5;
            var apple = new Product(productName, 0.75m);

            cart.Add(apple, quantity);

            VerifyCart(cart, 1, 3.75m);
            VerifyCartItem(cart.Items.First(), productName, quantity);
        }

        private static void VerifyCart(ShoppingCart cart, int itemCount, decimal totalAmount)
        {
            cart.ItemsCount.Should().Be(itemCount);
            cart.TotalAmount.Should().Be(totalAmount);
        }

        private void VerifyCartItem(ShoppingCartItem item, string productName, int quantity)
        {
            item.ProductName.Should().Be(productName);
            item.Quantity.Should().Be(quantity);
        }
    }
}