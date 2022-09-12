using AutoMapper;
using CleanNet.Application.DTOs;
using CleanNet.Application.Products.Commands;

namespace CleanNet.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
