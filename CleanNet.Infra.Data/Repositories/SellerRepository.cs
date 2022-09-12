using CleanNet.Domain.Entities;
using CleanNet.Domain.Interfaces;
using CleanNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanNet.Infra.Data.Repositories;

public class SellerRepository : ISellerRepository
{
    private ApplicationDbContext _sellerContext;
    public SellerRepository(ApplicationDbContext context)
    {
        _sellerContext = context;
    }

    public async Task<Seller> Create(Seller seller)
    {
        _sellerContext.Add(seller);
        await _sellerContext.SaveChangesAsync();
        return seller;
    }

    public async Task<Seller> GetById(int? id)
    {
        var seller = await _sellerContext.Sellers.FindAsync(id);
        return seller;
    }

    public async Task<IEnumerable<Seller>> GetSellers()
    {
        return await _sellerContext.Sellers.OrderBy(c => c.Name).ToListAsync();
    }

    public async Task<Seller> Remove(Seller seller)
    {
        _sellerContext.Remove(seller);
        await _sellerContext.SaveChangesAsync();
        return seller;
    }

    public async Task<Seller> Update(Seller seller)
    {
        _sellerContext.Update(seller);
        await _sellerContext.SaveChangesAsync();
        return seller;
    }
}
