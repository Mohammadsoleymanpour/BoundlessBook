using MediatR;

namespace BoundlessBook.Common;

public class BaseDomainEvent : INotification
{
    public DateTime CreationDate { get; protected set; }

    public BaseDomainEvent()
    {
        CreationDate = DateTime.Now;
    }
}