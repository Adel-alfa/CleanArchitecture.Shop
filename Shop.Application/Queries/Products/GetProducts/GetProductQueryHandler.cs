using Mapster;
using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Application.Queries.GetProducts;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Products.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository productRepository;

        public GetProductQueryHandler(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }
        public async Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync(cancellationToken);
            return products.Adapt<GetProductResponse>();
        }
    }
}
