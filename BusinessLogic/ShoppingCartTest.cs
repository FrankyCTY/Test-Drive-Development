using FluentAssertions;
using Xunit;

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

            Action add = () => cart.Add(null);
            add.Should().ThrowExactly<MissingProduct>();
        }
    }

    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int TotalAmount { get; } = 0;

        public void Add(object product)
        {
            if (product is null)
                throw new MissingProduct();
        }
    }

    public class MissingProduct : Exception
    { }
}