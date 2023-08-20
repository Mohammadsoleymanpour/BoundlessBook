using System.ComponentModel.DataAnnotations;

namespace BoundlessBook.Bootstrapper.ViewModels.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "شماره تلفن خود را وارد کنید")]
    [MaxLength(11,ErrorMessage = "شماره تلفن نمیتواند بیشتر از 11 کاراکتر باشد")]
    [MinLength(11,ErrorMessage = "شماره تلفن نمیتواند کمتر از 11 کاراکتر باشد")] 
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
    public string Password { get; set; }
}

public class RegisterViewModel
{
    [Required(ErrorMessage = "شماره تلفن خود را وارد کنید")]
    [MaxLength(11, ErrorMessage = "شماره تلفن نمیتواند بیشتر از 11 کاراکتر باشد")]
    [MinLength(11, ErrorMessage = "شماره تلفن نمیتواند کمتر از 11 کاراکتر باشد")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]
    [MinLength(6,ErrorMessage = "کلمه عبور باید بیشتر از 6 کاراکتر باشد")]
    public string Password { get; set; }
    [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]
    [Compare("Password",ErrorMessage = "تکرار کلمه عبور با کلمه عبور مغایرت دارد")]
    public string RePassword { get; set; }
}   