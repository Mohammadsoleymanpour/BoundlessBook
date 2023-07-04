namespace BoundlessBook.Common.Common.Domain;

public class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreationDate { get; private set; } = DateTime.Now;
    public bool IsDelete { get; set; } = false;


    public BaseEntity()
    {
        CreationDate = DateTime.Now;
    }
}