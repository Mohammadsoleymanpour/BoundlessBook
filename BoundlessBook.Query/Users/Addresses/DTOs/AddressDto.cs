using BoundlessBook.Common.Common.Query;

namespace BoundlessBook.Query.Users.Addresses.DTOs;

public class AddressDto:BaseDto
{
    public Guid UserId { get; set; }
    public string Shire { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PostalAddress { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsActive { get; set; }
}