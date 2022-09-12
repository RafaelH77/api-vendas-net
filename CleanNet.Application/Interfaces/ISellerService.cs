using CleanNet.Application.DTOs;

namespace CleanNet.Application.Interfaces;

public interface ISellerService
{
    Task<IEnumerable<SellerDTO>> GetSellers();
    Task<SellerDTO> GetById(int? id);
    Task Add(SellerDTO sellerDto);
    Task Update(SellerDTO sellerDto);
    Task Remove(int? id);
}
