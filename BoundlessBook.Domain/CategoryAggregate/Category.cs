﻿using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;
using BoundlessBook.Common.Common.Domain.Tools;
using BoundlessBook.Common.Common.Domain.ValueObjects;
using BoundlessBook.Domain.CategoryAggregate.Service;

namespace BoundlessBook.Domain.CategoryAggregate;

public class Category:AggregateRoot
{
    public Category()
    {
        Child = new List<Category>();
    }
    public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
        Guard(title,slug,categoryService);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
        Child = new List<Category>();
    }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public Guid? ParentId { get; set; }
    public List<Category> Child { get; set; }
    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
        Guard(title,slug,categoryService);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }

    public Guid AddChild(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
       var child =  new Category(title,slug,seoData,categoryService)
        {
            ParentId = Id
        };
       Child.Add(child);
       return child.Id;
    }
    public void Guard(string title, string slug,ICategoryDomainService categoryService)
    {
        NullOrEmptyDomainException.CheckString(title,nameof(title));
        NullOrEmptyDomainException.CheckString(slug,nameof(slug));
        slug = slug.ToSlug();
        if (categoryService.SlugIsExist(slug))
        {
            throw new InvalidDomainException("slug وارد شده تکراری است"); 
        }
    }
}