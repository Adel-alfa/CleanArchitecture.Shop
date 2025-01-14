using Mapster;
using Shop.Contracts.Responses;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Mappings
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<IReadOnlyList<Product>, GetProductResponse>.NewConfig().Map(des => des.ProductDtos, src => src);

            TypeAdapterConfig<Product, GetProductByIdResponse>.NewConfig().Map(des => des.ProductDto, src => src);

            TypeAdapterConfig<IReadOnlyList<Category>, GetCategoryResponse>.NewConfig().Map(des => des.categoryDtos, src => src);
            TypeAdapterConfig<Category, GetCategoryByIdResponse>.NewConfig().Map(des => des.categoryDto, src => src);
        }
    }
}
