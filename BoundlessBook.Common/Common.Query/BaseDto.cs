namespace BoundlessBook.Common.Common.Query;

public class BaseDto
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDelete { get; set; }

}