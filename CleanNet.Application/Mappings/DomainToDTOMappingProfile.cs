using AutoMapper;
using CleanNet.Application.DTOs;
using CleanNet.Domain.Entities;

namespace CleanNet.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Seller, SellerDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
    }
}
