using BoundlessBook.Common;

namespace BoundlessBook.Domain.OrderAggregate;

public class OrderAddress : BaseEntity
{
    public OrderAddress(string shire, string city, string postalCode, string postalAddress,
        string name, string family, string nationalCode)
    {
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        NationalCode = nationalCode;

    }
    public Guid OrderId { get; set; }
    public string Shire { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PostalAddress { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }

    #region Relations

    public Order Order { get; set; }

    #endregion
}