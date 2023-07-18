using BoundlessBook.Common.Common.Query;
using BoundlessBook.Query.Categories.DTOs;

namespace BoundlessBook.Query.Categories.GetByParentId;

public record GetCategoriesByParentIdQuery(Guid ParentId) : IQuery<List<ChildCategoryDto>>;
