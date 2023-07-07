using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Domain.ValueObjects;

namespace BoundlessBook.Application.Categories.AddChild;

public record AddCategoryChildCommand(Guid ParentId,string Title,string Slug,SeoData SeoData) : IBaseCommand;
