namespace BoundlessBook.Domain.SellerAggregate.Services;

public interface ISellerDomainService
{
    bool CheckSellerInfo(Seller seller);
    bool NationalCodeIsExist(string nationalCode);
}