using System.Security.AccessControl;
using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Domain.UserAggregate.Enums;
using BoundlessBook.Domain.UserAggregate.Services;


namespace BoundlessBook.Domain.UserAggregate;

public class User : AggregateRoot
{
    public User(string name, string family, string phoneNumber, string email, string password, Gender gender,IUserDomainService userDomainService)
    {
        Guard(phoneNumber,email,userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        AvatarName = "avatar.png";
    }
    public string Name { get; private set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public List<Wallet> Wallets { get; set; }
    public List<UserAddress> UserAddresses { get; set; }

    public static User RegisterUser(string phoneNumber, string password,IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, "", password, Gender.None, userDomainService);
    }

    public void EditUser(string name, string family, string phoneNumber, string email ,Gender gender,IUserDomainService userDomainService)
    {
        Guard(phoneNumber,email,userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
       
    }

    public void SetAvatar(string avatar)
    {
        NullOrEmptyDomainException.CheckString(avatar,nameof(avatar));
        AvatarName = avatar;
    }
    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        UserAddresses.Add(address);
    }

    public void EditAddress(UserAddress address)
    {
        var oldAddress = UserAddresses.FirstOrDefault(c => c.Id == address.Id);
        if (oldAddress == null)
        {
            throw new NullOrEmptyDomainException("آدرسی یافت نشد");
        }

        UserAddresses.Remove(oldAddress);
        UserAddresses.Add(address);
    }

    public void RemoveAddress(Guid addressId)
    {
        var oldAddress = UserAddresses.FirstOrDefault(c => c.Id == addressId);
        if (oldAddress == null)
        {
            throw new NullOrEmptyDomainException("آدرسی یافت نشد");
        }

        oldAddress.IsDelete = true;
    }

    public void ChargeWallet(Wallet wallet)
    {
        Wallets.Add(wallet);
    }

    public void AddUserRoles(List<UserRole> roles)
    {
        UserRoles.Clear();
        UserRoles.ForEach(c=>c.UserId=Id);
        UserRoles.AddRange(roles);
    }

    public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
    {
        NullOrEmptyDomainException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainException.CheckString(email, nameof(email));

        if (phoneNumber.Length != 11)
        {
            throw new InvalidDomainException("شماره موبایل معتبر نیست");
        }

        if (!EmailValidation.IsValidEmail(email))
        {
            throw new InvalidDomainException("ایمیل معتبر نیست");
        }

        if (email != Email)
        {
            if (userDomainService.IsEmailExist(email))
            {
                throw new InvalidDomainException("ایمیل وارد شده تکراری است");
            }
        }

        if (phoneNumber != PhoneNumber)
        {
            if (userDomainService.IsEmailExist(phoneNumber))
            {
                throw new InvalidDomainException("شماره موبایل وارد شده تکراری است");
            }
        }
    }
}