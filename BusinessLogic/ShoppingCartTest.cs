using FluentAssertions;
using Xunit;

namespace BusinessLogic
{
    public class ShoppingCartTest
    {
        [Fact]
        public void Can_Create_ShoppingCart()
        {
            var cart = new ShoppingCart();
        }

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
        public void Can_Add_Item_To_ShoppingCart()
        {
            var cart = new ShoppingCart();

            cart.AddItem();
        }
    }

    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int TotalAmount { get; } = 0;
    }
}