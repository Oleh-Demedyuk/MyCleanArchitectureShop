using Domain.Common;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class CartItem : ValueObject
    {
        private CartItem(int productId, string name, Image image, decimal price, uint quantity)
        {
            ProductId = productId;
            Name = name;
            Image = image;
            Price = price;
            Quantity = quantity;
        }

        public int ProductId { get; private set; }

        public string Name { get; private set; }

        public Image Image { get; private set; }

        public decimal Price { get; private set; }

        public uint Quantity { get; private set; }

        public static CartItem From(int productId, string name, Image image, decimal price, uint quantity)
        {

            var cartItem = new CartItem(productId, name, image, price, quantity);
            return cartItem;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ProductId;
            yield return Name;
            yield return Image;
            yield return Price;
            yield return Quantity;
        }
    }
}
