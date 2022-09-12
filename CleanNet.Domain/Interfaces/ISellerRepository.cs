using CleanNet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanNet.Domain.Interfaces;

public interface ISellerRepository
{
    Task<IEnumerable<Seller>> GetSellers();
    Task<Seller> GetById(int? id);

    Task<Seller> Create(Seller seller);
    Task<Seller> Update(Seller seller);
    Task<Seller> Remove(Seller seller);
}
