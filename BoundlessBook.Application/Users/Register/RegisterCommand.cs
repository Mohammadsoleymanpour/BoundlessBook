using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Users.Register;

public class RegisterCommand:IBaseCommand
{
    public RegisterCommand(string password, string phoneNumber)
    {
        Password = password;
        PhoneNumber = phoneNumber;
    }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

}