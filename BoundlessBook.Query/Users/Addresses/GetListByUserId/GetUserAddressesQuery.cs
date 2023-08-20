using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Users.Addresses.DTOs;

namespace BoundlessBook.Query.Users.Addresses.GetById;

public record GetUserAddressesQuery(Guid userId) : IQuery<List<AddressDto>>;