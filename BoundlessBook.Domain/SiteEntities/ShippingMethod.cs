using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.SiteEntities;

public class ShippingMethod : BaseEntity
{
    public ShippingMethod(int cost, string title)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }

    public void Edit(int cost, string title)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        Cost = cost;
        Title = title;
    }
    public string Title { get; private set; }
    public int Cost { get; private set; }
}