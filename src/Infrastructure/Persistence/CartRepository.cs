using Application.Common.Interfaces;
using Domain.Entities;
using LiteDB;

namespace Infrastructure.Persistence;

public class CartRepository: ICartRepository
{
    private readonly LiteDatabase _liteDb;
    private const string CollectionName = "Carts";

    public CartRepository(ILiteDbContext liteDbContext)
    {
        _liteDb = liteDbContext.Database;
    }

    public int InsertCart(Cart cart)
    {
        return _liteDb.GetCollection<Cart>(CollectionName)
            .Insert(cart);
    }

    public Cart? GetCart(int id)
    {
        return _liteDb.GetCollection<Cart>(CollectionName)
            .Find(x => x.Id == id).FirstOrDefault();
    }

    public bool UpdateCart(Cart cart)
    {
        return _liteDb.GetCollection<Cart>(CollectionName)
            .Update(cart);
    }

    public int DeleteCard(int id)
    {
        return _liteDb.GetCollection<Cart>(CollectionName)
            .DeleteMany(x => x.Id == id);
    }
}