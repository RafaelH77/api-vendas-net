﻿using AutoMapper;
using CleanNet.Application.DTOs;
using CleanNet.Application.Interfaces;
using CleanNet.Application.Products.Commands;
using CleanNet.Application.Products.Queries;
using MediatR;

namespace CleanNet.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productsQuery = new GetProductsQuery();

        if (productsQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(productsQuery);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task<ProductDTO> GetById(int? id)
    {
        var productByIdQuery = new GetProductByIdQuery(id.Value);

        if (productByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");
         
        var result = await _mediator.Send(productByIdQuery);

        return _mapper.Map<ProductDTO>(result);
    }

    //public async Task<ProductDTO> GetProductCategory(int? id)
    //{
    //    var productByIdQuery = new GetProductByIdQuery(id.Value);

    //    if (productByIdQuery == null)
    //        throw new Exception($"Entity could not be loaded.");

    //    var result = await _mediator.Send(productByIdQuery);

    //    return _mapper.Map<ProductDTO>(result);
    //}

    public async Task Add(ProductDTO productDto)
    {
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
        await _mediator.Send(productCreateCommand);
    }

    public async Task Update(ProductDTO productDto)
    {
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
        await _mediator.Send(productUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var productRemoveCommand = new ProductRemoveCommand(id.Value);
        if (productRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(productRemoveCommand);
    }
}
