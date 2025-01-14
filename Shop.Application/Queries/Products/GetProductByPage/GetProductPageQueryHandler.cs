using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Dtos;
using Shop.Contracts.Responses;

namespace Shop.Application.Queries.Products.GetProductByPage
{
    public class GetProductPageQueryHandler : IRequestHandler<GetProductPageQuery, PaginationList<ProductDto>>
    {
        private readonly IProductRepository productRepository;
        public GetProductPageQueryHandler(IProductRepository ProductRepository)
        {
            productRepository = ProductRepository;
        }
        public async Task<PaginationList<ProductDto>> Handle(GetProductPageQuery request, CancellationToken cancellationToken)
        {
            var productslist = await productRepository.GetPaginationAsync(request, cancellationToken);

            return productslist;
        }
    }
}
