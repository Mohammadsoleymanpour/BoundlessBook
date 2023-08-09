using AutoMapper;
using BoundlessBook.Application.Users.AddAddress;
using BoundlessBook.Bootstrapper.ViewModels.UserAddress;

namespace BoundlessBook.Bootstrapper.Infrastructure;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<AddAddressCommand, AddUserAddressViewModel>().ReverseMap();
    }
}