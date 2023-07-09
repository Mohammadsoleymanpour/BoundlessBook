using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace BoundlessBook.Application.Products.Edit;

public class EditProductCommand : IBaseCommand
{
    public EditProductCommand(Guid productId, string title, string description, IFormFile imageFile, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, SeoData seoData, Dictionary<string, string> productSpecifications)
    {
        ProductId = productId;
        Title = title;
        Description = description;
        ImageFile = imageFile;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug;
        SeoData = seoData;
        ProductSpecifications = productSpecifications;
    }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile ImageFile { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Dictionary<string, string> ProductSpecifications { get; set; }
}