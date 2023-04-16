namespace Application.Carts.Queries.GetCartItems
{
    public class CartItemsVm
    {
        public IReadOnlyCollection<CartItemDto> Items { get; init; } = Array.Empty<CartItemDto>();
    }
}
