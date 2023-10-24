using BoundlessBook.Common.Common.Query;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Query.Seller.DTOs;
using Dapper;

namespace BoundlessBook.Query.Seller.Inventories.GetById;

public class GetSellerInventoryByIdQueryHandler : IQueryHandler<GetSellerInventoryByIdQuery, InventoryDto>
{
    private readonly DapperContext _dapperContext;

    public GetSellerInventoryByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<InventoryDto> Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        using (var connection = _dapperContext.CreateConnection())
        {
            var sql =
                @$"SELECT i.Id, SellerId, ProductId , Count ,Price , i.CreationDate , DiscountPercent as DiscountPercentage , s.ShopName,
p.Title as ProductTitle , p.ImageName as ProductImage
From {_dapperContext.Inventories} i inner join {_dapperContext.Sellers} s on i.SellerId = s.Id
inner join {_dapperContext.Products} p on i.ProductId = p.Id WHERE i.Id = @id";


            var inventory =
                await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { id = request.InventoryId });


            return inventory ?? null;
        }
    }
}