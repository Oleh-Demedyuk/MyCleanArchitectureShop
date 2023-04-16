using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public IList<CartItem> Items { get; private set; } = new List<CartItem>();
}
