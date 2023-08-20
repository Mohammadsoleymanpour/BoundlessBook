using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.Addresses.DTOs;

namespace BoundlessBook.Query.Users.Addresses.GetList;

public record GetAddressByIdQuery(Guid id):IQuery<AddressDto>;