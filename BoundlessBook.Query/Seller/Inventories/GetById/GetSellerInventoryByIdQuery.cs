using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller.Inventories.GetById;

public record GetSellerInventoryByIdQuery(Guid InventoryId):IQuery<InventoryDto>;