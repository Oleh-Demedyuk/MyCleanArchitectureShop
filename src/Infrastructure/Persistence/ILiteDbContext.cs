using LiteDB;

namespace Infrastructure.Persistence
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
