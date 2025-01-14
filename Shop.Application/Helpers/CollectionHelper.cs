using Microsoft.EntityFrameworkCore;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Helpers
{
    public static class CollectionHelper<T>
    {
        public static async Task<PaginationList<T>> ToPaginationList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginationList<T>(items, count, pageNumber, pageSize);
        }
    }
}
