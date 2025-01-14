using MediatR;
using Shop.Application.Queries.Products.GetProductById;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Products.GetProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<GetProductByIdResponse>;

}
