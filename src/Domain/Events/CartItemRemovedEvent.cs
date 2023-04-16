using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Events
{
    public class CartItemRemovedEvent : BaseEvent
    {
        public CartItemRemovedEvent(CartItem cartItem)
        {
            CartItem = cartItem;
        }
        
        public CartItem CartItem { get; }
    }
}
