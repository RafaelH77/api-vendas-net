using CleanNet.Application.DTOs;
using CleanNet.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SellersController : ControllerBase
{
    private readonly ISellerService _sellerService;
    public SellersController(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SellerDTO>>> Get()
    {
        var categories = await _sellerService.GetSellers();
        if (categories == null)
        {
            return NotFound("Sellers not found");
        }
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetSeller")]
    public async Task<ActionResult<SellerDTO>> Get(int id)
    {
        var seller = await _sellerService.GetById(id);
        if (seller == null)
        {
            return NotFound("Seller not found");
        }
        return Ok(seller);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SellerDTO sellerDto)
    {
        if (sellerDto == null)
            return BadRequest("Invalid Data");

        await _sellerService.Add(sellerDto);

        return new CreatedAtRouteResult("GetSeller", new { id = sellerDto.Id },
            sellerDto);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] SellerDTO sellerDto)
    {
        if (id != sellerDto.Id)
            return BadRequest();

        if (sellerDto == null)
            return BadRequest();

        await _sellerService.Update(sellerDto);

        return Ok(sellerDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<SellerDTO>> Delete(int id)
    {
        var seller = await _sellerService.GetById(id);
        if (seller == null)
        {
            return NotFound("Seller not found");
        }

        await _sellerService.Remove(id);

        return Ok(seller);

    }
}
