using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.Users.Edit;

public class EditUserCommand:IBaseCommand
{
    public EditUserCommand(Guid userId, IFormFile avatarFile, string name, string family, string phoneNumber, string email, string password, Gender gender)
    {
        UserId = userId;
        AvatarFile = avatarFile;
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }
    public Guid UserId { get; set; }
    public IFormFile AvatarFile { get; set; }
    public string Name { get; private set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }
}