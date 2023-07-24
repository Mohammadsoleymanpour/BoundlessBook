using BoundlessBook.Common.Common.Application;

namespace BoundlessBook.Application.Categories.Remove;

public class RemoveCategoryCommand : IBaseCommand
{
    public RemoveCategoryCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }

}