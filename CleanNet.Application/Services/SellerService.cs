using AutoMapper;
using CleanNet.Application.DTOs;
using CleanNet.Application.Interfaces;
using CleanNet.Domain.Entities;
using CleanNet.Domain.Interfaces;

namespace CleanNet.Application.Services;

public class SellerService : ISellerService
{
    private ISellerRepository _sellerRepository;
    private readonly IMapper _mapper;
    public SellerService(ISellerRepository sellerRepository, IMapper mapper)
    {
        _sellerRepository = sellerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SellerDTO>> GetSellers()
    {
        var categoriesEntity = await _sellerRepository.GetSellers();
        return _mapper.Map<IEnumerable<SellerDTO>>(categoriesEntity);
    }

    public async Task<SellerDTO> GetById(int? id)
    {
        var sellerEntity = await _sellerRepository.GetById(id);
        return _mapper.Map<SellerDTO>(sellerEntity);
    }

    public async Task Add(SellerDTO sellerDto)
    {
        var sellerEntity = _mapper.Map<Seller>(sellerDto);
        await _sellerRepository.Create(sellerEntity);
        sellerDto.Id = sellerEntity.Id;
    }

    public async Task Update(SellerDTO sellerDto)
    {
        var sellerEntity = _mapper.Map<Seller>(sellerDto);
        await _sellerRepository.Update(sellerEntity);
    }

    public async Task Remove(int? id)
    {
        var sellerEntity = _sellerRepository.GetById(id).Result;
        await _sellerRepository.Remove(sellerEntity);
    }
}