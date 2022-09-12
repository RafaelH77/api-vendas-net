using AutoMapper;
using CleanNet.Application.DTOs;
using CleanNet.Application.Interfaces;
using CleanNet.Domain.Entities;
using CleanNet.Domain.Interfaces;

namespace CleanNet.Application.Services;

public class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderDTO>> GetOrders()
    {
        var orderEntity = await _orderRepository.GetOrdersAsync();
        return _mapper.Map<IEnumerable<OrderDTO>>(orderEntity);
    }

    public async Task<OrderDTO> GetById(int? id)
    {
        var orderEntity = await _orderRepository.GetByIdAsync(id);
        return _mapper.Map<OrderDTO>(orderEntity);
    }

    public async Task Add(OrderDTO orderDto)
    {
        var orderEntity = _mapper.Map<Order>(orderDto);
        await _orderRepository.CreateAsync(orderEntity);
        orderDto.Id = orderEntity.Id;
    }

    public async Task Update(OrderDTO orderDto)
    {
        var orderEntity = _mapper.Map<Order>(orderDto);
        await _orderRepository.UpdateAsync(orderEntity);
    }

    public async Task Remove(int? id)
    {
        var orderEntity = _orderRepository.GetByIdAsync(id).Result;
        await _orderRepository.RemoveAsync(orderEntity);
    }
}
