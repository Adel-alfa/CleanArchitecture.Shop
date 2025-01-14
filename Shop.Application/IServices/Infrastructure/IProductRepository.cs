using Shop.Application.Queries.Products.GetProductByPage;
using Shop.Application.Queries.Products.GetProducts;
using Shop.Contracts.Dtos;
using Shop.Contracts.Responses;
using Shop.Domain.Entities;


namespace Shop.Application.IServices.Infrastructure
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PaginationList<ProductDto>> GetPaginationAsync(GetProductPageQuery request, CancellationToken cancellationToken);
       
    }
}
