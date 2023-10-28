using BoundlessBook.Common.Common.Query;
using BoundlessBook.Domain.SellerAggregate.Enums;
using BoundlessBook.Infrastructure.Dapper.Persistent;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Categories;
using BoundlessBook.Query.Categories.DTOs;
using BoundlessBook.Query.Products.DTOs;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Products.GetProductForShop;

public class GetProductForShopQueryHandler : IQueryHandler<GetProductForShopQuery, ProductShopResult>
{
    private readonly BoundlessBookContext _context;
    private readonly DapperContext _dapperContext;

    public GetProductForShopQueryHandler(BoundlessBookContext context, DapperContext dapperContext)
    {
        _context = context;
        _dapperContext = dapperContext;
    }
    public async Task<ProductShopResult> Handle(GetProductForShopQuery request, CancellationToken cancellationToken)
    {
        var @param = request.FilterParam;
        var conditions = "";
        var orderBy = "";
        var inventoryOrderBy = "i.Price ASC";
        CategoryDto selectedCategory = null;

        // Check Category Condition
        if (!string.IsNullOrEmpty(@param.CategorySlug))
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Slug == @param.CategorySlug);
            if (category != null)
            {
                conditions += @$"And (A.CategoryId ={category.Id} or A.SubCategoryId = {category.Id}
or A.SecondarySubCategoryId= {category.Id}  )";
                selectedCategory = category.Map();
            }
        }

        //Check Title Condition
        if (!string.IsNullOrEmpty(@param.Search))
        {
            conditions += @$"and A.Title Like N'%{param.Search}%'";
        }

        // Check Count Condition
        if (@param.OnlyAvailableProduct)
        {
            conditions += "and A.Count>1";
        }
        //Check Discount Condition
        if (@param.JustHasDiscount)
        {
            conditions += "And A.DiscountPercent>0";
            inventoryOrderBy = "i.DiscountPercent Desc";
        }

        switch (@param.ProductOrderBy)
        {
            case ProductSearchOrderBy.Latest:
                {
                    orderBy = "A.CreationDate Asc";
                    break;
                }

            case ProductSearchOrderBy.Expensive:
                {
                    orderBy = "A.Price Desc";
                    break;
                }

            case ProductSearchOrderBy.Cheapest:
                {
                    orderBy = "A.Price Asc";
                    break;
                }
        }

        using (var connection = _dapperContext.CreateConnection())
        {
            var skip = (param.PageId - 1) * param.Take;
            var sql = $@"SELECT Count(A.Title)
FROM(Select p.Title , i.Price , i.Id as InventoryId , i.DiscountPercent , i.Count ,p.CategoryId , p.SubCategoryId , p.SecondarySubCategoryId ,
p.Id as Id , s.SellerStatus , ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy} ) AS RN 
FROM {_dapperContext.Products} p
left join {_dapperContext.Inventories} i on p.Id=i.ProductId
left join {_dapperContext.Sellers} s on i.SellerId=s.Id)A
WHERE A.RN = 1 and A.SellerStatus=@status {conditions} ";


            var resultSql =
                $@"SELECT A.Slug , A.Id , A.Title , A.Price , A.InventoryId , A.DiscountPercent , A.ImageName , A.CreationDate
FROM (SELECT p.Title , i.Price , i.Id As InventoryId , i.DiscountPercent , p.ImageName , i.Count , p.CreationDate,
p.CategoryId , p.SubCategoryId , p.SecondarySubCategoryId , p.Slug , p.Id as Id , s.SellerStatus ,
ROW_NUMBER() OVER(PARTITION BY p.Id ORDER BY {inventoryOrderBy} ) AS RN
FROM {_dapperContext.Products} p
left join {_dapperContext.Inventories} i on p.Id=i.ProductId
left join {_dapperContext.Sellers} s on i.SellerId=s.Id)A
WHERE A.RN =1 AND A.SellerStatus=@status {conditions} order by {orderBy} offset @skip ROWS FETCH NEXT @take ROWS ONLY ";

            var count = await connection.QueryFirstAsync<int>(sql, new { status = SellerStatus.Accept });
            var result = await connection.QueryAsync<ProductResultDto>(resultSql, new
            {
                skip, take = @param.Take, status = SellerStatus.Accept
            });

            var model = new ProductShopResult()
            {
                CategoryDto = selectedCategory,
                FilterParams = @param,
                Data = result.ToList(),
            };
            model.GeneratePaging(@param.Take,param.PageId,count);
            return model; 
        }

    }
}