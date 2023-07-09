using BoundlessBook.Common.Common.Domain.BaseRepository;

namespace BoundlessBook.Domain.SellerAggregate;

public interface ISellerRepository:IBaseRepository<Seller>
{
    Task<InventoryResult> GetInventoryById(Guid  id);
}

public class InventoryResult
{
    public Guid Id { get; set; }
    public Guid SellerId { get; set; }
    public Guid ProductId { get; set; }
    public int  Count { get; set; }
    public float Price { get; set; }

}