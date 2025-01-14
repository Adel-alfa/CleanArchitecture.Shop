using MediatR;
using Shop.Contracts.Dtos;
using Shop.Contracts.Responses;
using Shop.Contracts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Products.GetProductByPage
{
    public record GetProductPageQuery(PaginationParameters PaginationParameters) : IRequest<PaginationList<ProductDto>>;
     
}
