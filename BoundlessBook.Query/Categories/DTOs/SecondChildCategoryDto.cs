using BoundlessBook.Common.Common.Domain.ValueObjects;
using BoundlessBook.Common.Common.Query;
using BoundlessBook.Domain.CategoryAggregate;

namespace BoundlessBook.Query.Categories.DTOs;

public class SecondChildCategoryDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Guid? ParentId { get; set; }
}