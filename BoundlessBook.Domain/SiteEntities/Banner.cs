using BoundlessBook.Common.Common.Domain;
using BoundlessBook.Common.Common.Domain.Exceptions;

namespace BoundlessBook.Domain.SiteEntities;

public class Banner:BaseEntity
{
    public Banner()
    {
        
    }

    public Banner(string link, string imageName, BannerPosition bannerPosition)
    {
        Guard(imageName,link);
        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition BannerPosition { get; set; }

    public void Edit(string link, string imageName, BannerPosition bannerPosition)
    {
        Guard(imageName,link);
        Link = link;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }

    public void Guard(string imageName,string link)
    {
        NullOrEmptyDomainException.CheckString(imageName,nameof(imageName));
        NullOrEmptyDomainException.CheckString(link,nameof(link));
    }
}

public enum BannerPosition
{
    Right,Left
}