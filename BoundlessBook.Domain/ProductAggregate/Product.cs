using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;
using BoundlessBook.Common.Tools;
using BoundlessBook.Common.ValueObjects;

namespace BoundlessBook.Domain.ProductAggregate;

public class Product:AggregateRoot
{
    public Product()
    {
        
    }
    public Product(string title, string description, string imageName, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, SeoData seoData)
    {
        Title = title;
        Description = description;
        ImageName = imageName;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid SecondarySubCategoryId { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public List<ProductSpecification> ProductSpecifications { get; set; }


    public void Edit(string title, string description, string imageName, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, SeoData seoData)
    {
        Title = title;
        Description = description;
        ImageName = imageName;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        SecondarySubCategoryId = secondarySubCategoryId;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public void AddImage(ProductImage image)
    {
        image.ProductId = Id;
        ProductImages.Add(image);
    }
    public void RemoveImage(Guid imageIdGuid)
    {
        var image = ProductImages.FirstOrDefault(x => x.Id==imageIdGuid);
        if (image == null)
        {
            throw new NullOrEmptyDomainException("تصویری یافت نشد");
        }
        ProductImages.Remove(image);
    }
    public void AddSpecification(List<ProductSpecification> specifications)
    {
        specifications.ForEach(c=>c.ProductId=Id);
        ProductSpecifications = specifications;
    }

    public void Guard(string title,string slug ,string description, string imageName,iprodu)
    {
        NullOrEmptyDomainException.CheckString(title,nameof(title));
        NullOrEmptyDomainException.CheckString(description,nameof(description));
        NullOrEmptyDomainException.CheckString(imageName,nameof(imageName));


    }
}