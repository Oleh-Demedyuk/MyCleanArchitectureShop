using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICartRepository
{
    int InsertCart(Cart cart);

    Cart? GetCart(int cartId);

    bool UpdateCart(Cart cart);

    int DeleteCard(int id);
}