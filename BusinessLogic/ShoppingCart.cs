using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; } = new List<ShoppingCartItem>();
        public decimal TotalAmount => Items.Any() ? 1.05m : 0;
        public int ItemsCount => Items.Count;

        public void Add(Product product, int quantity)
        {
            if (product is null)
                throw new MissingProduct();

            if (quantity <= 0)
                throw new InvalidQuantity(quantity);

            var NewItem = new ShoppingCartItem(product, quantity);
            Items.Add(NewItem);
        }
    }

}
