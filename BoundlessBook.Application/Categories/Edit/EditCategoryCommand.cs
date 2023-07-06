using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Domain.ValueObjects;

namespace BoundlessBook.Application.Categories.Edit;

public record EditCategoryCommand(Guid CategoryId,string Title,string Slug,SeoData SeoData) : IBaseCommand;
