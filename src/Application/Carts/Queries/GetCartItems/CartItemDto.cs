using AutoMapper;
using Application.Common.Mappings;
using Domain.ValueObjects;

namespace Application.Carts.Queries.GetCartItems
{
    public class CartItemDto : IMapFrom<CartItem>
    {
        public int ProductId { get; init; }

        public string? Name { get; init; }

        public Image? Image { get; init; }

        public decimal Price { get; init; }

        public uint Quantity { get; init; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CartItem, CartItemDto>();
        }
    }
}
