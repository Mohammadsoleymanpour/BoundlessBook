using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Domain.ValueObjects;

namespace BoundlessBook.Application.Categories.Create;

public record CreateCategoryCommand(string Title, string Slug,SeoData SeoData) : IBaseCommand<Guid>;
