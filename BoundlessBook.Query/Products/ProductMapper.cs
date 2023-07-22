using BoundlessBook.Domain.ProductAggregate;
using BoundlessBook.Infrastructure.Ef.Persistent;
using BoundlessBook.Query.Products.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BoundlessBook.Query.Products;

public static class ProductMapper
{
    public static ProductDto Map(this Product product)
    {
        return new ProductDto()
        {
            Id = product.Id,
            CreationDate = product.CreationDate,
            Description = product.Description,
            IsDelete = product.IsDelete,
            ImageName = product.ImageName,
            SeoData = product.SeoData,
            ProductSpecifications = product.ProductSpecifications.Select(c => new ProductSpecificationDto()
            {
                IsDelete = c.IsDelete,
                CreationDate = c.CreationDate,
                Id = c.Id,
                Key = c.Key,
                Value = c.Value
            }).ToList(),

            ProductImages = product.ProductImages.Select(c => new ProductImageDto()
            {
                CreationDate = c.CreationDate,
                Id = c.Id,
                IsDelete = c.IsDelete,
                ImageName = c.ImageName,
                ProductId = c.ProductId,
                Sequence = c.Sequence,
            }).ToList(),

            Slug = product.Slug,
            Title = product.Title,
            Category = new ProductCategoryDto(){Id = product.CategoryId},
            SubCategory = new ProductCategoryDto(){Id = product.SubCategoryId},
            SecondarySubCategory = new ProductCategoryDto(){Id = product.SecondarySubCategoryId}
        };
    }


    public static ProductFilterData MapListData(this Product product)
    {
        return new ProductFilterData()
        {
            Id = product.Id,
            CreationDate = product.CreationDate,
            IsDelete = product.IsDelete,
            ImageName = product.ImageName,
            Slug = product.Slug,
            Title = product.Title,
        };
    }

    public static async Task<ProductDto> SetCategories(this ProductDto product, BoundlessBookContext context)
    {
        var category = await context.Categories.Where(c=>c.Id==product.Category.Id)
            .Select(c=>new ProductCategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                IsDelete = c.IsDelete,
                SeoData = c.SeoData,
                ParentId = c.ParentId,
                Slug = c.Slug,
                Title = c.Title,
            }).FirstOrDefaultAsync();
       
        var subCategory = await context.Categories.Where(c => c.Id == product.SubCategory.Id)
            .Select(c => new ProductCategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                IsDelete = c.IsDelete,
                SeoData = c.SeoData,
                ParentId = c.ParentId,
                Slug = c.Slug,
                Title = c.Title,
            }).FirstOrDefaultAsync();

        var secondSubCategory = await context.Categories.Where(c => c.Id == product.SecondarySubCategory.Id)
            .Select(c => new ProductCategoryDto()
            {
                Id = c.Id,
                CreationDate = c.CreationDate,
                IsDelete = c.IsDelete,
                SeoData = c.SeoData,
                ParentId = c.ParentId,
                Slug = c.Slug,
                Title = c.Title,
            }).FirstOrDefaultAsync();

        if (category!=null)
        {
            product.Category = category;
        }

        if (subCategory!=null)
        {
            product.SubCategory = subCategory;
        }

        if (secondSubCategory !=null)
        {
            product.SecondarySubCategory = secondSubCategory;
        }


        return product;
    } 
}