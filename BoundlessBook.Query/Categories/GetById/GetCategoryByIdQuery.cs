using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Categories.DTOs;

namespace BoundlessBook.Query.Categories.GetById;

public record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryDto>;
