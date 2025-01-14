using MediatR;
using Shop.Application.IServices.Infrastructure;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository CategoryRepository)
        {
            categoryRepository= CategoryRepository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category { Name = request.Name };
            var result = await categoryRepository.CreateAsync(category,cancellationToken);
            return result.Id;
        }
    }
}
