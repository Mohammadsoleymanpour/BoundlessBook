using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.UserAggregate;

public class UserAddress : BaseEntity
{
    public UserAddress(string shire, string city, string postalCode, string postalAddress, string name, string family, string nationalCode)
    {
        Guard(shire, city, postalCode, postalAddress, name, family, nationalCode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        IsActive = false;
    }
    public Guid UserId { get; set; }
    public string Shire { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string PostalAddress { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public bool IsActive { get; set; }
    public void SetActive()
    {
        IsActive = true;
    }
    public void Edit(string shire, string city, string postalCode, string postalAddress, string name, string family,
        string nationalCode)
    {
        Guard(shire, city, postalCode, postalAddress, name, family,nationalCode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }

    public void Guard(string shire, string city, string postalCode, string postalAddress, string name, string family,
        string nationalCode)
    {
        NullOrEmptyDomainException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainException.CheckString(city, nameof(city));
        NullOrEmptyDomainException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainException.CheckString(name, nameof(name));
        NullOrEmptyDomainException.CheckString(family, nameof(family));
        NullOrEmptyDomainException.CheckString(nationalCode, nameof(nationalCode));

        if (!IranianNationalCodeChecker.IsValid(nationalCode))
        {
            throw new InvalidDomainException("کد ملی معتبر نمیباشد");
        }


    }
}