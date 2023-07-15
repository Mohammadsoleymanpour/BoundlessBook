using BoundlessBook.Domain.CategoryAggregate;
using BoundlessBook.Query.Categories.DTOs;

namespace BoundlessBook.Query.Categories;

public static class CategoryMapper
{
    public static CategoryDto Map(this Category category)
    {
        if (category == null)
        {
            return null;
        }

        CategoryDto categoryDto = new CategoryDto()
        {
            IsDelete = category.IsDelete,
            SeoData = category.SeoData,
            CreationDate = category.CreationDate,
            Id = category.Id,
            Slug = category.Slug,
            Title = category.Title,
            Child = MapChild(category.Child)
        };

        return categoryDto;
    }
    
    public static List<CategoryDto> Map(this List<Category> categories)
    {
        var categoryDtos = new List<CategoryDto>();
        foreach (var item in categories)
        {
            categoryDtos.Add(new CategoryDto()
            {
                SeoData = item.SeoData,
                CreationDate = item.CreationDate,
                Id = item.Id,
                Slug = item.Slug,
                Title = item.Title,
                Child = MapChild(item.Child),
                IsDelete = item.IsDelete
            });
        }
        return categoryDtos;
    }

    public static List<ChildCategoryDto> MapChild(this List<Category> categories)
    {
        var childCategories = new List<ChildCategoryDto>();

        foreach (var item in categories)
        {
            childCategories.Add(new ChildCategoryDto()
            {
                SeoData = item.SeoData,
                IsDelete = item.IsDelete,
                CreationDate = item.CreationDate,
                Id = item.Id,
                Slug = item.Slug,
                Title = item.Title,
                ParentId = item.ParentId,
                Child = MapSecondChild(item.Child)
            });
        }
        return childCategories;
    }

    private static List<SecondChildCategoryDto> MapSecondChild(this List<Category> categories)
    {
        var secondChilds = new List<SecondChildCategoryDto>();
        foreach (var item in categories)
        {
            secondChilds.Add(new SecondChildCategoryDto()
            {
                IsDelete = item.IsDelete,
                SeoData = item.SeoData,
                CreationDate = item.CreationDate,
                Id = item.Id,
                Slug = item.Slug,
                Title = item.Title,
                ParentId = item.ParentId
            });
        }
        return secondChilds;
    }
}