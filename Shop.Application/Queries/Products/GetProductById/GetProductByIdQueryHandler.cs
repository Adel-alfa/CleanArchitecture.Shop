using Mapster;
using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly IProductRepository productRepository;
        public GetProductByIdQueryHandler(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }

        
        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(Products), request.Id.ToString());
            }

            return product.Adapt<GetProductByIdResponse>();
        }
    }
}
