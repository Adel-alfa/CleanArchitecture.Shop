using Mapster;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Helpers;
using Shop.Application.IServices.Infrastructure;
using Shop.Application.Queries.Products.GetProductByPage;
using Shop.Application.Queries.Products.GetProducts;
using Shop.Contracts.Dtos;
using Shop.Contracts.Responses;
using Shop.Domain.Entities;
using Shop.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ShopDbContext _db;
        public ProductRepository(ShopDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                 return await  _db.Products.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id)!;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)        
        {
            try
            {
                
                return await _db.Products.Include(p => p.Category).AsNoTracking().ToListAsync(); 
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<PaginationList<ProductDto>> GetPaginationAsync(GetProductPageQuery request, CancellationToken cancellationToken)
        {
            var query = _db.Products.Include(p => p.Category).ProjectToType<ProductDto>().AsQueryable();
            var paginationList = await CollectionHelper<ProductDto>.ToPaginationList(query, request.PaginationParameters.PageNumber,
                                         request.PaginationParameters.PageSize);
            return paginationList;
        }
        // 
    }
}
