using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCartItem
    {
        public Product Product { get; }
        public int Quantity { get; } = 0;
        public string ProductName => Product.Name;
        public decimal UnitPrice => Product.UnitPrice;
        public decimal Subtotal => UnitPrice * Quantity; 

        public ShoppingCartItem(Product product, int quantity)
        {
            if (product is null)
                throw new MissingProduct();

            if (quantity <= 0)
                throw new InvalidQuantity(quantity);

            Product = product;
            Quantity = quantity;
        }
    }
}
