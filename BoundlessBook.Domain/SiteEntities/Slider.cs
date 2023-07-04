using BoundlessBook.Common;
using BoundlessBook.Common.Exceptions;

namespace BoundlessBook.Domain.SiteEntities;

public class Slider:BaseEntity
{
    public Slider(string link, string imageName, string title)
    {
        Link = link;
        ImageName = imageName;
        Title = title;
    }
    public string Link { get; set; }
    public string ImageName { get; set; }
    public string Title { get; set; }

    public void Edit(string link, string imageName, string title)
    {
        Link=link;
        ImageName=imageName;
        Title=title;
    }

    public void Guard(string link, string imageName, string title)
    {
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));
        NullOrEmptyDomainException.CheckString(link, nameof(link));
        NullOrEmptyDomainException.CheckString(title, nameof(title));
    }
}