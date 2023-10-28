using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Query.Categories.DTOs;

namespace BoundlessBook.Query.Products.DTOs;

public class ProductShopResult : BaseFilter<ProductResultDto,ProductResultFilterParam>
{
    public CategoryDto CategoryDto { get; set; }
}

public class ProductResultDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public Guid InventoryId { get; set; }
    public float Price { get; set; }
    public int DiscountPercent { get; set; }
    public string ImageName { get; set; }

    public float TotalPrice
    {
        get
        {
            var discount = (Price * DiscountPercent) / 100 ;
            return Price - discount ;
        }
    }

}

public class ProductResultFilterParam : BaseFilterParam
{
    public string? CategorySlug { get; set; }
    public string? Search { get; set; }
    public bool OnlyAvailableProduct { get; set; } = false;
    public bool JustHasDiscount { get; set; } = false;
    public ProductSearchOrderBy ProductOrderBy { get; set; } = ProductSearchOrderBy.Latest; 
}

public enum ProductSearchOrderBy
{
    Latest,
    Expensive,
    Cheapest 
}