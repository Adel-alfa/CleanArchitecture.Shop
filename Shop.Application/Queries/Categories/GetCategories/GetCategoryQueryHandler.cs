using Mapster;
using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Categories.GetCategories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, GetCategoryResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository CategoryRepository)
        {
            categoryRepository = CategoryRepository;
        }
        public async Task<GetCategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetAllAsync(cancellationToken);
            return categories.Adapt<GetCategoryResponse>();
        }
    }
}
