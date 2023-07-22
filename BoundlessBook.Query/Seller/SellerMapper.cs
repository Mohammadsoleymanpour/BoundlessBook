using BoundlessBook.Query.Seller.DTOs;

namespace BoundlessBook.Query.Seller;

public static class SellerMapper
{
    public static SellerDto Map(this Domain.SellerAggregate.Seller seller)
    {
        return new SellerDto()
        {
            IsDelete = seller.IsDelete,
            Id = seller.Id,
            CreationDate = seller.CreationDate,
            NationalCode = seller.NationalCode,
            SellerStatus = seller.SellerStatus,
            ShopeName = seller.ShopName,
            UserId = seller.UserId,
        };
    }

    public static List<SellerDto> Map(this List<Domain.SellerAggregate.Seller> seller)
    {
        var sellerDtos = new List<SellerDto>();
        foreach (var item in seller)
        {
            sellerDtos.Add(new SellerDto()
            {
                IsDelete = item.IsDelete,
                Id = item.Id,
                CreationDate = item.CreationDate,
                NationalCode = item.NationalCode,
                SellerStatus = item.SellerStatus,
                ShopeName = item.ShopName,
                UserId = item.UserId,
            });
        }

        return sellerDtos;
    }
}