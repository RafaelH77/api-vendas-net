using CleanNet.Domain.Entities;
using CleanNet.Domain.Interfaces;
using CleanNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanNet.Infra.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private ApplicationDbContext _orderContext;
    public OrderRepository(ApplicationDbContext context)
    {
        _orderContext = context;
    }

    public async Task<Order> CreateAsync(Order order)
    {
        _orderContext.Add(order);
        await _orderContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> GetByIdAsync(int? id)
    {
        return await _orderContext.Orders.Include(s => s.Seller)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _orderContext.Orders.ToListAsync();
    }

    public async Task<Order> RemoveAsync(Order order)
    {
        _orderContext.Remove(order);
        await _orderContext.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        _orderContext.Update(order);
        await _orderContext.SaveChangesAsync();
        return order;
    }
}
