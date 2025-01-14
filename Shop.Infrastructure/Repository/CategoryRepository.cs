using Shop.Application.IServices.Infrastructure;
using Shop.Domain.Entities;
using Shop.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext db) : base(db)
        {
        }
    }
}
