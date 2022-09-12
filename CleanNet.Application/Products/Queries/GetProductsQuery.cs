using CleanNet.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanNet.Application.Products.Queries;

public class GetProductsQuery : IRequest<IEnumerable<Product>>
{
}
