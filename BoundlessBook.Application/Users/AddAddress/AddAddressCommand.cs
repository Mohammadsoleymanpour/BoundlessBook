using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Users.AddAddress;

public class AddAddressCommand:IBaseCommand
{
    public AddAddressCommand(Guid userId, string shire, string city, string postalCode, string postalAddress, string name, string phoneNumber, string family, string nationalCode)
    {
        UserId = userId;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        PhoneNumber = phoneNumber;
        Family = family;
        NationalCode = nationalCode;
    }
    public Guid UserId { get; set; }
    public string Shire { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PostalAddress { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
}