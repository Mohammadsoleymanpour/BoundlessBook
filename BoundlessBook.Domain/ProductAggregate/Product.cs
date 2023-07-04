using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Common.Common.Domain.Tools;
using BoundlessBook.Common.Common.Domain.ValueObjects;
using BoundlessBook.Domain.ProductAggregate.Services;

namespace BoundlessBook.Domain.ProductAggregate;

public class Product:AggregateRoot
{
    public Product()
    {
        
    }
    public Product(string title, string description, string imageName, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, IProductDomainService productService, SeoData seoData)
    {
        Guard(title, slug, description, imageName, productService);
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


    public void Edit(string title, string description, string imageName, Guid categoryId, Guid subCategoryId, Guid secondarySubCategoryId, string slug, IProductDomainService productService, SeoData seoData)
    {
        Guard(title,slug,description,imageName,productService);
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

    public void Guard(string title,string slug ,string description, string imageName,IProductDomainService productService)
    {
        NullOrEmptyDomainException.CheckString(title,nameof(title));
        NullOrEmptyDomainException.CheckString(description,nameof(description));
        NullOrEmptyDomainException.CheckString(imageName,nameof(imageName));

        if (productService.SlugIsExist(slug.ToSlug()))
        {
            throw new InvalidDomainException(" slug تکراری است");
        }

    }
}