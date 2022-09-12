using CleanNet.Application.DTOs;

namespace CleanNet.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetOrders();
    Task<OrderDTO> GetById(int? id);
    Task Add(OrderDTO orderDto);
    Task Update(OrderDTO orderDto);
    Task Remove(int? id);
}
