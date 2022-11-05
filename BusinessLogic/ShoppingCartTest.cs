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
            Action add = () => cart.Add(null, 5);

            add.Should().ThrowExactly<MissingProduct>().WithMessage("Must have a product.");
        }

        [Fact]
        public void Given_Zero_Quantity_When_Call_Add_Then_Throw_ZeroQuantity_Exception()
        {
            var cart = new ShoppingCart();
            var product = new Product();
            Action add = () => cart.Add(product, 0);

            add.Should().ThrowExactly<ZeroQuantity>().WithMessage("Quantity can not be zero.");
        }

        [Fact]
        public void Given_Quantity_Is_Negative_1_When_Call_Add_Then_Throw_NegativeQuantity_Exception()
        {
            var cart = new ShoppingCart();
            var product = new Product();
            Action add = () => cart.Add(product, -1);

            add.Should().ThrowExactly<NegativeQuantity>().WithMessage("-1 is an invalid quantity.");
        }

        [Fact]
        public void Given_Quantity_Is_Negative_3_When_Call_Add_Then_Throw_NegativeQuantity_Exception()
        {
            var cart = new ShoppingCart();
            var product = new Product();
            Action add = () => cart.Add(product, -3);

            add.Should().ThrowExactly<NegativeQuantity>().WithMessage("-3 is an invalid quantity.");
        }
    }

    public class Product
    {

    }

    public class ShoppingCart
    {
        public IEnumerable<object> Items { get; } = Enumerable.Empty<object>();
        public int TotalAmount { get; } = 0;

        public void Add(Product product, int quantity)
        {
            if(product is null)
                throw new MissingProduct();

            if (quantity is 0)
                throw new ZeroQuantity();

            throw new NegativeQuantity(quantity);
        }
    }

    public class MissingProduct : Exception
    {
        public MissingProduct()
            : base("Must have a product.")
        {
        }
    }

    public class ZeroQuantity : Exception
    {
        public ZeroQuantity()
            : base("Quantity can not be zero.")
        {
        }
    }

    public class NegativeQuantity : Exception
    {
        public NegativeQuantity(int invalidQuantity)
            : base($"{invalidQuantity} is an invalid quantity.")
        {
        }
    }
}