using BoundlessBook.Domain.SellerAggregate;
using BoundlessBook.Domain.SellerAggregate.Services;

namespace BoundlessBook.Application.Sellers;

public class SellerDomainService: ISellerDomainService
{
    private readonly ISellerRepository _sellerRepository;

    public SellerDomainService(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }
    public bool CheckSellerInfo(Seller seller)
    {
        var result = _sellerRepository.Exists(c => c.NationalCode == seller.NationalCode);
        return !result;
    }

    public bool NationalCodeIsExist(string nationalCode)
    {
        return _sellerRepository.Exists(c => c.NationalCode == nationalCode);
    }
}