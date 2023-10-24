using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Seller.DTOs;
using Dapper;

namespace BoundlessBook.Query.Seller.Inventories.GetList;

public class GetInventoriesQueryHandler:IQueryHandler<GetInventoriesQuery,List<InventoryDto>>
{
    private readonly DapperContext _dapperContext;

    public GetInventoriesQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<List<InventoryDto>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql =
                @$"SELECT i.Id, SellerId, ProductId , Count ,Price , i.CreationDate , DiscountPercent as DiscountPercentage, s.ShopName,
p.Title as ProductTitle , p.ImageName as ProductImage
From {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId = s.Id
inner join {_dapperContext.Products} p on i.ProductId = p.Id WHERE i.SellerId = @sellerId";


            var inventory =
                await connection.QueryAsync<InventoryDto>(sql, new { sellerId = request.SellerId });


            return inventory.ToList() ?? null;
        }
    }
}