using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Events
{
    public class CartItemAddedEvent : BaseEvent
    {
        public CartItemAddedEvent(CartItem cartItem)
        {
            CartItem = cartItem;
        }

        public CartItem CartItem { get; }
    }
}
