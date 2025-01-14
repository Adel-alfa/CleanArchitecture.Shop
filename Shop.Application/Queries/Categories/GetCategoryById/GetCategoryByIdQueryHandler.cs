using Mapster;
using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using Shop.Contracts.Responses;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository categoryRepository;
        public GetCategoryByIdQueryHandler(ICategoryRepository CategoryRepository)
        {
            categoryRepository = CategoryRepository;
        }
        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetByIdAsync(request.id, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.id.ToString());
            }
            return category.Adapt<GetCategoryByIdResponse>();
        }
    }
}
