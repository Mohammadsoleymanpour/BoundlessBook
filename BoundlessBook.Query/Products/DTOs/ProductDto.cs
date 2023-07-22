using BoundlessBook.Common.Common.Domain.ValueObjects;
using BoundlessBook.Common.Common.Query;
using BoundlessBook.Common.Common.Query.Filter;
using BoundlessBook.Domain.ProductAggregate;

namespace BoundlessBook.Query.Products.DTOs;

public class ProductDto : BaseDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public ProductCategoryDto Category { get; set; }
    public ProductCategoryDto SubCategory { get; set; }
    public ProductCategoryDto SecondarySubCategory { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDto> ProductImages { get; set; }
    public List<ProductSpecificationDto> ProductSpecifications { get; set; }
}

public class ProductFilterData : BaseDto
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Slug { get; set; }
}

public class ProductFilterResult : BaseFilter<ProductFilterData, ProductFilterParams>
{

}

public class ProductFilterParams : BaseFilterParam
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}

public class ProductImageDto : BaseDto
{
    public Guid ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}

public class ProductSpecificationDto : BaseDto
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class ProductCategoryDto : BaseDto
{
    public string Title { get; set; }
    public Guid? ParentId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }

}