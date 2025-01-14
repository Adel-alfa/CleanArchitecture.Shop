using MediatR;
using Shop.Contracts.Responses;

namespace Shop.Application.Queries.GetProducts
{
    public record GetProductQuery():IRequest<GetProductResponse>;
    
}
