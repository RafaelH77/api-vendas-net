using CleanNet.Application.DTOs;
using CleanNet.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDTO>>> Get()
    {
        var produtos = await _orderService.GetOrders();
        if (produtos == null)
        {
            return NotFound("Orders not found");
        }
        return Ok(produtos);
    }

    [HttpGet("{id}", Name = "GetOrder")]
    public async Task<ActionResult<OrderDTO>> Get(int id)
    {
        var produto = await _orderService.GetById(id);
        if (produto == null)
        {
            return NotFound("Order not found");
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] OrderDTO produtoDto)
    {
        if (produtoDto == null)
            return BadRequest("Data Invalid");

        await _orderService.Add(produtoDto);

        return new CreatedAtRouteResult("GetOrder",
            new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] OrderDTO produtoDto)
    {
        if (id != produtoDto.Id)
        {
            return BadRequest("Data invalid");
        }

        if (produtoDto == null)
            return BadRequest("Data invalid");

        await _orderService.Update(produtoDto);

        return Ok(produtoDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<OrderDTO>> Delete(int id)
    {
        var produtoDto = await _orderService.GetById(id);

        if (produtoDto == null)
        {
            return NotFound("Order not found");
        }

        await _orderService.Remove(id);

        return Ok(produtoDto);
    }
}
