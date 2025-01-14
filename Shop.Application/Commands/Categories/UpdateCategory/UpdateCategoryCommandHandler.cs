using MediatR;
using Shop.Application.Commands.Products.UpdateProduct;
using Shop.Application.IServices.Infrastructure;
using Shop.Contracts.Exceptions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Commands.Categories.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository CategoryRepository)
        {
            categoryRepository = CategoryRepository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var cateDatabase =await categoryRepository.GetByIdAsync (request.Id,cancellationToken);
            if(cateDatabase == null)
            {
                throw new NotFoundException(nameof(Category), request.Id.ToString());
            }
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                ModificationDate = DateTime.Now,
            };
            await categoryRepository.UpdateAsync(category, cancellationToken);
            
            
            return Unit.Value;
        }
    }
}
