using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller.Inventories.GetList;

public record GetInventoriesQuery(Guid SellerId):IQuery<List<InventoryDto>>;
